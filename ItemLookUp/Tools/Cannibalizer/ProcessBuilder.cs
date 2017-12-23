using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ItemLookUp.LookUp.Inventory;


namespace ItemLookUp.Tools
{
    /// <summary>
    /// ProcessBuilder
    /// This class creates a process for cannibalizing kits
    /// </summary>
    public class ProcessBuilder
    {
        /* Instance Variables */
        /// <summary>
        /// Collection of rows to add to the table
        /// </summary>
        private LinkedList<Adhoc<Kit, Component>> transfers;

        private DataGridView processTable = new DataGridView();
        private DataGridView invalidKitsTable = new DataGridView();
        private DataGridView validKitsTable = new DataGridView();

        /// <summary>
        /// Kits being used in the process
        /// </summary>
        private Kit primaryKit, secondaryKit;

        /// <summary>
        /// Gets the primary kit
        /// </summary>
        public Kit PrimaryKit { get { return primaryKit; } }

        /// <summary>
        /// Gets the secondary kit
        /// </summary>
        public Kit SecondaryKit { get { return secondaryKit; } }

        /// <summary>
        /// Builds a process and outputs a file
        /// </summary>
        public ProcessBuilder()
        {
            setup();
        }

        /// <summary>
        /// Builds a process and outputs a file
        /// </summary>
        /// <param name="transfers">transfers to build table with</param>
        public ProcessBuilder(LinkedList<Adhoc<Kit, Component>> transfers)
        {
            this.transfers = transfers;
            setup();
        }

        /// <summary>
        /// Setup datagridview tables
        /// </summary>
        private void setup()
        {
            // Set properties of tables
            processTable.AllowUserToAddRows = false;
            processTable.AllowUserToDeleteRows = false;
            processTable.AllowUserToOrderColumns = false;

            invalidKitsTable.AllowUserToAddRows = false;
            invalidKitsTable.AllowUserToDeleteRows = false;
            invalidKitsTable.AllowUserToOrderColumns = false;

            validKitsTable.AllowUserToAddRows = false;
            validKitsTable.AllowUserToDeleteRows = false;
            validKitsTable.AllowUserToOrderColumns = false;

            // Set up processTable
            processTable.Columns.Add("transferType", "Transfer");
            processTable.Columns.Add("fromContainer", "From Container");
            processTable.Columns.Add("component", "Component");
            processTable.Columns.Add("toContainer", "To Container");
            processTable.Columns.Add("qty", "Qty");

            processTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            processTable.Dock = DockStyle.Fill;

            // Set Up invalid and valid kit tables
            invalidKitsTable.Columns.Add("productNumber", "Kit Number");
            invalidKitsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            invalidKitsTable.Dock = DockStyle.Fill;

            validKitsTable.Columns.Add("productNumber", "Kit Number");
            validKitsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            validKitsTable.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Wrapper to build datagridview of the process
        /// </summary>
        /// <returns></returns>
        public DataGridView ProcessTable()
        {
            return buildProcessTable();
        }

        /// <summary>
        /// Gets a DataGridView table of Invalid kits
        /// </summary>
        /// <returns></returns>
        public DataGridView InvalidKitsTable(Stack<Kit> invalidStack)
        {
            Stack<Kit> s = new Stack<Kit>(invalidStack);
            while (s.Count > 0)
            {
                Kit k = s.Pop();
                invalidKitsTable.Rows.Add(Utils.FormatKitNumber(k.ProductNumber, k.SerialNumber));
            }

            return invalidKitsTable;
        }

        /// <summary>
        /// Gets a DataGridView of Valid Kits
        /// </summary>
        /// <returns></returns>
        public DataGridView ValidKitsTable(Stack<Kit> validStack)
        {
            Stack<Kit> s = new Stack<Kit>(validStack);
            while(s.Count > 0)
            {
                Kit k = s.Pop();
                validKitsTable.Rows.Add(Utils.FormatKitNumber(k.ProductNumber, k.SerialNumber));
            }

            return validKitsTable;
        }

        /// <summary>
        /// Build DataGridView representation of the process
        /// </summary>
        /// <returns></returns>
        private DataGridView buildProcessTable()
        {   

            if(transfers == null || transfers.Count < 1)
            {
                return null;
            }
            else
            {
                foreach (Adhoc<Kit, Component> transfer in transfers)
                {

                    string from = Utils.FormatKitNumber(secondaryKit.ProductNumber, secondaryKit.SerialNumber);
                    string to = Utils.FormatKitNumber(primaryKit.ProductNumber, primaryKit.SerialNumber);
                    string component = transfer.Item.ProductNumber;
                    string qty = transfer.Qty.ToString();

                    processTable.Rows.Add("Adhoc", from, component, to, qty);
                }

                return processTable;
            }
        }
        
        /// <summary>
        /// Set primary kit. Primary kit is the kit that accept items
        /// </summary>
        /// <param name="k"></param>
        public void SetPrimary(Kit k)
        {
            primaryKit = k;
        }

        /// <summary>
        /// Set Secondary kit, Secondary is the kit that items will be taken from
        /// </summary>
        /// <param name="k"></param>
        public void SetSecondary(Kit k)
        {
            secondaryKit = k;
        }

        /// <summary>
        /// Add a process to the table
        /// </summary>
        /// <param name="transfer"></param>
        public void Add(Adhoc<Kit, Component> transfer)
        {
            this.transfers.AddLast(transfer);
        }

        /// <summary>
        /// Add a process to the table
        /// </summary>
        /// <param name="transfers"></param>
        public void Add(LinkedList<Adhoc<Kit, Component>> transfers)
        {
            this.transfers = transfers;
        }

    }
}
