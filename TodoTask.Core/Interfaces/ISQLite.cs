using SQLite;
// ReSharper disable InconsistentNaming

namespace TodoTask.Core.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
        bool IsDBFileExists();
    }
}
