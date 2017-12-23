using ItemLookUp.Config;
using System;
using System.Windows.Forms;

namespace ItemLookUp.Forms
{
    /// <summary>
    /// ScanInput
    /// 
    /// Simple form to take the input from user and return it to the calling form
    /// </summary>
    public partial class ScanInput : Form
    {
        /// <summary>
        /// DialogResult to return to the parent form
        /// </summary>
        private DialogResult result;

        /// <summary>
        /// Input given by the user
        /// </summary>
        private string input;

        /// <summary>
        /// Sets the ScanInput to automattically 
        /// delimit concurent inputs on ENTER key press
        /// </summary>
        private bool disableDelimiting = false;

        /// <summary>
        /// Sets the ScanInput to close on enter key press in the input box
        /// </summary>
        private bool closeOnEnter = false;

        /// <summary>
        /// Get value from the input box
        /// </summary>
        public string Input { get { return input; } }

        /// <summary>
        /// Get the DialogResult
        /// </summary>
        public DialogResult Result { get { return result; } }

        /// <summary>
        /// Create a ScanInput Form
        /// </summary>
        public ScanInput()
        {
            AcceptButton = null;
            InitializeComponent();

            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Create a ScanInput
        /// </summary>
        /// <param name="text">Text to display above user input area</param>
        public ScanInput(string text)
        {
            
            InitializeComponent();
            AcceptButton = null;
            label.Text = text;
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;
        }

        public ScanInput(string text, bool disableDelimiting, bool closeOnEnter)
        {
            InitializeComponent();
            if (!closeOnEnter)
                AcceptButton = null;
            label.Text = text;
            this.disableDelimiting = disableDelimiting;
            this.closeOnEnter = closeOnEnter;
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Called when the enter key is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // This is to detect if a barcode scanner is being used.
            // Barcode scanners automatically send a RETURN or ENTER call after scanning
            if (e.KeyChar == (char)13)
            {

                if (!disableDelimiting)
                    textBox.AppendText(Constants.DELIMITER);

                input = textBox.Text;
                result = DialogResult.OK;

            }
        }

        /// <summary>
        /// Called when the Ok button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            input = textBox.Text;
            result = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Called when the Cancel button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            result = DialogResult.Cancel;
            this.Close();
        }
    }
}
