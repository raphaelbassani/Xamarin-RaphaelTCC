using SQLite;

namespace TODOList.Interface
{
    public interface IDatabase
    {
        SQLiteConnection GetConnection();
    }
}
