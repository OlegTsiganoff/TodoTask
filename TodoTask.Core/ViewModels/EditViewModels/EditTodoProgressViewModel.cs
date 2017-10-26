using TodoTask.Core.Model;
using TodoTask.Core.ViewModels.Helpers;
using TodoTask.Core.ViewModels.TodoItemViewModels;

namespace TodoTask.Core.ViewModels.EditViewModels
{
    public class EditTodoProgressViewModel : EditTodoViewModelBase
    {
        public void Init(int id)
        {
            if(id > -1)
            {
                var item = new Repository().GetTodoItem<TodoProgressItem>(id);
                ViewModel = new TodoProgressItemViewMode(item);
            }
            else
            {
                ViewModel = new TodoProgressItemViewMode();
            }
        }
    }
}
