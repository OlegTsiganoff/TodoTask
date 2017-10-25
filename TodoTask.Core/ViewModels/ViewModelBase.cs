using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace TodoTask.Core.ViewModels
{
    public class ViewModelBase : MvxViewModel
    {
        ICommand _appearingCommand;
        public ICommand AppearingCommand
        {
            get { return _appearingCommand; }
            set { SetProperty(ref _appearingCommand, value); }
        }

        ICommand _disappearingCommand;
        public ICommand DisappearingCommand
        {
            get { return _disappearingCommand; }
            set { SetProperty(ref _disappearingCommand, value); }
        }

        ICommand _backCommand;
        public ICommand BackCommand
        {
            get { return _backCommand; }
            set { SetProperty(ref _backCommand, value); }
        }
    }
}
