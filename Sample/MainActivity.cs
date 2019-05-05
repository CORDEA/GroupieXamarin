using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Xwray.Groupie;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Sample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IOnItemClickListener, IOnItemLongClickListener
    {
        private readonly GroupAdapter _groupAdapter = new GroupAdapter();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            _groupAdapter.Add(new ListItem("title"));
            var group = new ExpandableGroup(new ExpandableHeaderItem("expandable item"));
            group.Add(new ExpandableContentItem("description"));
            group.Add(new ExpandableContentItem("description"));
            _groupAdapter.Add(group);
            var childItems = new List<IGroup>
            {
                new CarouselChildItem("carousel1"),
                new CarouselChildItem("carousel2"),
                new CarouselChildItem("carousel3"),
            };
            var carousel = new CarouselItem("carousel", childItems);
            _groupAdapter.Add(carousel);
            var section = new ListSection();
            section.Update(new List<IGroup>
            {
                new ListItem("section1"),
                new ListItem("section2")
            });
            _groupAdapter.Add(section);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.recycler_view);
            var manager = new GridLayoutManager(this, _groupAdapter.SpanCount);
            manager.SetSpanSizeLookup(_groupAdapter.SpanSizeLookup);
            recyclerView.SetLayoutManager(manager);
            recyclerView.SetAdapter(_groupAdapter);
            _groupAdapter.SetOnItemClickListener(this);
            _groupAdapter.SetOnItemLongClickListener(this);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener) null).Show();
        }

        public void OnItemClick(Item item, View view)
        {
            Toast.MakeText(this, "Clicked", ToastLength.Short).Show();
        }

        public bool OnItemLongClick(Item item, View view)
        {
            Toast.MakeText(this, "Long clicked", ToastLength.Short).Show();
            return true;
        }
    }
}