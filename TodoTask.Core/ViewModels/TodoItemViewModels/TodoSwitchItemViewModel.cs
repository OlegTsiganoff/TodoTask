using TodoTask.Core.ViewModels.TodoItemViewModels;

namespace TodoTask.Core.ViewModels.TodoItemViewModels
{
    public class TodoSwitchItemViewModel : TodoItemViewModelBase
    {
        private bool _isSwitched;
        public bool IsSwitched
        {
            get { return _isSwitched; }
            set { SetProperty(ref _isSwitched, value); }
        }
    }
}
