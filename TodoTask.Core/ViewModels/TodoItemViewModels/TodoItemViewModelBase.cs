using System;
using MvvmCross.Core.ViewModels;
using TodoTask.Core.Model;

namespace TodoTask.Core.ViewModels.TodoItemViewModels
{
    public abstract class TodoItemViewModelBase : MvxViewModel, IComparable<TodoItemViewModelBase>
    {
        protected TodoItemViewModelBase() { }

        protected TodoItemViewModelBase(TodoItem item)
        {
            Id = item.Id;
            Name = item.Name;
            DateTime = item.DateTime;
            Finished = item.Finished;
        }

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

        private bool _finished;
        public bool Finished
        {
            get { return _finished; }
            set { SetProperty(ref _finished, value); }
        }

        public int CompareTo(TodoItemViewModelBase other)
        {
            return this.DateTime.CompareTo(other.DateTime);
        }
    }
}
