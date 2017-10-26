using System;
using TodoTask.Core.Model;
using TodoTask.Core.ViewModels.Helpers;
using TodoTask.Core.ViewModels.TodoItemViewModels;

namespace TodoTask.Core.ViewModels.TodoItemViewModels
{
    public class TodoSwitchItemViewModel : TodoItemViewModelBase
    {
        public TodoSwitchItemViewModel()
        {
            Item = new TodoSwitchItem() { DateTime = DateTime.Now };
        }

        public TodoSwitchItemViewModel(TodoSwitchItem item) : base(item)
        {
            IsSwitched = item.IsSwitched;
        }

        private bool _isSwitched;
        public bool IsSwitched
        {
            get { return _isSwitched; }
            set { SetProperty(ref _isSwitched, value); }
        }

        public override void Save()
        {
            base.Save();
            ((TodoSwitchItem)Item).IsSwitched = IsSwitched;
            new Repository().SaveTodoItem((TodoSwitchItem)Item);
        }
    }
}
