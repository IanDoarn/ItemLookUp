using System.Data;
using ItemLookUp.DataBase;
using ItemLookUp.Barcodes;
using ItemLookUp.LookUp.Inventory;
using System.Collections.Generic;
using ItemLookUp.Tools.Exceptions;
using ItemLookUp.Tools;
using System;

/// <summary>
/// Searches through the IW for the given information
/// </summary>
namespace ItemLookUp.LookUp
{
    public class Search
    {
        private OracleDB oracle;
        private Postgres postgres;
        private BarcodeParser parser;

        /// <summary>
        /// Searches through the IW for the given information
        /// </summary>
        public Search(Postgres postgres, OracleDB oracle, BarcodeParser parser)
        {
            this.postgres = postgres;
            this.oracle = oracle;
            this.parser = parser;
        }

        /// <summary>
        /// Returns whether the kit is in the current inventory snapshot
        /// </summary>
        /// <param name="kit_number">Kit to check for</param>
        /// <returns></returns>
        public bool CheckInInventory(string kit_number, bool invalid=false)
        {
            string query;

            if (!invalid)
                query = string.Format("select serial_number from doarni.ci_product_data where product_number = '{0}'", 
                    kit_number);
            else
                query = string.Format("select * from doarni.invalid_kit_barcodes('{0}');",
                    kit_number);

            try
            {
                postgres.execute(query, true);
                return true;
            }
            catch(QueryError qError)
            {
                return false;
            }
            catch (DatabaseError dbError)
            {
                throw ErrorHandler.Throw(ErrorType.DATABASE_ERROR, "No connection currently made to database");
            }
        }

        /// <summary>
        /// Return a queue of barcodes based on a given kit number,
        /// Barcode strings returned are ktis that are invalid, meaning 
        /// they are missing more than one piece
        /// </summary>
        /// <param name="kitNumber">Kit Product Number</param>
        /// <returns></returns>
        public Queue<string> SearchByKitNumber(string kitNumber)
        {
            Queue<string> barcodes = new Queue<string>();
            try
            {
                DataTable dt = postgres.execute(string.Format(@"select * from doarni.invalid_kit_barcodes('{0}');", kitNumber), true);

                foreach (DataRow row in dt.Rows)
                    barcodes.Enqueue(row[0].ToString());

                return barcodes;
            }
            catch (QueryError qError)
            {
                throw qError;
            }
        }

        /// <summary>
        /// Search for given barcode and return the corresponding Product object
        /// </summary>
        /// <param name="input">barcode scanned</param>
        /// <returns>Product object</returns>
        public Product search(string input, Barcode barcode=null)
        {
            Barcode b;

            if (barcode != null)
                b = barcode;
            else
                b = parser.parse(input);

            switch (b.BType())
            {
                case BarcodeEnum.KIT:
                    return KitProduct((BKit) b);
                default:
                    break;
            }
            return null;
        }

        /// <summary>
        /// Search for given barcodes in a <code>Queue<string></code> 
        /// and return the corresponding Product object
        /// </summary>
        /// <param name="inputs"><code>Queue<string></code> of barcodes to search</param>
        /// <returns>LinkedList<Product></returns>
        public LinkedList<Product> search(Queue<string> inputs)
        {
            LinkedList<Product> products = new LinkedList<Product>();
            foreach(string barcode in inputs)
            {
                Barcode b = parser.parse(barcode);
                switch (b.BType())
                {
                    case BarcodeEnum.KIT:
                        products.AddLast(KitProduct((BKit)b));
                        break;
                    default:
                        break;
                }                
            }
            return products;
        }

        /// <summary>
        /// Returns the name of the product by searching the product id
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public DataTable SearchByProductId(string productid)
        {
            string query = string.Format("select distinct product_number, description from doarni.ci_product_library where item_id = {0}", productid);
            return postgres.execute(query, true);
        }

        /// <summary>
        /// Builds a Kit object based of the given barcode object information
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns>Kit</returns>
        private Kit KitProduct(BKit barcode)
        {            
            SQLBuilder builder = new SQLBuilder();
            int component_qty_std = 0;
            int qty_in_kit = 0;

            // Query for information about the kit
            builder.add("SELECT");
            builder.add(@"component_product_number,
                          component_description,
                          kit_product_number,
                          component_quantity_in_kit_std,
                          qty_in_kit");
            builder.add("FROM doarni.southaven_kit_data");
            builder.add(string.Format("WHERE kit_product_number = '{0}' AND serial_number = {1}", barcode.ProductNumber, barcode.SerialNumber));

            // Create collection of components for the kit
            LinkedList<Component> components = new LinkedList<Component>();

            DataTable dt = postgres.execute(builder.build(), true);

            // Build LinkedList of components in the kit
            foreach(DataRow row in dt.Rows)
            {
                string component_prod_num = row[0].ToString();
                string component_desc = row[1].ToString();
                string kit_prod_num = barcode.ProductNumber;
                component_qty_std += int.Parse(row[3].ToString());
                qty_in_kit += int.Parse(row[4].ToString());

                components.AddLast(new Component(component_prod_num, component_desc, kit_prod_num, int.Parse(row[3].ToString()), int.Parse(row[4].ToString())));
            }

            // Return the completed kit object
            return new Kit(barcode.ProductNumber, barcode, components, component_qty_std, qty_in_kit);
        }

        /// <summary>
        /// Execute a custome query
        /// </summary>
        /// <param name="query">query to execute</param>
        /// <param name="pg">use postgres</param>
        /// <param name="or">use oracle</param>
        /// <returns>DataTable</returns>
        public DataTable Custom(string query, bool pg=true, bool or = false)
        {
            if (pg)
                return postgres.execute(query, true);
            else
                return oracle.execute(query, true);
        }

        /// <summary>
        /// Takes user input and returns the products 
        /// systematically mapped location in the warehouse
        /// </summary>
        /// <returns>string</returns>
        public string ItemMapping(string item)
        {
            string zone = "";
            string position = "";
            string shelf = "";
            DataTable dt;
            SQLBuilder sql = new SQLBuilder();

            // TODO: implement barcode parsing to return different results
            switch (parser.parseType(item))
            {
                case BarcodeEnum.KIT:
                    string product = SearchByProductId(Utils.SplitKitBarcode(item)[0]).Rows[0][0].ToString();
                    sql.add("SELECT");
                    sql.add("zone, position, shelf");
                    sql.add("FROM doarni.ci_product_mapping");
                    sql.add(string.Format("WHERE product_number = '{0}'", product));

                    dt = postgres.execute(sql.build(), true);

                    zone = dt.Rows[0][0].ToString();
                    position = dt.Rows[0][1].ToString();
                    shelf = dt.Rows[0][2].ToString();
                    break;
                case BarcodeEnum.UNKNOWN:
                    // Attempt to find the item anyways
                    sql.add("SELECT");
                    sql.add("zone, position, shelf");
                    sql.add("FROM doarni.ci_product_mapping");
                    sql.add(string.Format("WHERE product_number = '{0}'", item));

                    try
                    {
                        dt = postgres.execute(sql.build(), true);

                        zone = dt.Rows[0][0].ToString();
                        position = dt.Rows[0][1].ToString();
                        shelf = dt.Rows[0][2].ToString();
                        break;
                    }
                    catch (QueryError qError)
                    {
                        // Could not find the item
                        throw ErrorHandler.Throw(ErrorType.INVENTORY, "Unknown barcode / item [" + item + "]");
                    }                                   
                default: break; // TODO implement new exception here
            }

            return string.Format("{0}-{1}-{2}", zone, position, shelf);

        }
    }
}
