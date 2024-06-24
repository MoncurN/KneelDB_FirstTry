namespace KneelDB.Library;

public interface IDatabase
{
    int Insert(string table, Dictionary<string, string> fields);
}
