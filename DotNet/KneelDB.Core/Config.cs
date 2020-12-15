using KneelDB.Core.Enums;

namespace KneelDB.Core
{
    public static class Config
    {
        static Config()
        {
            BasePath = @"../../../Storage";
            DefaultDatabaseName = "Default";
            DefaultTableName = "Default";
            QueryOptionNewDatabase = QueryOptionNewDatabase.Add;
            QueryOptionNoDatabase = QueryOptionNoDatabase.UseDefault;
            QueryOptionNewTable = QueryOptionNewTable.Add;
            QueryOptionNoTable = QueryOptionNoTable.UseDefault;
            QueryOptionNewColumns = QueryOptionNewColumns.Ignore;
        }

        public static string BasePath { get; set; }
        public static string DefaultDatabaseName { get; set;}
        public static string DefaultTableName { get; set; }
        public static QueryOptionNewDatabase QueryOptionNewDatabase { get; set; }
        public static QueryOptionNoDatabase QueryOptionNoDatabase { get; set; }
        public static QueryOptionNewTable QueryOptionNewTable { get; set; }
        public static QueryOptionNoTable QueryOptionNoTable { get; set; }
        public static QueryOptionNewColumns QueryOptionNewColumns { get; set; }
    }
}