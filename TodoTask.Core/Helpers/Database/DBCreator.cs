using System;
using MvvmCross.Platform;
using SQLite;
using TodoTask.Core.Interfaces;
using TodoTask.Core.Model;

// ReSharper disable InconsistentNaming

namespace TodoTask.Core.Helpers.Database
{
    public class DBCreator
    {

        public void FillDatabaseIfNeed()
        {
            if(!Settings.IsDatabaseFilled)
            {
                var connection = Mvx.Resolve<ISQLite>().GetConnection();
                DropTables(connection);
                CreateTables(connection);
                FillTodoTextItem(connection);
                FillTodoProgressItem(connection);
                FillTodoSwitchItem(connection);
                Settings.IsDatabaseFilled = true;
            }
        }

        private void CreateTables(SQLiteConnection connection)
        {
            connection.CreateTable<TodoTextItem>();
            connection.CreateTable<TodoProgressItem>();
            connection.CreateTable<TodoSwitchItem>();
        }

        private void DropTables(SQLiteConnection connection)
        {
            connection.DropTable<TodoTextItem>();
            connection.DropTable<TodoProgressItem>();
            connection.DropTable<TodoSwitchItem>();
        }

        //public bool IsDatabaseExists()
        //{
        //    var db = Mvx.Resolve<ISQLite>();
        //    return db.IsDBFileExists();
        //}

       

        private void FillTodoTextItem(SQLiteConnection connection)
        {
            var random = new Random();
            for (int i = 0; i < 100; i++)
            {
                var date = DateTime.Now;
                date = date.AddDays(i - 50);

                var todoItem = new TodoTextItem()
                {
                    Name = "Text Todo №" + (i + 1),
                    DateTime = date,
                    Text = i + " She suspicion dejection saw instantly. Well deny may real one told yet saw hard dear."
                };
                connection.Insert(todoItem);
            }
        }

        private void FillTodoProgressItem(SQLiteConnection connection)
        {
            var random = new Random();
            for(int i = 0; i < 100; i++)
            {
                var date = DateTime.Now.AddHours(2);
                date = date.AddDays(i - 50);

                var todoItem = new TodoProgressItem()
                {
                    Name = "Progress Todo №" + (i + 1),
                    DateTime = date,
                    Progress = random.Next(0, 100)
                };
                connection.Insert(todoItem);
            }
        }

        private void FillTodoSwitchItem(SQLiteConnection connection)
        {
            var random = new Random();
            for(int i = 0; i < 100; i++)
            {
                var date = DateTime.Now.AddHours(-2);
                date = date.AddDays(i - 50);

                var todoItem = new TodoSwitchItem()
                {
                    Name = "Switch Todo №" + (i + 1),
                    DateTime = date,
                    IsSwitched = random.Next(0, 1) == 1
                };
                connection.Insert(todoItem);
            }
        }
    }
}
