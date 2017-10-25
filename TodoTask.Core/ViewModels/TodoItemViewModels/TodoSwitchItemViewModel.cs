﻿using TodoTask.Core.ViewModels.TodoItemViewModels;

namespace TodoTask.Core.ViewModels.TodoItemViewModels
{
    public class TodoSwitchItemViewModel : TodoItemViewModelBase
    {
        private bool _finished;
        public bool Finished
        {
            get { return _finished; }
            set { SetProperty(ref _finished, value); }
        }
    }
}
