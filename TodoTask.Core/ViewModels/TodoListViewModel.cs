using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using TodoTask.Core.Events;
using TodoTask.Core.Model;
using TodoTask.Core.ViewModels.EditViewModels;
using TodoTask.Core.ViewModels.Helpers;
using TodoTask.Core.ViewModels.TodoItemViewModels;

namespace TodoTask.Core.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {
        private readonly Repository _repository;
        private DateTime _startDate;
        private DateTime _endDate;
        private readonly MvxSubscriptionToken _token;

        private ObservableCollection<TodoItemViewModelBase> _items;
        public ObservableCollection<TodoItemViewModelBase> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }

        private IMvxCommand _navigateToDetailCommand;
        public IMvxCommand NavigateToDetailCommand
        {
            get { return _navigateToDetailCommand; }
            set { SetProperty(ref _navigateToDetailCommand, value); }
        }

        private IMvxCommand _addCommand;
        public IMvxCommand AddCommand
        {
            get { return _addCommand; }
            set { SetProperty(ref _addCommand, value); }
        }

        public IMvxCommand GetPreviousCommand { get; private set; }


        public TodoListViewModel()
        {
            var messanger = Mvx.Resolve<IMvxMessenger>();
            _token = messanger.Subscribe<OnScrollListViewEvent>(OnScrollListViewEventDeliveryAction);
            AppearingCommand = new MvxCommand(AppearingExecute);
            DisappearingCommand = new MvxCommand(DisappearingExecute);
            BackCommand = new MvxCommand(BackExecute);
            AddCommand = new MvxCommand(AddCommandExecute);
            GetPreviousCommand = new MvxAsyncCommand(GetPreviousExecute);
            NavigateToDetailCommand = new MvxCommand<TodoItemViewModelBase>(item =>
            {
                if(item is TodoTextItemViewModel)
                    ShowViewModel<EditTodoTextViewModel>(item);
            });
            _repository = new Repository();
            
        }

        private void OnScrollListViewEventDeliveryAction(OnScrollListViewEvent e)
        {
            if(e.TotalItemCount == 0) return;
            if (e.FirstVisibleItem + e.VisibleItemCount == e.TotalItemCount)
            {
                LoadFartherMore();
            }
        }

        private async void LoadFartherMore()
        {
            await Task.Run(() =>
            {
                IsRefreshing = true;
                var startDate = _endDate;
                _endDate = _endDate.AddDays(7);
                var items = GetSortedItemList(startDate, _endDate);
                AddItemsToTheEnd(items);
                IsRefreshing = false;
            });
        }

        private async Task GetPreviousExecute()
        {
            await Task.Run(() =>
            {
                IsRefreshing = true;
                var endDate = _startDate;
                _startDate = _startDate.AddDays(-7);
                var items = GetSortedItemList(_startDate, endDate);
                AddItemsToTheBeginning(items);
                IsRefreshing = false;
            });
        }


        private void AddCommandExecute()
        {
            var dialog = Mvx.Resolve<IUserDialogs>();
            var config = new ActionSheetConfig {Cancel = new ActionSheetOption("Cancel")};
            config.Add("Text", () => { ShowViewModel<EditTodoTextViewModel>(new { id = -1 }); });
            config.Add("Switch", () => { ShowViewModel<EditTodoSwitchViewModel>(new { id = -1 }); });
            config.Add("Progress", () => { ShowViewModel<EditTodoProgressViewModel>(new { id = -1 }); });
            dialog.ActionSheet(config);
        }

        private async void AppearingExecute()
        {
            await Task.Run(() =>
            {
                FillListItems();
            });
        }

        private void DisappearingExecute()
        {

        }

        private void BackExecute()
        {
        }

        void FillListItems()
        {
            try
            {
                _startDate = DateTime.Now.AddDays(-7);
                _endDate = DateTime.Now.AddDays(7);
                var list = GetSortedItemList(_startDate, _endDate);
                Items = new ObservableCollection<TodoItemViewModelBase>(list);
            }
            catch (Exception e)
            {
                Debug.WriteLine("FillListItems Exception: " + e.Message);
            }
        }

        private List<TodoItemViewModelBase> GetSortedItemList(DateTime startDateTime, DateTime endDateTime)
        {
            List<TodoItemViewModelBase> list = new List<TodoItemViewModelBase>();
            list.AddRange(_repository.GetItemsForDatePeriod<TodoTextItem>(startDateTime, endDateTime)
                .Select(x => new TodoTextItemViewModel(x)));
            list.AddRange(_repository.GetItemsForDatePeriod<TodoProgressItem>(startDateTime, endDateTime)
                .Select(x => new TodoProgressItemViewMode(x)));
            list.AddRange(_repository.GetItemsForDatePeriod<TodoSwitchItem>(startDateTime, endDateTime)
                .Select(x => new TodoSwitchItemViewModel(x)));
            list.Sort();
            return list;
        }

        private void AddItemsToTheBeginning(IList<TodoItemViewModelBase> items)
        {
            if(items == null) return;
            
            for (int i = items.Count - 1; i >= 0; i--)
            {
                Items.Insert(0, items[i]);
            }
        }

        private void AddItemsToTheEnd(IList<TodoItemViewModelBase> items)
        {
            if(items == null) return;
            
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
    }
}
