using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using TodoTask.Core.ViewModels.TodoItemViewModels;

namespace TodoTask.Core.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {

        private IList<TodoItemViewModelBase> _items;
        public IList<TodoItemViewModelBase> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public TodoListViewModel()
        {
            AppearingCommand = new MvxAsyncCommand(AppearingExecute);
            DisappearingCommand = new MvxCommand(DisappearingExecute);
            BackCommand = new MvxCommand(BackExecute);
        }
        private async Task AppearingExecute()
        {
            await Task.Run(() =>
            {

            });
        }
        private void DisappearingExecute()
        {

        }

        private void BackExecute()
        {
        }


    }
}
