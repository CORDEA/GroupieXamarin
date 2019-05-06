# GroupieXamarin

Xamarin bindings library for the [groupie](https://github.com/lisawray/groupie) library.

> Groupie is a simple, flexible library for complex RecyclerView layouts.

**Currently this library supports only groupie 2.1.0** because groupie 2.2.0 or later has been migrated to AndroidX but task to migrate Xamarin.Android bindings to AndroidX seems to be in progress. So, I can not binding latest library yet because package name does not match. (If you know how to bind, please let me know.)

## Usage

```cs
class ListItem : Item
{
    private readonly string _title;

    public ListItem(string title)
    {
        _title = title;
    }

    public override void Bind(Object holder, int position)
    {
        var viewHolder = (ViewHolder) holder;
        var title = viewHolder.Root.FindViewById<TextView>(Resource.Id.title);
        title.Text = _title;
    }

    public override int Layout => Resource.Layout.list_item;
}
```

```cs
var adapter = new GroupAdapter();
adapter.Add(new ListItem("1"));

var recyclerView = FindViewById<RecyclerView>(Resource.Id.recycler_view);
recyclerView.SetLayoutManager(new LinearLayoutManager(this));
recyclerView.SetAdapter(adapter);
```

If you want more examples, you can refer [Sample](https://github.com/CORDEA/GroupieXamarin/tree/master/Sample) and [groupie's example](https://github.com/lisawray/groupie/tree/2.1.0/example).
