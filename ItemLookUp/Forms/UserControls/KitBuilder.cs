using System.Windows.Forms;
using ItemLookUp.LookUp.Inventory;
using System.Collections.Generic;
using System;
using ItemLookUp.Tools;

namespace ItemLookUp.Forms.UserControls
{
    /// <summary>
    /// KitBuilder
    /// 
    /// Kit Builder is a control to allow the user to build a kit and 
    /// create it a kit object dynamically in the program
    /// </summary>
    public partial class KitBuilder : Form
    {

        private string kitnumber;
        private string productid;
        private string description;
        private string serialnumber;

        private int componentstd;
        private int componentqty;

        private LinkedList<Component> componentlist;

        private Kit kit;

        public Kit NewKit {  get { return this.kit; } }

        private DialogResult result;

        /// <summary>
        /// Get the DialogResult
        /// </summary>
        public DialogResult Result { get { return result; } }
    
        public KitBuilder(
            string kitnumber, 
            string serialnumber,
            string productid,
            string description,
            int componentstd,
            LinkedList<Component> componentlist
            )
        {

            this.kitnumber = kitnumber;
            this.serialnumber = serialnumber;
            this.productid = productid;
            this.description = description;
            this.componentstd = componentstd;
            this.componentlist = componentlist;
            componentqty = componentstd;

            InitializeComponent();

            buttonSave.DialogResult = DialogResult.OK;

            setup();
        }

        /// <summary>
        /// Setup intial information before user see form
        /// </summary>
        void setup()
        {
            // Load details
            detailsComponentsContained.Text = componentstd.ToString();
            detailsComponentStd.Text = componentstd.ToString();
            detailsContainer.Text = "";
            detailsDescription.Text = description;
            detailsDiffFromStandard.Text = componentstd.ToString();
            detailsInventoryType.Text = "Centralized Inventory";
            detailsLotSerial.Text = serialnumber;
            detailsProductNumber.Text = kitnumber;
            detailsType.Text = "Kit";

            // Load components into datagridview
            foreach(Component c in componentlist)
            {
                dataGridViewComponents.Rows.Add(
                    c.ProductNumber,
                    c.Description,
                    Utils.FormatKitNumber(kitnumber, serialnumber),
                    c.QtyStandard.ToString(),
                    c.QtyStandard.ToString()
                    );
            }
        }

        /// <summary>
        /// Build a new kit object
        /// </summary>
        void build()
        {
            // Refresh compnent collection with updated info from the table
            foreach(DataGridViewRow row in dataGridViewComponents.Rows)
            {
                string component = row.Cells[0].Value.ToString();

                foreach (Component c in componentlist)
                {
                    if(c.ProductNumber.Equals(component))
                    {
                        // Update the components qty
                        int qty = int.Parse(row.Cells[4].Value.ToString());
                        c.Qty = qty;
                    }
                }
            }

            // Get a new count of the components
            int cQty = 0;
            foreach (Component c in componentlist)
                cQty += c.Qty;

            
            // create the new kit
            kit = new Kit(
                detailsProductNumber.Text,
                productid,
                detailsDescription.Text,
                detailsLotSerial.Text,
                componentlist,
                componentstd,
                cQty
                );
        }

        /// <summary>
        /// Executes on button save click, saves information user typed in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Set result to OK
            result = DialogResult.OK;
            // build the new kit
            build();
            // close the form
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Set result to OK
            result = DialogResult.Cancel;
            // Close the form
            this.Close();
        }
    }
}
