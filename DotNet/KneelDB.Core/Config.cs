namespace KneelDB.Core
{
    public static class Config 
    {
        static Config() 
        {
            BasePath = @"../Storage";
        }

        public static string BasePath { get; set; }
    }
}