using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Views;
using TodoTask.Core.ViewModels;
using TodoTask.Core.ViewModels.TodoItemViewModels;

namespace TodoTask.Droid.Views
{
    [Activity(ScreenOrientation = ScreenOrientation.Sensor)]
    public class TodoListView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.TodoListView);
            var list = FindViewById<MvxListView>(Resource.Id.listView);
            list.Adapter = new CustomAdapter(this, (IMvxAndroidBindingContext)BindingContext);
            
        }

        protected override void OnResume()
        {
            base.OnResume();
            var viewModel = ViewModel as TodoListViewModel;
            viewModel?.AppearingCommand?.Execute(null);
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

            protected override View GetBindableView(View convertView, object dataContext, int templateId)
            {
                if(dataContext is TodoTextItemViewModel)
                    templateId = Resource.Layout.TodoItem_Text;
                else if(dataContext is TodoProgressItemViewMode)
                    templateId = Resource.Layout.TodoItem_Progress;
                else
                {
                    templateId = Resource.Layout.TodoItem_Switch;
                }

                return base.GetBindableView(convertView, dataContext, templateId);
            }
        }
    }
}