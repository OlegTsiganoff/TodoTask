using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoTask.Core.Model;

namespace TodoTask.Core.ViewModels.TodoItemViewModels
{
    public class TodoTextItemViewModel : TodoItemViewModelBase
    {
        public TodoTextItemViewModel() { }

        public TodoTextItemViewModel(TodoTextItem item) : base(item)
        {
            Text = item.Text;
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
    }
}
