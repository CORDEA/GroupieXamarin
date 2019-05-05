using Android.Views;
using Android.Widget;
using Java.Lang;
using Xwray.Groupie;

namespace Sample
{
    public class ExpandableHeaderItem : Item, IExpandableItem, View.IOnClickListener
    {
        private ExpandableGroup _onToggleListener;
        private readonly string _title;

        public ExpandableHeaderItem(string title)
        {
            _title = title;
        }

        public override int Layout => Resource.Layout.expandable_header_item;

        public override void Bind(Object holder, int position)
        {
            var viewHolder = (ViewHolder) holder;
            viewHolder.Root.SetOnClickListener(this);
            var title = viewHolder.Root.FindViewById<TextView>(Resource.Id.title);
            title.Text = _title;
        }

        public void SetExpandableGroup(ExpandableGroup onToggleListener)
        {
            _onToggleListener = onToggleListener;
        }

        public void OnClick(View v)
        {
            _onToggleListener.OnToggleExpanded();
        }
    }
}