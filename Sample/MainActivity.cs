using System;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Xwray.Groupie;

namespace Sample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private GroupAdapter _groupAdapter = new GroupAdapter();

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
            var recyclerView = FindViewById<RecyclerView>(Resource.Id.recycler_view);
            var manager = new GridLayoutManager(this, _groupAdapter.SpanCount);
            manager.SetSpanSizeLookup(_groupAdapter.SpanSizeLookup);
            recyclerView.SetLayoutManager(manager);
            recyclerView.SetAdapter(_groupAdapter);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener) null).Show();
        }
    }
}