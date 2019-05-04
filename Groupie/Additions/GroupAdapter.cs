using Android.Support.V7.Widget;
using Android.Views;

namespace Xwray.Groupie
{
    public partial class GroupAdapter
    {
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            // Do nothing here because original source does nothing.
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            return (RecyclerView.ViewHolder) InternalCreateViewHolder(parent, viewType);
        }
    }
}