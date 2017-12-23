using System;
using System.Windows.Forms;
using System.Threading;
using ItemLookUp.Forms;
using ItemLookUp.Config;
using ItemLookUp.DataBase;
using ItemLookUp.Tools.Exceptions;

namespace ItemLookUp
{
    /// <summary>
    /// Main entry point of the program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main window of the program
        /// </summary>
        static MainWindow mainWindow;

        /// <summary>
        /// Main Postgres database object
        /// </summary>
        private static Postgres postgres;

        /// <summary>
        /// Main OracleDB database object
        /// </summary>
        private static OracleDB oracle;

        /// <summary>
        /// Main Application method
        /// </summary>
        [STAThread]
        static void Main()
        {   
            /* Load settings */
              
            // Load Postgres and Oracle connections
            postgres = new Postgres(LoadPostgresConfig());
            oracle = new OracleDB(LoadOracleConfig());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Check to see if we run connection checks

            if(Properties.Settings.Default.AUTOCONNECT)
            {
                // Load the splash screen and Show it as the connection is being tested
                SplashScreen splash = new SplashScreen();
                splash.Show();

                // Test Connection to Databases before fully running the application
                Thread t = new Thread(new ThreadStart(TestDatabaseConnections));
                t.Start();
                t.Join();

                // connect to databases
                connect();

                splash.Close();
            }

            // Load main window form, initialize database connections
            mainWindow = new MainWindow(
                postgres, oracle
            );

            // Run main application
            Application.Run(mainWindow);

            // Disconnect from databases
            disconnect();
        }

        /// <summary>
        /// Load postgres settings
        /// </summary>
        /// <returns>PostgresConfig object</returns>
        private static PostgresConfig LoadPostgresConfig()
        {

            return new PostgresConfig(
                Properties.Settings.Default.POSTGRES_HOST,
                Properties.Settings.Default.POSTGRES_DATABASE,
                Properties.Settings.Default.POSTGRES_PORT,
                Properties.Settings.Default.POSTGRES_USERNAME,
                Properties.Settings.Default.POSTGRES_PASSWORD
            );
        }
        
        /// <summary>
        /// Load oracle settings
        /// </summary>
        /// <returns>OracleConfig object</returns>
        private static OracleConfig LoadOracleConfig()
        {
            return new OracleConfig(
                Properties.Settings.Default.ORACLE_HOST,
                Properties.Settings.Default.ORACLE_SID,
                Properties.Settings.Default.ORACLE_PORT,
                Properties.Settings.Default.ORACLE_USERNAME,
                Properties.Settings.Default.ORACLE_PASSWORD
            );

        }

        /// <summary>
        /// Test for connection to the database
        /// </summary>
        private static void TestDatabaseConnections()
        {   
            try
            {
                // Test postgres
                postgres.TestConnection();

                // Test Oracle
                oracle.TestConnection();
            }
            catch (ConnectionError c)
            {
                // Could not connect, display message and close program
                MessageBox.Show("Unable to connect to database: " + c.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Force the application to close
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Open connections to databases
        /// </summary>
        static void connect()
        {
            postgres.OpenConnection();
            oracle.OpenConnection();
        }

        /// <summary>
        /// Close connections to databases
        /// </summary>
        static void disconnect()
        {
            if(postgres.IsConnected())
                postgres.CloseConnection();
            if(oracle.IsConnected())
                oracle.CloseConnection();
        }
    }
}
