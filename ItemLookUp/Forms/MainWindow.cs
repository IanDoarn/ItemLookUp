using System;
using System.Windows.Forms;
using ItemLookUp.Forms.UserControls;
using ItemLookUp.DataBase;
using ItemLookUp.LookUp;
using ItemLookUp.Tools;
using ItemLookUp.Barcodes;

namespace ItemLookUp.Forms
{
    /// <summary>
    /// Main window of the application
    /// </summary>
    public partial class MainWindow : Form
    {
        /* Instance variables */

        /// <summary>
        /// Postgres object
        /// </summary>
        private Postgres postgres;
        /// <summary>
        /// OracleDB object
        /// </summary>
        private OracleDB oracle;

        /// <summary>
        /// Search object
        /// </summary>
        private Search search;

        /// <summary>
        /// Barcode parser object
        /// </summary>
        private BarcodeParser barcodeParser;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="postgres">Postgres database object</param>
        /// <param name="oracle">OracleDB database object</param>
        public MainWindow(Postgres postgres, OracleDB oracle)
        {
            // Instantiate connections
            this.postgres = postgres;
            this.oracle = oracle;

            // Instantiate tools
            barcodeParser = new BarcodeParser(postgres, oracle);
            search = new Search(postgres, oracle, barcodeParser);

            
            CannibalizationControl cc = new CannibalizationControl(this.postgres, this.oracle, this.search, this.barcodeParser);
            cc.Dock = DockStyle.Fill;

            // Initialize Components onto the form
            InitializeComponent();

            //Load controls
            tabCannibalize.Controls.Add(cc);
        }

        /// <summary>
        /// Executes on close button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Execute on menu item selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lookUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            itemLookUp();
        }

        /// <summary>
        /// Opens the item look up tools
        /// </summary>
        private void itemLookUp()
        {
            MessageBox.Show("This feature has not yet been implemented.");
        }

        /// <summary>
        /// Executes on mapping menu selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mappingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            itemMapping();
        }

        /// <summary>
        /// Takes user input and returns the products 
        /// systematically mapped location in the warehouse
        /// </summary>
        private void itemMapping()
        {
           string text = "Enter a kit barcode or kit number to search";

            // Create a new ScanInput form
            using (var f = new ScanInput(text, true, false))
            {
                // Get input from user

                var result = f.ShowDialog();

                if (!(result == DialogResult.OK))
                {
                    // User canceled or closed the dialog                    
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(f.Input) || string.IsNullOrEmpty(f.Input))
                    {
                        MessageBox.Show("You didn't enter anything!", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    string product;

                    // Make sure the input was a barcode
                    // If not, simply take the imput as a product number
                    if (barcodeParser.parseType(f.Input) == BarcodeEnum.UNKNOWN)
                        product = f.Input;
                    else 
                        product = search.SearchByProductId(Utils.SplitKitBarcode(f.Input)[0]).Rows[0][0].ToString();

                    try
                    {
                        string map = search.ItemMapping(f.Input);

                        MessageBox.Show(
                            string.Format("{0} Mapped to: {1}{2}", product, Environment.NewLine, map),
                            "Mapping for " + product, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

        }
    }
}
