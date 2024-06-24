using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KneelDB.API
{
    public interface IApi
    {
        int Insert<T>(string table, T record);

        T Select<T>(string table);

        T Select<T>(string table, int kneelId);

        void Update<T>(string table, T record);

        void Update<T>(string table, int kneelId, T record);

        void Delete(string table, int kneelId);
    }
}
