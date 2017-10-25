using System;
using Android.Content;
using TodoTask.Core.Interfaces;
using MvvmCross.Platform.Platform;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using TodoTask.Droid.Helpers;

namespace TodoTask.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
            
        }

        protected override IMvxApplication CreateApp()
        {
            Register();
            return new Core.App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
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