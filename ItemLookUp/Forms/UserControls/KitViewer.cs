using System.Windows.Forms;
using ItemLookUp.LookUp.Inventory;

namespace ItemLookUp.Forms.UserControls
{
    public partial class KitViewer : UserControl
    {
        /// <summary>
        /// Kit associated with this control
        /// </summary>
        private Kit kit;

        public KitViewer(Kit kit)
        {
            this.kit = kit;            

            InitializeComponent();

            loadDetails();
            loadDataGridViews();
        }

        /// <summary>
        /// Load information into details text boxes
        /// </summary>
        void loadDetails()
        {
            detailsProductNumber.Text = kit.ProductNumber;
            detailsLotSerial.Text = kit.SerialNumber;
            detailsDescription.Text = kit.Description;
            detailsType.Text = kit.isValid() ? "Valid" : "Invalid";
            detailsContainer.Text = "NotImplemented";
            detailsInventoryType.Text = "Centralized Inventory";
            detailsComponentStd.Text = kit.ComponentStd.ToString();
            detailsComponentsContained.Text = kit.ComponentQty.ToString();
            detailsDiffFromStandard.Text = (kit.ComponentStd - kit.ComponentQty).ToString();
        }

        /// <summary>
        /// Load tables showing kits current components and kits diff from standard
        /// </summary>
        private void loadDataGridViews()
        {
            string container = kit.ProductNumber + " {" + kit.SerialNumber + "}";

            foreach (Component c in kit.Components)
            {
                // If the item is in the kit, add it to the components tab
                if(c.Qty > 0)
                {
                    dataGridViewComponents.Rows.Add(
                        c.ProductNumber, c.Description, container, 
                        c.QtyStandard.ToString(), c.Qty.ToString()
                        );
                }
                else if (c.Qty != c.QtyStandard && c.Qty > 0)
                {
                    // We ave some of the components and are missing some others

                    // Add what we have to the components table
                    dataGridViewComponents.Rows.Add(
                        c.ProductNumber, c.Description, container,
                        c.QtyStandard.ToString(), c.Qty.ToString()
                        );

                    // Add the difference to the diff table
                    dataGridViewDiff.Rows.Add(
                        (c.QtyStandard - c.Qty).ToString(), c.ProductNumber, c.Description
                        );
                }
                // Otherwise add it to the diff
                else 
                {
                    dataGridViewDiff.Rows.Add(
                        (c.QtyStandard - c.Qty).ToString(), c.ProductNumber, c.Description
                        );
                }
            }

        }
    }
}
