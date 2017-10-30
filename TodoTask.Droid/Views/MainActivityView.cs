using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
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
    }
}