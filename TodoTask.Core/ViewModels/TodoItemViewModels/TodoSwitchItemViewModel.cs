using TodoTask.Core.Model;
using TodoTask.Core.ViewModels.TodoItemViewModels;

namespace TodoTask.Core.ViewModels.TodoItemViewModels
{
    public class TodoSwitchItemViewModel : TodoItemViewModelBase
    {
        public TodoSwitchItemViewModel() { }

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
    }
}
