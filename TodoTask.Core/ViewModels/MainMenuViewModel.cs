using MvvmCross.Core.ViewModels;

namespace TodoTask.Core.ViewModels
{
    public class MainMenuViewModel : MvxViewModel
    {
        public IMvxCommand ShowTodoListCommand
        {
            get { return new MvxCommand(ShowTodoExecuted); }
        }

        private void ShowTodoExecuted()
        {
            ShowViewModel<TodoListViewModel>();
        }

        public IMvxCommand ShowSettingCommand
        {
            get { return new MvxCommand(ShowSettingsExecuted); }
        }

        private void ShowSettingsExecuted()
        {
            ShowViewModel<SettingsViewModel>();
        }
    }
}
