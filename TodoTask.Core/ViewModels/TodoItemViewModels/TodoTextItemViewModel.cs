using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoTask.Core.Model;
using TodoTask.Core.ViewModels.Helpers;

namespace TodoTask.Core.ViewModels.TodoItemViewModels
{
    public class TodoTextItemViewModel : TodoItemViewModelBase
    {
        public TodoTextItemViewModel()
        {
            Item = new TodoTextItem() {DateTime = DateTime.Now};
        }

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

        public  override void Save()
        {
            base.Save();
            ((TodoTextItem) Item).Text = Text;
            new Repository().SaveTodoItem((TodoTextItem)Item);
        }
    }
}
