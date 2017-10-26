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
        //public IList<TodoTextItem> GetNextWeekTextItems(DateTime startDateTime)
        //{
        //    return GetNextWeekItems<TodoTextItem>(startDateTime);
        //}

        //public IList<TodoProgressItem> GetNextWeekProgressItems(DateTime startDateTime)
        //{
        //    return GetNextWeekItems<TodoProgressItem>(startDateTime);
        //}

        //public IList<TodoSwitchItem> GetNextWeekSwitchItems(DateTime startDateTime)
        //{
        //    return GetNextWeekItems<TodoSwitchItem>(startDateTime);
        //}

        //public IList<TodoTextItem> GetPreviousWeekTextItems(DateTime startDateTime)
        //{
        //    return GetPreviousWeekItems<TodoTextItem>(startDateTime);
        //}

        //public IList<TodoProgressItem> GetPreviousWeekProgressItems(DateTime startDateTime)
        //{
        //    return GetPreviousWeekItems<TodoProgressItem>(startDateTime);
        //}

        //public IList<TodoSwitchItem> GetPreviousWeekSwitchItems(DateTime startDateTime)
        //{
        //    return GetPreviousWeekItems<TodoSwitchItem>(startDateTime);
        //}

        public IList<T> GetNextWeekItems<T>(DateTime startDateTime, DateTime endDateTime) where T : TodoItem, new ()
        {
            var connection = Mvx.Resolve<ISQLite>().GetConnection();
            var items = connection.Table<T>().Where(x => x.DateTime > startDateTime && x.DateTime < endDateTime);
            return items.ToList();
        }

        //private IList<T> GetPreviousWeekItems<T>(DateTime startDateTime) where T : TodoItem, new()
        //{
        //    var connection = Mvx.Resolve<ISQLite>().GetConnection();
        //    var endDate = startDateTime.AddDays(-7);
        //    var items = connection.Table<T>().Where(x => x.DateTime < startDateTime && x.DateTime > endDate);
        //    return items.ToList();
        //}

    }
}
