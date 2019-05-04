using System;
using Android.Widget;
using Xwray.Groupie;
using Object = Java.Lang.Object;

namespace Sample
{
    public class ExpandableContentItem : Item
    {
        private readonly string _description;

        public ExpandableContentItem(string description)
        {
            _description = description;
        }

        public override int Layout => Resource.Layout.expandable_content_item;

        public override void Bind(Object p0, int p1)
        {
            var viewHolder = (ViewHolder) p0;
            var description = viewHolder.Root.FindViewById<TextView>(Resource.Id.description);
            description.Text = _description;
        }
    }
}