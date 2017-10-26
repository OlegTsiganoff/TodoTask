using TodoTask.Core.Model;

namespace TodoTask.Core.ViewModels.TodoItemViewModels
{
    public class TodoProgressItemViewMode : TodoItemViewModelBase
    {
        private const int MinValue = 0;
        private const int MaxValue = 100;

        public TodoProgressItemViewMode() { }
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
    }
}
