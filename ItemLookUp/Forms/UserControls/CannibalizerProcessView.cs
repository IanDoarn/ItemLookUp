using System;
using System.Text;
using System.Windows.Forms;
using ItemLookUp.Tools;
using ItemLookUp.LookUp.Inventory;
using System.Collections.Generic;
using ItemLookUp.Config;
using ItemLookUp.Forms.FormTools;
using ItemLookUp.LookUp;
using System.Net;
using System.IO;
using System.Drawing;

namespace ItemLookUp.Forms.UserControls
{
    public partial class CannibalizerProcessView : UserControl
    {
        /// <summary>
        /// Cannibalizer object
        /// </summary>
        private Cannibalizer<Kit> cannibalizer;

        private Search search;

        /// <summary>
        /// Collection of valid kits from the cannibalizer
        /// </summary>
        public Stack<Kit> ValidKits;

        /// <summary>
        /// Collection of invalid kits from the cannibalizer
        /// </summary>
        public Stack<Kit> InvalidKits;

        /// <summary>
        /// Count of the total possible transfer that will be done
        /// </summary>
        private int totalTransfers = 0;

        /// <summary>
        /// Count of the number of cannibalizations that will be done
        /// </summary>
        private int iterations = 0;

        /// <summary>
        /// Creates a UserControl to view the cannibalization process
        /// </summary>
        /// <param name="cannibalizer">Cannibalizer object</param>
        public CannibalizerProcessView(Cannibalizer<Kit> cannibalizer, Search search)
        {
            this.search = search;

            // Set the cannibalizer up
            this.cannibalizer = cannibalizer;

            // Load controls
            InitializeComponent();

            // Run cannibalization
            fillControls();
            updateLog();
        }

        /// <summary>
        /// Executes on run click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If the queue isn't empty, update
            if (!cannibalizer.KitQueue.isEmpty())
            {
                fillControls();
                updateLog();
            }
            else
            {
                // Queue is empty
                MessageBox.Show("Queue empty! All kits in queue exhausted.");

            }
        }

