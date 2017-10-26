using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using TodoTask.Core.ViewModels.TodoItemViewModels;

namespace TodoTask.Core.ViewModels.EditViewModels
{
    public abstract class EditTodoViewModelBase : MvxViewModel
    {

        private TodoItemViewModelBase _viewModel;
        public TodoItemViewModelBase ViewModel
        {
            get { return _viewModel; }
            set { SetProperty(ref _viewModel, value); }
        }


        private IMvxCommand _saveCommand;
        public IMvxCommand SaveCommand
        {
            get { return _saveCommand; }
            set { SetProperty(ref _saveCommand, value); }
        }


        protected EditTodoViewModelBase()
        {
            SaveCommand = new MvxAsyncCommand(SaveExecute);
        }

        private async Task SaveExecute()
        {
            await Task.Run(() =>
            {
                ViewModel.Save();
            });
            Close(this);
        }
    }
}
