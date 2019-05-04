using System;
using Android.Widget;
using Xwray.Groupie;
using Object = Java.Lang.Object;

namespace Sample
{
    public class CarouselChildItem : Item
    {
        private readonly string _title;

        public CarouselChildItem(string title)
        {
            _title = title;
        }

        public override int Layout => Resource.Layout.carousel_child_item;

        public override void Bind(Object p0, int p1)
        {
            var viewHolder = (ViewHolder) p0;
            var title = viewHolder.Root.FindViewById<TextView>(Resource.Id.title);
            title.Text = _title;
        }
    }
}