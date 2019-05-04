using Android.Widget;
using Java.Lang;
using Xwray.Groupie;

namespace Sample
{
    public class ListItem : Item
    {
        private string _title;

        public ListItem(string title)
        {
            _title = title;
        }

        public override int Layout => Resource.Layout.list_item;

        public override void Bind(Object p0, int p1)
        {
            var viewHolder = (ViewHolder) p0;
            var title = viewHolder.Root.FindViewById<TextView>(Resource.Id.title);
            title.Text = _title;
        }
    }
}