using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using TodoTask.Core.ViewModels;
//using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Views.Attributes;

namespace TodoTask.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.navigation_frame)]
    [Register("TodoTask.Droid.Views.MenuFragment")]
    public class MenuFragment : MvxFragment<MainMenuViewModel>, NavigationView.IOnNavigationItemSelectedListener
    {
        private NavigationView _navigationView;
        private IMenuItem _previousMenuItem;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.NavigationViewFragment, null);

            _navigationView = view.FindViewById<NavigationView>(Resource.Id.navigation_view);
            _navigationView.SetNavigationItemSelectedListener(this);
            _navigationView.Menu.FindItem(Resource.Id.nav_home).SetChecked(true);

            return view;
        }

        public bool OnNavigationItemSelected(IMenuItem menuItem)
        {
            if(menuItem != _previousMenuItem)
            {
                _previousMenuItem?.SetChecked(false);
            }

            menuItem.SetCheckable(true);
            menuItem.SetChecked(true);

            _previousMenuItem = menuItem;

            Navigate(menuItem.ItemId);

            return true;
        }

        private async Task Navigate(int itemId)
        {
            ((MainActivityView)Activity).DrawerLayout.CloseDrawers();

            // add a small delay to prevent any UI issues
            await Task.Delay(TimeSpan.FromMilliseconds(250));

            switch(itemId)
            {
                case Resource.Id.nav_home:
                    ViewModel.ShowTodoListCommand.Execute();
                    break;
                case Resource.Id.nav_settings:
                    ViewModel.ShowSettingCommand.Execute();
                    break;
            }
        }
    }
}