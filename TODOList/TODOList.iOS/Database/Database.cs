using SQLite;
using System.IO;
using TODOList.Interface;
using TODOList.iOS.Database;

[assembly: Xamarin.Forms.Dependency(typeof(Database))]
namespace TODOList.iOS.Database

{
    public class Database : IDatabase
    {
        public SQLiteConnection GetConnection()
        {
            var nameDB = "TodoList.db3";
            var specialFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var libraryFolder = Path.Combine(specialFolder, "...", "Libray");
            var directoryName = Path.Combine(libraryFolder, nameDB);

            return new SQLiteConnection(directoryName);
        }
    }
}