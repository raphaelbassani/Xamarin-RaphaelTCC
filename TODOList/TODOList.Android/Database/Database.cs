using SQLite;
using System;
using System.IO;
using TODOList.Droid.Database;
using TODOList.Interface;

[assembly: Xamarin.Forms.Dependency(typeof(Database))]
namespace TODOList.Droid.Database
{
    public class Database : IDatabase
    {
        public SQLiteConnection GetConnection()
        {
            var nameDB = "TodoList.db3";
            var pathDB = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),nameDB);

            return new SQLiteConnection(pathDB);
        }
    }
}