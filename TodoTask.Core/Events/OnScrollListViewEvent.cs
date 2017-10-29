using MvvmCross.Plugins.Messenger;

namespace TodoTask.Core.Events
{
    public class OnScrollListViewEvent : MvxMessage
    {
        public int FirstVisibleItem { get; set; }
        public int VisibleItemCount { get; set; }
        public int TotalItemCount { get; set; }

        public OnScrollListViewEvent(object sender) : base(sender) { }
    }
}
