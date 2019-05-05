using System.Collections.Generic;
using Xwray.Groupie;

namespace Sample
{
    public class ListSection : Section
    {
        public void Update(IList<IGroup> items)
        {
            SetHeader(new ListItem("header"));
            AddAll(items);
            SetFooter(new ListItem("footer"));
        }
    }
}