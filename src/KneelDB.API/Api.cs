using KneelDB.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KneelDB.API
{
    public class Api : IApi
    {
        private readonly IDatabase database;
        
        public Api (IDatabase database) 
        {
            this.database = database; 
        }

        public void Delete(string table, int kneelId)
        {
            throw new NotImplementedException();
        }

        public int Insert<T>(string table, T record)
        {
            var fields = new Dictionary<string, string>();
            var type = record.GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                fields.Add(property.Name, property.GetValue(record)?.ToString() ?? "");
            }
            database.Insert(table, fields);

            throw new NotImplementedException();
        }

        public T Select<T>(string table)
        {
            throw new NotImplementedException();
        }

        public T Select<T>(string table, int kneelId)
        {
            throw new NotImplementedException();
        }

        public void Update<T>(string table, T record)
        {
            throw new NotImplementedException();
        }

        public void Update<T>(string table, int kneelId, T record)
        {
            throw new NotImplementedException();
        }
    }
}
