namespace KneelDB.Core
{
    public static class Config 
    {
        static Config() 
        {
            BasePath = @"../Storage";
            AutoIdName = "Id";
        }

        public static string BasePath { get; set; }
        public static string AutoIdName { get; set; }
    }
}