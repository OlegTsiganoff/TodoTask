using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using TodoTask.Core.ViewModels.Helpers;
using TodoTask.Core.ViewModels.TodoItemViewModels;

namespace TodoTask.Core.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {
        private readonly Repository _repository;
        private ObservableCollection<TodoItemViewModelBase> _items;
        public ObservableCollection<TodoItemViewModelBase> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public TodoListViewModel()
        {
            AppearingCommand = new MvxCommand(AppearingExecute);
            DisappearingCommand = new MvxCommand(DisappearingExecute);
            BackCommand = new MvxCommand(BackExecute);
            _repository = new Repository();
            FillListItems();
        }

        private async void AppearingExecute()
        {
            await Task.Run(() =>
            {
                
            });
        }

        private void DisappearingExecute()
        {

        }

        private void BackExecute()
        {
        }

        async void FillListItems()
        {
            await Task.Run(() =>
            {
                try
                {
                    var list = _repository.GetPreviousWeekTextItems(DateTime.Now);
                    list = list.Concat(_repository.GetNextWeekTextItems(DateTime.Now)).ToList();
                    Items = new ObservableCollection<TodoItemViewModelBase>(list
                        .Select(x => new TodoTextItemViewModel()
                        {
                            Id = x.Id,
                            DateTime = x.DateTime,
                            Name = x.Name,
                            Text = x.Text
                        })
                        .ToList());

                }
                catch (Exception e)
                {
                    Debug.WriteLine("FillListItems Exception: " + e.Message);
                }
            });

        }
    }
}