        /// <summary>
        /// Update the process view log
        /// </summary>
        void updateLog()
        {
            StringBuilder sb = new StringBuilder();

            // Make sure the queue isn't empty
            if(cannibalizer.KitQueue.isEmpty())
            {
                // Queue is empty 
                sb.Append("Cannibalization complete.");
                sb.AppendLine();

                // Print report of process
                sb.Append("Report:");
                sb.AppendLine();

                // Print valid kits
                sb.Append("Valid kits: ");
                sb.AppendLine();
                foreach(Kit k in cannibalizer.ValidKits)
                {
                    sb.Append(k.ToString());
                    sb.AppendLine();
                }

                // Print invalid kits
                sb.Append("Invalid kits: ");
                sb.AppendLine();
                foreach (Kit k in cannibalizer.InvalidKits)
                {
                    sb.AppendFormat("{0} Component Qty in kit [{1}] Component Std [{2}]",
                        k.ToString(), k.ComponentQty.ToString(), k.ComponentStd.ToString()
                        );
                    sb.AppendLine();
                }

                // Print report
                sb.AppendFormat("Total iterations {0} with {1} possible transfers.",
                    iterations.ToString(), totalTransfers.ToString()
                    );

                // Check if anything was done
                if(cannibalizer.ValidKits.Count < 1)
                {
                    MessageBox.Show("No valid kits where made", "Cannibalization Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                // Cannibalization complete
                MessageBox.Show("Cannibalization Complete. Please use SMS to source and / or complete any remaining transfers into the remaining invalid kits", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                processViewTabControl.SelectedIndex = 1;

                // Check to see if we can breakdown any kits
                checkForBreakdowns();
            }
            else
            {
                string primary = cannibalizer.Process.PrimaryKit.ToString();
                string secondary = cannibalizer.Process.SecondaryKit.ToString();

                // See if items where pulled from the secondary
                if(cannibalizer.AdhocTransfers.Count < 1)
                {
                    sb.Append("No items pulled from: " + secondary);
                }
                else
                {
                    sb.Append("Primary kit: " + primary);
                    sb.AppendLine();

                    sb.Append("Pulling items from: " + secondary);
                    sb.AppendLine();

                    // Iterate each adhoc transfer
                    foreach (Adhoc<Kit, Component> t in cannibalizer.AdhocTransfers)
                    {
                        sb.AppendFormat("Component {0} from kit {1} to kit {2} qty moved {3}",
                            t.Item.ProductNumber, t.FromContainer.ToString(), t.ToContainer.ToString(), t.Qty.ToString()
                            );
                        sb.AppendLine();
                    }
                }
            }

            // Add a new line at the end
            sb.AppendLine();

            // Add the new information to the log text box
            processViewLogTextBox.AppendText(sb.ToString());
        }

        /// <summary>
        /// Fill controls and containers with new data each iteration of the cannibalization process
        /// </summary>
        void fillControls()
        {
            // Iterate the cannibalizer once
            cannibalizer.Cannibalize();
            iterations += 1;

            // Suspend layouts
            processViewTablePanel.SuspendLayout();
            processViewKitDetailsSplitContainer.SuspendLayout();

            // Clear the current controls
            processViewInvalidKitsPanel.Controls.Clear();
            processViewValidKitsPanel.Controls.Clear();
            processViewTablePanel.Controls.Clear();

            // Get new DataGridView objects
            DataGridView invalid = cannibalizer.Process.InvalidKitsTable(cannibalizer.InvalidKits);
            DataGridView valid = cannibalizer.Process.ValidKitsTable(cannibalizer.ValidKits);
            DataGridView table = cannibalizer.Process.ProcessTable();

            // Set the containers up with the new tables
            processViewTablePanel.Controls.Add(table);
            processViewInvalidKitsPanel.Controls.Add(invalid);
            processViewValidKitsPanel.Controls.Add(valid);

            totalTransfers += cannibalizer.AdhocTransfers.Count;

            totalTransfersTextBox.Text = totalTransfers.ToString();
            
            iterationsTextBox.Text = iterations.ToString();

            if(cannibalizer.Process.PrimaryKit == null)
            {
                primaryKitTextBox.Text = "None";
            }
            else
            {
                primaryKitTextBox.Text = cannibalizer.Process.PrimaryKit.ToString();
            }

            // Resume layouts
            processViewTablePanel.ResumeLayout();
            processViewKitDetailsSplitContainer.ResumeLayout();

        }

        /// <summary>
        /// Checks to see if any kits need to be broken down
        /// </summary>
        private void checkForBreakdowns()
        {
            // Store kits to breakdown here
            List<Kit> kits = new List<Kit>();

            // Iterate through all the invalid kits
            foreach(Kit k in cannibalizer.InvalidKits)
            {
                k.isValid();
                // Check to see if the kit is less than the threshold
                if(!Utils.DetermineBreakdown(k) || k.ComponentQty <= 1)
                {
                    kits.Add(k);
                }
            }

            // See if anything was added to the list
            if(!(kits.Count > 0))
            {
                return;
            }
            else if (kits.Count == 1)
            {
                // Ask the user if they want to break any kits down
                string message = "There is 1 kit that eligable for breakdowns. Would you like to break them down?";

                DialogResult result = MessageBox.Show(message, "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }
                else
                {
                    buildBreakoutView(new LinkedList<Kit>(kits));
                }

            }
            else
            {
                // Ask the user if they want to break any kits down
                int count = kits.Count;
                string message = string.Format("There are {0} kits that eligable for breakdowns. Would you like to break them down?", 
                    count, (Constants.BREAKDOWN_THRESHOLD * 100));

                DialogResult result = MessageBox.Show(message, "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(result == DialogResult.No)
                {
                    return;
                }
                else
                {
                    buildBreakoutView(new LinkedList<Kit>(kits));
                }
            }
        }

        /// <summary>
        /// Create a new tab for breaking down 
        /// remaining kits that are elidgable to be borken down
        /// </summary>
        /// <param name="kits"></param>
        void buildBreakoutView(LinkedList<Kit> kits)
        {
            // make sure no kits are empty
            foreach(Kit k in kits)
            {
                if(k.ComponentQty == 0 || k.Components.Count == 0)
                {
                    string message = string.Format("{0} is empty. Adhoc this kit to NEW KIT ASSEMBLY-0-0 or INVALID KITS-0-0", k.ToString());
                    MessageBox.Show(message, "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    continue;
                }
            }

            // Create a new tabcontrol
            TabControl tbc = new TabControl();

            tbc.Dock = DockStyle.Fill;

            // Create a kitbreakdown builder
            KitBreakDownBuilder kbb = new KitBreakDownBuilder(kits, search);

            // Build the DataGridView Tables
            kbb.BuildTables();

            // Create a new tab for each table
            foreach (DataGridView table in kbb.KitBreakdownTables)
            {
                // Add each table to their new tab
                TabPage tbpg = new TabPage(table.Name);
                tbpg.Controls.Add(table);
                tbc.TabPages.Add(tbpg);
            }


            TabPage kbPage = new TabPage("Process Breakdowns");
            kbPage.Controls.Add(tbc);

            processViewTabControl.TabPages.Add(kbPage);

        }
    }
}

