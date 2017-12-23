using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ItemLookUp.Barcodes;
using ItemLookUp.DataBase;
using ItemLookUp.LookUp;
using ItemLookUp.LookUp.Inventory;
using ItemLookUp.Tools;
using ItemLookUp.Tools.Exceptions;
using System.Data;
using ItemLookUp.Tools.Exceptions.Errors;

namespace ItemLookUp.Forms.UserControls
{
    /// <summary>
    /// Control to show the cannibalization process
    /// </summary>
    public partial class CannibalizationControl : UserControl
    {
        /// <summary>
        /// Postgres object
        /// </summary>
        private Postgres postgres;
       
        /// <summary>
        /// OracleDB object
        /// </summary>
        private OracleDB oracle;
        
        /// <summary>
        /// Kit cannibalizer
        /// </summary>
        private Cannibalizer<Kit> cannibalizer;

        /// <summary>
        /// Barcode parsing objetc
        /// </summary>
        private BarcodeParser barcodeParser;
        
        /// <summary>
        /// Database search object
        /// </summary>
        private Search search;

        /// <summary>
        /// Current Collection of kits
        /// </summary>
        private List<Kit> kitQueueList = new List<Kit>();

        /// <summary>
        /// Current kit number loaded into the cannibalizer
        /// </summary>
        private string currentKitNumber = "";

        /// <summary>
        /// Create a new cannibalization control
        /// </summary>
        /// <param name="postgres">Postgres object</param>
        /// <param name="oracle">Oracle object</param>
        public CannibalizationControl(Postgres postgres, OracleDB oracle, Search search, BarcodeParser barcodeParser)
        {
            this.postgres = postgres;
            this.oracle = oracle;
            this.barcodeParser = barcodeParser;
            this.search = search;

            InitializeComponent();

            // Set control specific settings
            kitQueuePanel.AutoScroll = true;

            // Event Handlers
            this.cannibalizeSearchButton.Click += new EventHandler(this.cannibalizeSearchButton_Click);
            this.cannibalizeResetButton.Click += new EventHandler(this.cannibalizeResetButton_Click);
            this.kitQueueTable.CellContentClick += new DataGridViewCellEventHandler(this.kitQueueTable_CellContentClick);
        }

        /// <summary>
        /// Checks if the current kit number loaded
        /// is the same as the one being added
        /// </summary>
        /// <param name="newKit">kit number being added</param>
        /// <returns>bool</returns>
        private bool checkKitNumber(string newKit)
        {
            return (newKit.Equals(currentKitNumber));
        }

        /// <summary>
        /// Check to see if specific kit is in the current inventory snapshot
        /// </summary>
        /// <param name="kit_number"></param>
        private void checkInventory(string kit_number)
        {
            // Check that the current kit exists in the inventory snapshot
            if (!search.CheckInInventory(kit_number, true))
            {
                DialogResult r = MessageBox.Show(
                    "Could not find " + kit_number + " in current inventory snapshot, would you like to manually add the kit?",
                    "Inventory Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    MessageBox.Show("Manual addition of kits has not yet been added!", "Sorry!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    // User said No
                    return;
                }
            }
        }

