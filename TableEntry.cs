using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gtk;

namespace Lab2
{
    public class TableEntry : Entry
    {
        public int rowIndex;
        public TableEntry(string initialText, int rowIndex) : base(initialText)
        {
            this.rowIndex = rowIndex;
        }
    }
}
