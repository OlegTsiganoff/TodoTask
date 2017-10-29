using System;
using System.Collections.Generic;
using System.Linq;
using MvvmCross.Platform;
using TodoTask.Core.Interfaces;
using TodoTask.Core.Model;

namespace TodoTask.Core.ViewModels.Helpers
{
    public class Repository
    {
        public IList<T> GetItemsForDatePeriod<T>(DateTime startDateTime, DateTime endDateTime) where T : TodoItem, new ()
        {
            var connection = Mvx.Resolve<ISQLite>().GetConnection();
            var items = connection.Table<T>().Where(x => x.DateTime > startDateTime && x.DateTime < endDateTime);
            return items.ToList();
        }

        public void SaveTodoItem<T>(T item) where T : TodoItem, new()
        {
            var connection = Mvx.Resolve<ISQLite>().GetConnection();
            if (item.Id <= 0)
                connection.Insert(item);
            else
            {
                connection.Update(item);
            }
        }

        public T GetTodoItem<T>(int id) where T : TodoItem, new()
        {
            var connection = Mvx.Resolve<ISQLite>().GetConnection();
            var table = connection.Table<T>();
            return table.FirstOrDefault(x => x.Id == id);
        }
    }
}
