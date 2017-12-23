using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ItemLookUp.Tools.Breakdown;
using ItemLookUp.LookUp.Inventory;
using ItemLookUp.Tools;
using ItemLookUp.LookUp;

namespace ItemLookUp.Forms.FormTools
{
    public class KitBreakDownBuilder
    {
        private LinkedList<Kit> kits;
        private Search s;
        private LinkedList<DataGridView> kitBreakdownTables;
        private SortedSet<string> binLocations;

        /// <summary>
        /// Returns a collection of DataGridView's that contain kit breakdown info
        /// </summary>
        public LinkedList<DataGridView> KitBreakdownTables { get { return kitBreakdownTables; } }

        /// <summary>
        /// Returns a SortedSet of bin locations
        /// </summary>
        public SortedSet<string> BinLocations {  get { return binLocations; } }

        /// <summary>
        /// Create a breakdown process of tables
        /// </summary>
        /// <param name="kits">Collection of kits to breakdown</param>
        public KitBreakDownBuilder(LinkedList<Kit> kits, Search s)
        {
            this.kits = kits;
            this.s = s;
            kitBreakdownTables = new LinkedList<DataGridView>();
            binLocations = new SortedSet<string>();
        }

        /// <summary>
        /// Build DataGridView tables for breakdown process
        /// </summary>
        public void BuildTables()
        {
            foreach(Kit k in kits)
            {
                // Create breakdown for current kit
                KitBreakdown bd = new KitBreakdown(k, s);

                // create a new table
                DataGridView table = buildTable(k.ToString());

                // fill the table
                foreach(Transfer<Kit, Container<Component>, Component> transfer in bd.Breakdown())
                {
                    string From = transfer.From.ToString();
                    string To = transfer.To.ToString();
                    string Item = transfer.Item.ToString();

                    table.Rows.Add(From, To, Item, transfer.Item.Qty.ToString());
                }

                kitBreakdownTables.AddLast(table);

                binLocations.UnionWith(bd.PutAwayLocations());
            }
        }

        /// <summary>
        /// Build a single breakdown table
        /// </summary>
        /// <returns>DataGridView</returns>
        private DataGridView buildTable(string title)
        {
            DataGridView dgv = new DataGridView();

            dgv.Name = title;

            // Set properties of dgv
            dgv.Dock = DockStyle.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeRows = false;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Set up columns
            dgv.Columns.Add("from", "From Container");
            dgv.Columns.Add("to", "To Container");
            dgv.Columns.Add("item", "Item");
            dgv.Columns.Add("qty", "Quantity");
        
            // Make sure columns autosize
            foreach(DataGridViewColumn dgvcol in dgv.Columns)
            {
                dgvcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
                
            return dgv;
        }
    }
}
