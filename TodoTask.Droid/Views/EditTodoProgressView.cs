using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace TodoTask.Droid.Views
{
    [Activity(ScreenOrientation = ScreenOrientation.Sensor)]
    public class EditTodoProgressView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.TodoProgressEditView);
        }
    }
}