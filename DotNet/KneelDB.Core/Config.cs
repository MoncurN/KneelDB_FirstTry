namespace KneelDB.Core
{
    public static class Config 
    {
        static Config() 
        {
            BasePath = @"../../Storage";
            ClusteredIdName = "Id";
        }

        public static string BasePath { get; set; }
        public static string ClusteredIdName { get; set; }
    }
}