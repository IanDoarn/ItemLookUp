using System.Text.RegularExpressions;
using System.Data;
using ItemLookUp.Config;
using System;
using ItemLookUp.DataBase;
using ItemLookUp.Tools.Exceptions;

namespace ItemLookUp.Barcodes
{
    /// <summary>
    /// BarcodeParser
    /// Parses barcodes and returns to associated information
    /// </summary>
    public class BarcodeParser
    {
        /// <summary>
        /// Postgres connection
        /// </summary>
        private Postgres postgres;

        /// <summary>
        /// OracleDB connection
        /// </summary>
        private OracleDB oracle;
        
        /// <summary>
        /// Parses barcodes and returns to associated information
        /// </summary>
        /// <param name="p">Postgres database object</param>
        /// <param name="o">OracleDB databse object</param>
        public BarcodeParser(Postgres p, OracleDB o)
        {
            postgres = p;
            oracle = o;
        }

        /// <summary>
        /// Parse barcode and return Barcode object
        /// </summary>
        /// <param name="barcode">string to parse</param>
        /// <returns>object</returns>
        public Barcode parse(string barcode)
        {
            BarcodeEnum b = parse_barcode(barcode);

            if(!(b == BarcodeEnum.UNKNOWN))
            {
                return buildBarcode(b, barcode);
            }
            else
            {
                throw ErrorHandler.Throw(ErrorType.UKNOWN_BARCODE, "Unknown Barcode {" + barcode + "}");
            }
        }

        /// <summary>
        /// Returns the Enum of the barcode
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public BarcodeEnum parseType(string barcode)
        {
            return parse_barcode(barcode);
        }

        /// <summary>
        /// Parses given barcode using regex to match patterns
        /// </summary>
        /// <param name="input">string</param>
        /// <returns>BarcodeEnum</returns>
        private BarcodeEnum parse_barcode(string input)
        {
            if (Regex.Match(input, Constants.KitBarcodeRegexVerify).Success)
            {
                return BarcodeEnum.KIT;
            }
            else if(Regex.Match(input, Constants.ZtagBarcodeRegexVerify).Success)
            {
                return BarcodeEnum.ZTAG;
            }
            else
            {
                return BarcodeEnum.UNKNOWN;
            }
        }

        /// <summary>
        /// Builds a barcode based on the given Enum type and barcode string
        /// </summary>
        /// <param name="btype">BarcodeEnum</param>
        /// <param name="barcode">barcode number</param>
        /// <returns>Barcode object</returns>
        private Barcode buildBarcode(BarcodeEnum btype, string barcode)
        {
            SQLBuilder builder = new SQLBuilder();
            DataTable dt;

            switch (btype)
            {
                case BarcodeEnum.KIT:
                    string id, kit_number, desc, serial_number;
                    string[] s = barcode.Split('-');

                    id = s[1];
                    serial_number = s[2];

                    builder.add("SELECT product_number, description");
                    builder.add("FROM doarni.ci_product_data");
                    builder.add(string.Format(@"WHERE product_number_id = {0} AND serial_number = {1}", id, serial_number));

                    dt = postgres.execute(builder.build(), true);

                    builder.clear();

                    kit_number = dt.Rows[0][0].ToString();
                    desc = dt.Rows[0][1].ToString();

                    return new BKit(barcode, id, kit_number, desc, serial_number);
                case BarcodeEnum.BIN: throw new NotImplementedException("BIN barcodes not yet supported");
                case BarcodeEnum.GS1: throw new NotImplementedException("GS1 barcodes not yet supported");
                case BarcodeEnum.HIBC: throw new NotImplementedException("HIBC barcodes not yet supported");
                case BarcodeEnum.ZTAG: throw new NotImplementedException("ZTAG barcodes not yet supported");
                default:
                    break;
            }

            return null;
        }
    }
}
