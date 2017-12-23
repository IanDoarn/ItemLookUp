using ItemLookUp.Config;
using ItemLookUp.Tools.Exceptions;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace ItemLookUp.DataBase
{
    public class OracleDB : IDatabaseConnection
    {
        private OracleConnection connection = null;
        private OracleConfig oracleConfig;
        private string ConnectionString;
        private bool isConnected = false;

        public OracleConnection ConnectionObj { get { return connection; } set { this.connection = value; } }

        public bool IsConnected() { return isConnected; }

        public OracleDB(OracleConfig oracleConfig)
        {
            this.oracleConfig = oracleConfig;
            this.ConnectionString = this.oracleConfig.ConnectionString();
            connection = new OracleConnection(ConnectionString);
        }

        public void OpenConnection()
        {
            try
            {
                connection.Open();
                isConnected = true;
            }
            catch (OracleException ex)
            {
                string message = string.Format("{0}. ERROR CODE [{1}]", ex.Message, ex.ErrorCode);
                throw ErrorHandler.Throw(ErrorType.NO_CONNECTION, message);
            }
            catch (Exception ex)
            {
                throw ErrorHandler.Throw(ErrorType.NO_CONNECTION, ex.Message);
            }

        }

        public void CloseConnection()
        {
            try
            {
                connection.Close();
                isConnected = false;
            }
            catch (OracleException ex)
            {
                string message = string.Format("{0}. ERROR CODE [{1}]", ex.Message, ex.ErrorCode);
                throw ErrorHandler.Throw(ErrorType.NO_CONNECTION, message);
            }
            catch (Exception ex)
            {
                throw ErrorHandler.Throw(ErrorType.DEFAULT, ex.Message);
            }
        }

        public bool TestConnection()
        {
            // Close connection incase it is already open
            if (isConnected)
            {
                CloseConnection();
            }

            // Test connection
            try
            {
                OpenConnection();
                CloseConnection();
                return true;
            }
            catch (OracleException ex)
            {
                string message = string.Format("{0}. ERROR CODE [{1}]", ex.Message, ex.ErrorCode);
                throw ErrorHandler.Throw(ErrorType.NO_CONNECTION, message);
            }
            catch (Exception ex)
            {
                throw ErrorHandler.Throw(ErrorType.NO_CONNECTION, ex.Message);
            }
        }

        public DataTable execute(string query, bool ensureReturn)
        {
            if (!isConnected)
            {
                throw ErrorHandler.Throw(ErrorType.NO_CONNECTION, "No connection to the database is currently made.");
            }

            try
            {
                DataTable dt = new DataTable();

                OracleCommand cmd = new OracleCommand(query);

                cmd.CommandType = CommandType.Text;

                cmd.Connection = connection;

                using (OracleDataAdapter adapter = new OracleDataAdapter())
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);
                }

                if (ensureReturn)
                {
                    if (dt.Rows.Count > 0)
                    {
                        return dt;
                    }

                    throw ErrorHandler.Throw(ErrorType.NO_DATA_RETURNED_FROM_QUERY, string.Format("QUERY: [{0}]", query));
                }
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        return dt;
                    }

                    return null;
                }
            }
            catch(OracleException ex)
            {
                string message = string.Format("{0}. ERROR CODE [{1}]", ex.Message, ex.ErrorCode);
                throw ErrorHandler.Throw(ErrorType.DATABASE_ERROR, message);
            }
            catch (Exception ex)
            {
                throw ErrorHandler.Throw(ErrorType.DATABASE_ERROR, ex.Message);
            }
        }

    }
}
