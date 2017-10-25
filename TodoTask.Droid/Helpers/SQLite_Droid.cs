using TodoTask.Core.Interfaces;
using SQLite;
// ReSharper disable InconsistentNaming

namespace TodoTask.Droid.Helpers
{
    public class SQLite_Droid : ISQLite
    {
        const string SqliteFilename = "database.db3";
        static SQLiteConnection _connection;

        public SQLite_Droid()
        {
            
        }
        public SQLiteConnection GetConnection()
        {
            if(_connection == null)
            {
                string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
                var path = System.IO.Path.Combine(documentsPath, SqliteFilename);
                // Create the connection
                _connection = new SQLite.SQLiteConnection(path);
            }
            // Return the database connection
            return _connection;
        }

        public bool IsDBFileExists()
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = System.IO.Path.Combine(documentsPath, SqliteFilename);
            var file = new Java.IO.File(path);
            return file.Exists();
        }
    }
}