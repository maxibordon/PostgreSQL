using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPostgreSQL
{
    public class PostgreSQLConfiguration
    {
        public PostgreSQLConfiguration(string connectionString) => ConnectionString = connectionString;

        public string ConnectionString { get; set; }

    }
}
