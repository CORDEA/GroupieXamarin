using Android.Views;
using Android.Widget;
using Java.Lang;
using Xwray.Groupie;

namespace Sample
{
    public class ExpandableHeaderItem : Item, IExpandableItem, View.IOnClickListener
    {
        private ExpandableGroup _expandableGroup;
        private readonly string _title;

        public ExpandableHeaderItem(string title)
        {
            _title = title;
        }

        public override int Layout => Resource.Layout.expandable_header_item;

        public override void Bind(Object p0, int p1)
        {
            var viewHolder = (ViewHolder) p0;
            viewHolder.Root.SetOnClickListener(this);
            var title = viewHolder.Root.FindViewById<TextView>(Resource.Id.title);
            title.Text = _title;
        }

        public void SetExpandableGroup(ExpandableGroup p0)
        {
            _expandableGroup = p0;
        }

        public void OnClick(View v)
        {
            _expandableGroup.OnToggleExpanded();
        }
    }
}