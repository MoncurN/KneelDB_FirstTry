namespace KneelDB.Core {
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
                DatabaseName = "Default";
            }

            if (String.IsNullOrWhiteSpace(TableName))
            {
                TableName = "Default";
            }
        }
    }
}