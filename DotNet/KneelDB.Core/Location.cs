using KneelDB.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KneelDB.Core
{
    public class Location
    {
        public string DatabaseName { get; set; }
        public string TableName { get; set; }

        public Location(string dotLocation)
        {
            DatabaseName = "";
            TableName = "";

            if (!String.IsNullOrWhiteSpace(dotLocation))
            {
                var locationParts = dotLocation.Split('.');
                if (locationParts.Length == 1)
                {
                    TableName = locationParts[0];
                }
                else if (locationParts.Length == 2)
                {
                    DatabaseName = locationParts[0];
                    TableName = locationParts[1];
                }
                else if (locationParts.Length > 2)
                {
                    throw new ArgumentException($"\"Into\" can only have 0, 1 or 2 parts.  It can not have more than 2 parts at this time; Schemas and Server Name is not supported at this time in the Into statement.");
                }
                else
                {
                    // This conditional should not occur; provided for completeness
                    throw new NotImplementedException("Error parsing \"Into\" statement; fewer than zero parts.");
                }
            }

            if (String.IsNullOrWhiteSpace(DatabaseName))
            {
                if (Config.QueryOptionNoDatabase == QueryOptionNoDatabase.ThrowException)
                {
                    throw new ArgumentException($"Current Config settings require you to specify a Database Name.  If you would rather just use the Default Database name, please change the Config settings.");
                }
                else if (Config.QueryOptionNoDatabase == QueryOptionNoDatabase.UseDefault)
                {
                    DatabaseName = Config.DefaultDatabaseName;
                }
            }

            if (String.IsNullOrWhiteSpace(TableName))
            {
                if (Config.QueryOptionNoTable == QueryOptionNoTable.ThrowException)
                {
                    throw new ArgumentException($"Current Config settings require you to specify a Table Name.  If you would rather just use the Default Table name, please change the Config settings.");
                }
                else if (Config.QueryOptionNoTable == QueryOptionNoTable.UseDefault)
                {
                    TableName = Config.DefaultTableName;
                }
            }
        }
    }
}
