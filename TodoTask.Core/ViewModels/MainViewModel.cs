using MvvmCross.Core.ViewModels;

namespace TodoTask.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        public IMvxCommand ShowTodoListCommand
        {
            get { return new MvxCommand(ShowTodoListExecuted); }
        }

        public IMvxCommand ShowSettingCommand
        {
            get { return new MvxCommand(ShowSettingsExecuted); }
        }


        public void ShowMenu()
        {
            ShowViewModel<TodoListViewModel>();
            ShowViewModel<MainMenuViewModel>();
        }

        private void ShowTodoListExecuted()
        {
            ShowViewModel<TodoListViewModel>();
        }


        private void ShowSettingsExecuted()
        {
            ShowViewModel<SettingsViewModel>();
        }
    }
}
