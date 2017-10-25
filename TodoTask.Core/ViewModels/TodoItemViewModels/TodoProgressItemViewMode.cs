using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoTask.Core.ViewModels.TodoItemViewModels;

namespace ApiExamples.Core.ViewModels.TodoItemViewModels
{
    public class TodoProgressItemViewMode : TodoItemViewModelBase
    {
        private const int MinValue = 0;
        private const int MaxValue = 100;

        private int _progress;
        public int Progress
        {
            get { return _progress; }
            set { SetProperty(ref _progress, value); }
        }
    }
}
