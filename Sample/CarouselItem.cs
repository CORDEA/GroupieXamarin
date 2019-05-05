using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Widget;
using Java.Lang;
using Xwray.Groupie;

namespace Sample
{
    public class CarouselItem : Item
    {
        private readonly GroupAdapter _groupAdapter = new GroupAdapter();
        private readonly string _title;
        private readonly IList<IGroup> _childItems;

        public CarouselItem(string title, IList<IGroup> childItems)
        {
            _title = title;
            _childItems = childItems;
        }

        public override int Layout => Resource.Layout.carousel_item;

        public override void Bind(Object holder, int position)
        {
            var viewHolder = (ViewHolder) holder;
            var title = viewHolder.Root.FindViewById<TextView>(Resource.Id.title);
            title.Text = _title;
            var recyclerView = viewHolder.Root.FindViewById<RecyclerView>(Resource.Id.recycler_view);
            recyclerView.SetLayoutManager(new LinearLayoutManager(viewHolder.Root.Context, LinearLayoutManager.Horizontal, false));
            recyclerView.SetAdapter(_groupAdapter);
            _groupAdapter.Clear();
            _groupAdapter.AddAll(_childItems);
        }
    }
}