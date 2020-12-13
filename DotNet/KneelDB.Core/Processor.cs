using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KneelDB.Core
{
    public class Processor
    {
        public string TableName { get; set; }
        public string DatabaseName { get; set; }

        public Processor()
        {
            TableName = "Default";
            DatabaseName = "Default";
        }

        public Processor(string tableName)
        {
            TableName = tableName;
            DatabaseName = "Default";
        }

        public Processor(string tableName, string databaseName)
        {
            TableName = tableName;
            DatabaseName = databaseName;
        }

        public int Insert(dynamic values)
        {
            

            throw new NotImplementedException();
        }
    }
}
