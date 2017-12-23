using System.Windows.Forms;

namespace ItemLookUp.Forms
{
    /// <summary>
    /// SplashScreen class
    /// Displayed before the main application is loaded so that the user
    /// can visual see the progress of the application as it loads
    /// </summary>
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();

            this.Focus();
        }
    }
}
