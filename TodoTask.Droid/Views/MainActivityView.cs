using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.Widget;
using TodoTask.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace TodoTask.Droid.Views
{
    [Activity(
        Label = "Main Activity",
        Theme = "@style/AppTheme",
        LaunchMode = LaunchMode.SingleTop
    )]
    public class MainActivityView : MvxAppCompatActivity<MainViewModel>
    {
        public DrawerLayout DrawerLayout;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainActivityView);

            DrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            if(bundle == null)
                ViewModel.ShowMenu();
        }
    }
}