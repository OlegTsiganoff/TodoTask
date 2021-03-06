using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace TodoTask.Droid
{
    [Activity(
		Label = "TodoTask.Droid"
		, MainLauncher = true
		, Icon = "@drawable/icon"
		, Theme = "@style/Theme.Splash"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Sensor)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}