using DataLibary.DataAccess;
using DataLibary.Models;
using System.Collections.Generic;

namespace DataLibary.BusinessLogic
{
    public static class ExampleProcessor
    {
        public static int CreateExample(int id, string firstName, string lastName)
        {
            ExampleModel data = new ExampleModel {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            };

            string sql = @"insert into dbo.Examples (ID, FirstName, LastName)
                           values (@Id, @FirstName, @LastName)";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<ExampleModel> LoadExamples()
        {
            string sql = @"select ID, FirstName, LastName
                           from dbo.Examples";
            return SqlDataAccess.LoadData<ExampleModel>(sql);
        }
    }
}
