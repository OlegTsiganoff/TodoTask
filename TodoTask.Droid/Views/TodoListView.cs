using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using TodoTask.Core.Events;
using TodoTask.Core.ViewModels;
using TodoTask.Core.ViewModels.TodoItemViewModels;

namespace TodoTask.Droid.Views
{
    [Activity(ScreenOrientation = ScreenOrientation.Sensor, Theme = "@style/AppTheme")]
    public class TodoListView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            var view = this.BindingInflate(Resource.Layout.TodoRecyclerView, null);
            SetContentView(Resource.Layout.TodoRecyclerView);
            var list = FindViewById<MvxListView>(Resource.Id.listView);
            list.Adapter = new CustomAdapter(this, (IMvxAndroidBindingContext)BindingContext);
            list.SetOnScrollListener(new CustomScrollListener());
        }
      

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            menu.Add("Add");
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var viewModel = ViewModel as TodoListViewModel;
            viewModel?.AddCommand?.Execute(null);
            return base.OnOptionsItemSelected(item);
        }

        public class CustomAdapter : MvxAdapter
        {
            public CustomAdapter(Context context, IMvxAndroidBindingContext bindingContext)
                : base(context, bindingContext)
            {
            }

            public override int GetItemViewType(int position)
            {
                var item = GetRawItem(position);
                if(item is TodoTextItemViewModel)
                    return 0;
                if(item is TodoProgressItemViewMode)
                    return 1;
                return 2;
            }



            public override int ViewTypeCount
            {
                get { return 3; }
            }

            protected override View GetBindableView(View convertView, object dataContext, ViewGroup parent, int templateId)
            {
                if(dataContext is TodoTextItemViewModel)
                    templateId = Resource.Layout.TodoItem_Text;
                else if(dataContext is TodoProgressItemViewMode)
                    templateId = Resource.Layout.TodoItem_Progress;
                else
                {
                    templateId = Resource.Layout.TodoItem_Switch;
                }
                return base.GetBindableView(convertView, dataContext, parent, templateId);
            }
        }

        public class CustomScrollListener : Java.Lang.Object,  AbsListView.IOnScrollListener
        {
            public void OnScroll(AbsListView view, int firstVisibleItem, int visibleItemCount, int totalItemCount)
            {
                var messanger = Mvx.Resolve<IMvxMessenger>();
                messanger.Publish(new OnScrollListViewEvent(this) {FirstVisibleItem = firstVisibleItem, VisibleItemCount = visibleItemCount, TotalItemCount = totalItemCount});
                Debug.WriteLine("OnScroll firstVisibleItem = {0}, visibleItemCount = {1}, totalItemCount = {2}", firstVisibleItem, visibleItemCount, totalItemCount);
            }

            public void OnScrollStateChanged(AbsListView view, ScrollState scrollState)
            {
                Debug.WriteLine("OnScrollStateChanged scrollState = {0}", scrollState);
            }
        }

        public class CustomScrolChangedlListener : Java.Lang.Object, AbsListView.IOnScrollChangeListener
        {
            public void OnScrollChange(View v, int scrollX, int scrollY, int oldScrollX, int oldScrollY)
            {
                //Debug.WriteLine("OnScrollChange scrollState = {0}", scrollState);
            }
        }
    }
}