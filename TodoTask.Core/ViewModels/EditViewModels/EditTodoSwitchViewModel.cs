using TodoTask.Core.Model;
using TodoTask.Core.ViewModels.Helpers;
using TodoTask.Core.ViewModels.TodoItemViewModels;

namespace TodoTask.Core.ViewModels.EditViewModels
{
    public class EditTodoSwitchViewModel : EditTodoViewModelBase
    {
        public void Init(int id)
        {
            if(id > -1)
            {
                var item = new Repository().GetTodoItem<TodoSwitchItem>(id);
                ViewModel = new TodoSwitchItemViewModel(item);
            }
            else
            {
                ViewModel = new TodoSwitchItemViewModel();
            }
        }
    }
}
