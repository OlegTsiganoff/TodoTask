using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace TodoTask.Droid.Views
{
    [Activity(ScreenOrientation = ScreenOrientation.Sensor)]
    public class EditTodoTextView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.TodoTextEditView);

        }
    }
}