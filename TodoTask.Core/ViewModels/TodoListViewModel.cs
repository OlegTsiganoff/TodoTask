﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using TodoTask.Core.Model;
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

        private IMvxCommand _addCommand;
        public IMvxCommand AddCommand
        {
            get { return _addCommand; }
            set { SetProperty(ref _addCommand, value); }
        }


        public TodoListViewModel()
        {
            AppearingCommand = new MvxCommand(AppearingExecute);
            DisappearingCommand = new MvxCommand(DisappearingExecute);
            BackCommand = new MvxCommand(BackExecute);
            AddCommand = new MvxCommand(AddCommandExecute);
            _repository = new Repository();
            FillListItems();
        }

        private void AddCommandExecute()
        {
            var dialog = Mvx.Resolve<IUserDialogs>();
            var config = new ActionSheetConfig {Cancel = new ActionSheetOption("Cancel")};
            config.Add("Text", () => { });
            config.Add("Switch", () => { });
            config.Add("Progress", () => { });
            dialog.ActionSheet(config);
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
                    var startDate = DateTime.Now.AddDays(-7);
                    var endDate = DateTime.Now.AddDays(7);
                    List<TodoItemViewModelBase> list = new List<TodoItemViewModelBase>();
                    list.AddRange(_repository.GetNextWeekItems<TodoTextItem>(startDate, endDate).Select(x => new TodoTextItemViewModel(x)));
                    list.AddRange(_repository.GetNextWeekItems<TodoProgressItem>(startDate, endDate).Select(x => new TodoProgressItemViewMode(x)));
                    list.AddRange(_repository.GetNextWeekItems<TodoSwitchItem>(startDate, endDate).Select(x => new TodoSwitchItemViewModel(x)));
                    list.Sort();
                    Items = new ObservableCollection<TodoItemViewModelBase>(list);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("FillListItems Exception: " + e.Message);
                }
            });

        }

       
    }
}
