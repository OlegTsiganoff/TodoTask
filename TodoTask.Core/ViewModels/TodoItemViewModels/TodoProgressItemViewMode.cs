using System;
using TodoTask.Core.Model;
using TodoTask.Core.ViewModels.Helpers;

namespace TodoTask.Core.ViewModels.TodoItemViewModels
{
    public class TodoProgressItemViewMode : TodoItemViewModelBase
    {
        private const int MinValue = 0;
        private const int MaxValue = 100;

        public TodoProgressItemViewMode()
        {
            Item = new TodoProgressItem() { DateTime = DateTime.Now };
        }
        public TodoProgressItemViewMode(TodoProgressItem item) : base(item)
        {
            Progress = item.Progress;
        }

        private int _progress;
        public int Progress
        {
            get { return _progress; }
            set
            {
                int val = value;
                if (val < MinValue) val = MinValue;
                if (val > MaxValue) val = MaxValue;
                SetProperty(ref _progress, val); 
            }
        }

        public override void Save()
        {
            base.Save();
            ((TodoProgressItem)Item).Progress = Progress;
            new Repository().SaveTodoItem((TodoProgressItem)Item);
        }
    }
}
