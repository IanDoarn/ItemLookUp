﻿using ItemLookUp.Config;
using ItemLookUp.Tools.Exceptions;
using Npgsql;
using System;
using System.Data;

namespace ItemLookUp.DataBase 
{
    public class Postgres : IDatabaseConnection
    {
        private NpgsqlConnection connection = null;
        private string ConnectionString;
        private PostgresConfig postgresConfig;
        private bool isConnected = false;

        public NpgsqlConnection ConnectionObj { get { return connection; } set { this.connection = value; } }

        public bool IsConnected() { return isConnected; }

        public Postgres(PostgresConfig postgresConfig)
        {
            this.postgresConfig = postgresConfig;
            ConnectionString = postgresConfig.ConnectionString();
            connection = new NpgsqlConnection(ConnectionString);
        }

        public void OpenConnection()
        {
            try
            {
                connection.Open();
                isConnected = true;
            }
            catch (NpgsqlException ex)
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
            catch (NpgsqlException ex)
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
            catch (NpgsqlException ex)
            {
                string message = string.Format("{0}. ERROR CODE [{1}]", ex.Message, ex.ErrorCode);
                throw ErrorHandler.Throw(ErrorType.NO_CONNECTION, message);
            }
            catch (Exception ex)
            {
                throw ErrorHandler.Throw(ErrorType.NO_CONNECTION, ex.Message);
            }
        }

        public DataTable execute(string query, bool ensureReturn = false)
        {
            if (!isConnected)
            {
                throw ErrorHandler.Throw(ErrorType.NO_CONNECTION, "No connection to the database is currently made.");
            }

            try
            {
                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                command.Dispose();

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

            catch (NpgsqlException ex)
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
