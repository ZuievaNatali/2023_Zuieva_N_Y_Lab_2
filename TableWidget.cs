using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Gtk;

namespace Lab2
{
    public class TableWidget : Grid
    {
        private List<Label> columnLabels;
        private List<string> columnNames;
        public List<List<Entry>> entryRows;
        public int columns;

        private const int columnSpacing = 1;
        private const int rowSpacing = 1;

        public delegate void OnRowSelectedHandler(int row);
        public event OnRowSelectedHandler OnRowSelected;

        public delegate void OnTableModifiedHandler(int row, int column);
        public event OnTableModifiedHandler OnTableModified;

        public int Rows => entryRows.Count;

        public TableWidget(int columns) : base()
        {
            this.columnLabels = new List<Label>();
            this.entryRows = new List<List<Entry>>();
            this.columns = columns;
            this.ColumnSpacing = columnSpacing;
            this.RowSpacing = rowSpacing;
        }

        public void Clear()
        {
            Widget[] children = this.Children;

            foreach (Widget child in children)
            {
                this.Remove(child);
            }

            this.entryRows.Clear();
            this.columnLabels.Clear();
        }

        public void SetColumnLabels(List<string> columnNames)
        {
            this.columnNames = columnNames;
            for (int i = 0; i < columnNames.Count; i++)
            {
                var label = new Label(columnNames[i]);
                this.Attach(label, left: i, top: 0, width: 1, height: 1);
            }
        }

        public void RemoveRow(int index)
        {
            foreach (var entry in entryRows[index])
            {
                this.Remove(entry);
            }
            entryRows.RemoveAt(index);
            this.ShowAll();
            Redraw();
        }

        public void Redraw()
        {
            var data = GetData();
            Clear();
            SetColumnLabels(this.columnNames);
            foreach (var rowData in data)
            {
                AddRow(rowData);
            }
            this.ShowAll();
        }

        public void AddRow()
        {
            List<string> stringList = new List<string>();
            for (int i = 0; i < columns; i++)
            {
                stringList.Add("");
            }
            AddRow(stringList);
        }


        public void AddRow(List<string> values)
        {
            List<Entry> entryRow = new List<Entry>();
            for (int j = 0; j < values.Count; j++)
            {
                var row = Rows + 1;
                var entry = new Entry(values[j]);
                entry.FocusInEvent += (sender, e) => OnRowSelected?.Invoke(row - 1);
                entry.FocusInEvent += (sender, e) => Console.WriteLine(row - 1);
                entry.Changed += (sender, e) => OnTableModified?.Invoke(row - 1, j);
                this.Attach(entry, left: j, top: row, width: 1, height: 1);
                entryRow.Add(entry);
                entry.ShowAll();
            }
            entryRows.Add(entryRow);
        }
        
        public List<List<string>> GetData()
        {
            var data = new List<List<string>>();
            foreach (var row in entryRows)
            {
                var rowData = new List<string>();
                foreach (var entry in row)
                {
                    rowData.Add(entry.Text);
                }
                data.Add(rowData);
            }
            return data;
        }
    }
}
