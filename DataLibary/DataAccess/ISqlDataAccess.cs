using System.Collections.Generic;

namespace DataLibary.DataAccess
{
    public interface ISqlDataAccess
    {
        int CheckData<T>(string sql, T data);
        string GetConnectionString();
        List<T> LoadData<T>(string sql);
        T LoadData<T>(string sql, T data);
        int SaveData<T>(string sql, T data);
    }
}