        /// <summary>
        /// Check to see if the given kit is in the queue
        /// </summary>
        /// <param name="check"></param>
        private bool checkInQueue(Kit check)
        {
            foreach(Kit k in kitQueueList)
            {
                if (k.SerialNumber.Equals(check.SerialNumber))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Update the kit queue header
        /// </summary>
        private void updateKitQueueDetails()
        {
            kitQueueDetailsCount.Text = kitQueueList.Count.ToString();
            kitQueueDetailsKitNumber.Text = currentKitNumber;
        }

        /// <summary>
        /// Search for given kit number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cannibalizeSearchButton_Click(object sender, EventArgs e)
        {
            buildCannibalizationKitQueue(cannibalizeKitNimber.Text);
        }

        /// <summary>
        /// Populate the kit queue
        /// </summary>
        /// <param name="kit_number">Kit number to search for</param>
        private void buildCannibalizationKitQueue(string kit_number)
        {
            // Check to see if the queue has items in it
            if(!(kitQueueList.Count < 1))
            {
                // Prompt user informing them that the current queue will be removed
                DialogResult result = MessageBox.Show("The current queue is not empty, this will clear the queue. Any scanned barcodes will need to be rescanned. Press ok to continue.",
                    "Alert!", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

                if(result == DialogResult.Cancel)
                {
                    return;
                }
            }

            // clear current queue
            kitQueueTable.Rows.Clear();

            // Clear kitQueueList
            kitQueueList.Clear();

            // Check for kit in inventroy snapshot
            checkInventory(kit_number);

            // Search for kits via kit number
            Queue<string> kitsQueue = search.SearchByKitNumber(kit_number);
            PriorityQueue<Kit> kpq = new PriorityQueue<Kit>();

            currentKitNumber = ((Kit)search.search(kitsQueue.Peek())).ProductNumber;

            // Only one kit available for cannibalization
            if(kitsQueue.Count <= 1)
            {
                MessageBox.Show("Not enough kits to cannibalize", "Cannibalization Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Kit k = (Kit) search.search(kitsQueue).ElementAt(0);
                kitQueueList.Add(k);
                AddKitQueueRow(kitQueueTable, true, k.ProductNumber, k.SerialNumber);
                return;
            }

            // Put results into priority queue to sort them
            foreach (Product p in search.search(kitsQueue))
            {
                Kit k = (Kit)p;
                kpq.enqueue(k);
            }

            // Add items to the table
            while (!kpq.isEmpty())
            {
                Kit k = kpq.dequeue();

                if (!checkKitNumber(k.ProductNumber))
                {
                    MessageBox.Show(k.ToString() + " is not the same as other kits in the queue and has been removed",
                        "Queue Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (!checkInQueue(k))
                {
                    kitQueueList.Add(k);

                    // Args => [DataGridView, CheckBox State, Product Number, Serial Number]
                    AddKitQueueRow(kitQueueTable, false, k.ProductNumber, k.SerialNumber);
                }
                else
                {
                    MessageBox.Show(k.ToString() + " is already in the queue", "Hey!",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }

            updateKitQueueDetails();
        }

        /// <summary>
        /// Add a row to the current visual kit queue
        /// </summary>
        /// <param name="panel">TableLayoutPanel control</param>
        /// <param name="args">Info to be added to the table</param>
        private void AddKitQueueRow(DataGridView panel, params object[] args)
        {
            panel.Rows.Add(args);
        }

        /// <summary>
        /// Remove all rows from DataGridView and the cannibalization process view
        /// and empty the kitQueueList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cannibalizeResetButton_Click(object sender, EventArgs e)
        {
            kitQueueTable.Rows.Clear();
            canniblizerMainPanel.Controls.Clear();
            kitQueueList.Clear();
            currentKitNumber = "";
            updateKitQueueDetails();
        }
    
        /// <summary>
        /// Handles the event of clicking the 'details' button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kitQueueTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            // Determine if the the click was on the button
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Get the location of the cell
                int col = e.ColumnIndex - 1;
                int row = e.RowIndex;

                // Get the kits serial number
                string serial = senderGrid.Rows[row].Cells[col].Value.ToString();

                // Find the kit in the kitQueueList via its serial number
                foreach (Kit k in kitQueueList)
                {
                    if (k.SerialNumber.Equals(serial))
                    { 
                        // Create a kit viewer and show it
                        createKitViewer(k);
                    }
                }
            }
        }

        /// <summary>
        /// Creates a kit viewer to view the specific details of the selected kit
        /// </summary>
        /// <param name="k"></param>
        private void createKitViewer(Kit k)
        {
            Form kitViewerContainer = new Form();
            KitViewer kv = new KitViewer(k);

            // Set properties of container
            kitViewerContainer.Text = k.ToString();
            kitViewerContainer.ShowIcon = false;

            // Make sure the container form cannot be resized
            kitViewerContainer.MaximumSize = kv.MaximumSize;
            kitViewerContainer.MinimumSize = kv.MinimumSize;
            kitViewerContainer.MaximizeBox = false;
            kitViewerContainer.MinimizeBox = false;

            // Make sure Kitviewer fills its parent container
            kv.Dock = DockStyle.Fill;

            // Add usercontrol to parent container
            kitViewerContainer.Controls.Add(kv);

            // Show the control
            kitViewerContainer.Show();
        }

        /// <summary>
        /// Populates the process view for the cannibalization process
        /// </summary>
        private void buildProcessView(LinkedList<Kit> kitsToCannibalize)
        {
            // Create cannibalizer
            cannibalizer = new Cannibalizer<Kit>(kitsToCannibalize);

            // Load cannibalizer into new CannibalizationProcessView Control
            CannibalizerProcessView cpv = new CannibalizerProcessView(cannibalizer, search);

            // Set control to fill its parent container
            cpv.Dock = DockStyle.Fill;

            // Remove any existing controls
            canniblizerMainPanel.Controls.Clear();

            // Add process view to the panel
            canniblizerMainPanel.Controls.Add(cpv);
        }

        /// <summary>
        /// Runs cannibalization process from current selection of kits in the queue.
        /// Only kits with the check box selected are run
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cannibalizeButton_Click(object sender, EventArgs e)
        {
            // Make sure there are kits currently loaded
            if (kitQueueList == null || kitQueueList.Count == 0)
            {
                MessageBox.Show("No kits loaded for cannibalization.", "Queue Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (kitQueueList.Count == 1)
            {
                // Kits are loaded but there is only one
                MessageBox.Show("Only one kit available for cannibalization", "Cannibalization Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                
                LinkedList<Kit> kitLL = new LinkedList<Kit>();

                // Iterate thorugh each kit in the table and only use the ones with there checkbox enabled
                foreach (DataGridViewRow row in kitQueueTable.Rows)
                {
                    DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (!(bool)cell.Value)
                    {
                        string kit = row.Cells[1].Value.ToString();
                        string serial = row.Cells[2].Value.ToString();

                        foreach(Kit k in kitQueueList)
                        {
                            if(k.SerialNumber == serial && k.ProductNumber == kit)
                            {
                                kitLL.AddLast(k);
                            }
                        }
                    }
                }

                // Create build process
                buildProcessView(kitLL);
            }                
        }

        /// <summary>
        /// Create a dialog that prompts the user to enter something
        /// </summary>
        /// <returns></returns>
        private string getuserinput()
        {
            string text = "Scan or enter kit barcodes seperated by a ';'";

            // Create a new ScanInput form
            using (var f = new ScanInput(text))
            {
                var result = f.ShowDialog();

                if (!(result == DialogResult.OK))
                {
                    // User canceled or closed the dialog
                    return null;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(f.Input) || string.IsNullOrEmpty(f.Input))
                    {
                        MessageBox.Show("You didn't enter anything!", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return null;
                    }

                    return f.Input;
                }
            }
        }

        /// <summary>
        /// Search for kits via barcodes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cannibalizeSearchByBarcode_Click(object sender, EventArgs e)
        {
            // get the users input
            string barcode = getuserinput();

            // user did not enter anything
            if (barcode == null)
                return;

            List<string> issues = new List<string>();

            // barcodes returned by getuserinput() are concatentated by a ;
            // so we split on that just incase we have multiple barcodes
            foreach (string b in barcode.Split(';'))
            {
                // ignore the string if it is null or whitespace
                if (!(string.IsNullOrWhiteSpace(b) | string.IsNullOrEmpty(b)))
                {
                    try
                    {
                        addByBarcode(b);
                    }
                    catch (ItemLookUpException qError)
                    {
                        issues.Add(b);
                    }

                }
            }

            // check to see if there was an issue with any barcodes
            if(issues.Count > 0)
            {
                MessageBox.Show("There was an issue with " + issues.Count + " items you scanned", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                foreach(string b in issues)
                {
                    DialogResult r = MessageBox.Show(
                    "Could not find " + b + " in current inventory snapshot, would you like to manually add the kit?",
                    "Inventory Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (r == DialogResult.Yes)
                    {
                        // MessageBox.Show("Manual addition of kits has not yet been added!", "Sorry!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Kit nk = BuildKit(b);

                        if (nk == null) // user decided to not add it or closed the window
                            continue;
                        else
                        {
                            kitQueueList.Add(nk);

                            // Args => [DataGridView, CheckBox State, Product Number, Serial Number]
                            AddKitQueueRow(kitQueueTable, false, nk.ProductNumber, nk.SerialNumber);

                            continue;
                        }
                    }
                    else
                    {
                        // User canceled
                        continue;
                    }
                }
            }

            updateKitQueueDetails();
        }

        /// <summary>
        /// Build a new kit object with given info
        /// </summary>
        /// <returns></returns>
        private Kit BuildKit(string barcode)
        {
            LinkedList<Component> components = new LinkedList<Component>();
            SQLBuilder sql = new SQLBuilder();

            string[] barcodeData = Utils.SplitKitBarcode(barcode);

            // Get the kit number from the product id
            DataTable kitData = search.SearchByProductId(barcodeData[0]);

            string kitnumber = kitData.Rows[0][0].ToString();
            string description = kitData.Rows[0][1].ToString();

            // Get components and their standards for the kit
            sql.add("SELECT DISTINCT");
            sql.add("component_product_number, component_description, component_quantity_in_kit_std");
            sql.add("FROM doarni.southaven_kit_data");
            sql.add("WHERE");
            sql.add(string.Format("kit_product_number = '{0}'", kitnumber));

            DataTable dt = postgres.execute(sql.build(), true);

            int total_components_std = 0;

            // Iterate the data table returned from postgres
            foreach(DataRow row in dt.Rows)
            {
                string component_product_number = row[0].ToString();
                string component_description = row[1].ToString();
                int component_standard = int.Parse(row[2].ToString());
                int component_qty = 0;

                total_components_std += component_standard;

                // Add new component to the list
                components.AddLast(new Component(
                    component_product_number,
                    component_description,
                    kitnumber,
                    component_standard,
                    component_qty
                    ));
            }

            using(var kb = new KitBuilder(kitnumber, barcodeData[1], barcodeData[0], description, total_components_std, components))
            {
                var result = kb.ShowDialog();

                if (!(result == DialogResult.OK))
                {
                    // User canceled or closed the dialog
                    return null;
                }
                else
                {
                    // Get input from user
                    return kb.NewKit;
                }
            }
        }
    
        /// <summary>
        /// Add kit to the queue via barcode number
        /// </summary>
        /// <param name="barcode"></param>
        private void addByBarcode(string barcode)
        {
            Kit k = (Kit)search.search("", barcodeParser.parse(barcode));

            // Check to see if a currentKitNumber is set
            if (currentKitNumber.Equals(""))
            {
                // update current kit number
                currentKitNumber = k.ProductNumber;

                if (!checkInQueue(k))
                {
                    kitQueueList.Add(k);

                    // Args => [DataGridView, CheckBox State, Product Number, Serial Number]
                    AddKitQueueRow(kitQueueTable, false, k.ProductNumber, k.SerialNumber);
                }
                else
                {
                    MessageBox.Show(k.ToString() + " is already in the queue", "Hey!",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                // Make sure the kits we are adding are the same as others in the queue
                if (!checkKitNumber(k.ProductNumber))
                {
                    MessageBox.Show(k.ToString() + " is not the same as other kits in the queue and will not be added",
                        "Queue Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!checkInQueue(k))
                    {
                        kitQueueList.Add(k);

                        // Args => [DataGridView, CheckBox State, Product Number, Serial Number]
                        AddKitQueueRow(kitQueueTable, false, k.ProductNumber, k.SerialNumber);
                    }
                    else
                    {
                        MessageBox.Show(k.ToString() + " is already in the queue", "Hey!",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
        }
        
        /// <summary>
        /// Search for given kit number, called when Enter Key is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cannibalizeKitNimber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only register event when Enter key is pressed
            if(e.KeyChar == (char)13)
            {
                string s = cannibalizeKitNimber.Text;

                if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
                {
                    MessageBox.Show("You didn't enter anything!", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    buildCannibalizationKitQueue(cannibalizeKitNimber.Text);
                }
            }
        }
        
        /// <summary>
        /// Remove rows where the check box is seleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cannibalizeRemoveButton_Click_1(object sender, EventArgs e)
        {
            // I have to fucking do this to remove cells, wtf
            kitQueueTable.ClearSelection();

            foreach (DataGridViewRow row in kitQueueTable.Rows)
            {
                //DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                //if ((bool)cell.Value)
                if ((bool)row.Cells[0].Value)
                {
                    string kit = row.Cells[1].Value.ToString();
                    string serial = row.Cells[2].Value.ToString();

                    for (int i = 0; i < kitQueueList.Count; i++)
                    {
                        Kit k = kitQueueList[i];
                        if (k.SerialNumber == serial && k.ProductNumber == kit)
                        {
                            row.Cells[0].Selected = false;
                            kitQueueTable.Rows.Remove(row);
                            kitQueueList.RemoveAt(kitQueueList.IndexOf(k));
                        }
                    }
                }
            }

            updateKitQueueDetails();
        }
    }
}
