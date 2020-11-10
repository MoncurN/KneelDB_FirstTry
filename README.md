# KneelDB
## API
Method|Description
-|-
int Insert(string dbName, string tableName, Record record)|Inserts the given record into the specified database / table
int Insert(string tableName, Record record)|Inserts the given record into the specified table in the "Default" database
int Insert(Record record)|Inserts the given record into the "Default" table of the "Default" database
