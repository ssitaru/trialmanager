using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;	
using System.Windows.Forms;

namespace TranslationManagerCommon
{
    public class ListViewItemComparer : System.Collections.IComparer
    {
        public SortOrder Order { get; set; }

        public ListViewItemComparer()
	    {
            Order = SortOrder.None;
	    }

	    public int Compare(object oa, object ob)
	    {
		    ListViewItem a = (ListViewItem)oa, b = (ListViewItem)ob;

            int ia = int.Parse(a.SubItems[0].Text);
            int ib = int.Parse(b.SubItems[0].Text);

            if (Order == SortOrder.Descending)
		    {
                return ia.CompareTo(ib);
		    }
            else if (Order == SortOrder.Ascending)
		    {
                return ib.CompareTo(ia);
		    }
		    else
		    {
			    return 0;
		    }
	    }
    }
}
