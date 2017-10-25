using System;
using MvvmCross.Core.ViewModels;

namespace TodoTask.Core.ViewModels.TodoItemViewModels
{
    public abstract class TodoItemViewModelBase : MvxViewModel
    {
        public int Id { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private DateTime _dateTime;
        public DateTime DateTime
        {
            get { return _dateTime; }
            set { SetProperty(ref _dateTime, value); }
        }
    }
}
