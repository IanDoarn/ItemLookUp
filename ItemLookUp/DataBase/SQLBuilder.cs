using System.Text;

namespace ItemLookUp.DataBase
{
    /// <summary>
    /// Small wrapper class of StringBuilder to create SQL strings
    /// </summary>
    class SQLBuilder
    {
        /// <summary>
        /// StringBuilder to hold SQL statements and build final string
        /// </summary>
        private StringBuilder builder;

        /// <summary>
        /// SQLBuilder
        /// </summary>
        /// <param name="caplitalize_statements"></param>
        public SQLBuilder(bool caplitalize_statements = true)
        {
            builder = new StringBuilder();
        }

        /// <summary>
        /// Add a string to the SQL statement
        /// </summary>
        /// <param name="statement">string to add</param>
        public void add(string statement)
        {
            builder.Append(statement);
            builder.Append(" ");
        }

        /// <summary>
        /// Build SQL statement
        /// </summary>
        /// <returns>SQL string</returns>
        public string build()
        {
            builder.Append(";");
            return builder.ToString();
        }

        /// <summary>
        /// Clear the SQL string
        /// </summary>
        /// <returns>bool</returns>
        public bool clear()
        {
            builder.Clear();
            return true;
        }
    }
}
