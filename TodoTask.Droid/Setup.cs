using System;
using System.Collections.Generic;
using System.Reflection;
using Acr.UserDialogs;
using Android.Content;
using TodoTask.Core.Interfaces;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
//using MvvmCross.Droid.Shared.Presenter;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using TodoTask.Core.ViewModels;
using TodoTask.Droid.Helpers;

namespace TodoTask.Droid
{
    public class Setup : MvxAndroidSetup
    {

        protected override IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly>(base.AndroidViewAssemblies)
        {
            typeof(Android.Support.Design.Widget.NavigationView).Assembly,
            typeof(Android.Support.V7.Widget.Toolbar).Assembly,
            typeof(Android.Support.V4.Widget.DrawerLayout).Assembly
        };


        public Setup(Context applicationContext) : base(applicationContext)
        {
            
        }

        protected override IMvxApplication CreateApp()
        {
            Register();
            return new Core.App();
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            UserDialogs.Init(() => Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity);
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            return new MvxAppCompatViewPresenter(AndroidViewAssemblies);
            //Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(mvxFragmentsPresenter);

            ////add a presentation hint handler to listen for pop to root
            //mvxFragmentsPresenter.AddPresentationHintHandler<MyMvxPresentationHint>(hint =>
            //{
            //    var activity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
            //    var fragmentActivity = activity as Android.Support.V4.App.FragmentActivity;

            //    if (fragmentActivity != null)
            //    {
            //        for (int i = 0; i < fragmentActivity.SupportFragmentManager.BackStackEntryCount; i++)
            //        {
            //            fragmentActivity.SupportFragmentManager.PopBackStack();
            //        }
            //    }
            //    return true;
            //});
            ////register the presentation hint to pop to root
            ////picked up in the third view model
            //Mvx.RegisterSingleton<MvxPresentationHint>(() => new MyMvxPresentationHint());
            //return mvxFragmentsPresenter;
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
            
        }

        void Register()
        {
            try
            {
                Mvx.RegisterType<ISQLite, SQLite_Droid>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Register Exception: " + ex.Message);
            }
            
        }
    }
}