namespace KneelDB.Library;

public class Database : IDatabase
{
    private Dictionary<string, ITable>? Tables;

    public int Insert(string table, Dictionary<string, string> fields)
    {
        throw new NotImplementedException();
    }
}
