using TodoTask.Core.Model;
using TodoTask.Core.ViewModels.Helpers;
using TodoTask.Core.ViewModels.TodoItemViewModels;

namespace TodoTask.Core.ViewModels.EditViewModels
{
    public class EditTodoTextViewModel : EditTodoViewModelBase
    {
        public void Init(int id)
        {
            if (id > -1)
            {
                var item = new Repository().GetTodoItem<TodoTextItem>(id);
                ViewModel = new TodoTextItemViewModel(item);
            }
            else
            {
                ViewModel = new TodoTextItemViewModel();
            }
        }
    }
}
