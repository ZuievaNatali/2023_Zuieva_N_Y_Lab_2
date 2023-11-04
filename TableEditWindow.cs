using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Gtk;
using Lab2.Models;
using System.Data.Entity;

namespace Lab2
{
    public enum EntryType
    {
        IncrementedId,
        NonIncrementedId,
        String
    }

    public class TableEditWindow<T> : VBox where T : class
    {
        public TableWidget table;
        protected List<EntryType> entryTypes;
        protected Button addButton;
        protected Button deleteButton;
        protected Button saveButton;
        protected Context context;
        protected DbSet<T> dbset;
        protected ErrorsWindow errorsWindow;
        protected int incrementedId = 0;
        protected List<string> defaultValues;

        public delegate void OnTableSavedHandler();
        public event OnTableSavedHandler OnTableSaved;

        public TableEditWindow(Context context, DbSet<T> dbset, ErrorsWindow errorsWindow, int rows, List<EntryType> entryTypes, List<string> defaultValues) : base(false, 6)
        {
            this.context = context;
            this.dbset = dbset;
            this.errorsWindow = errorsWindow;
            this.entryTypes = entryTypes;
            this.deleteButton = null;
            this.defaultValues = defaultValues;

            SetupTable();

            addButton = new Button();
            addButton.Label = "Додати Рядок";
            addButton.Image = new Image(Stock.Add, IconSize.Button);
            addButton.AlwaysShowImage = true;
            saveButton = new Button();
            saveButton.Label = "Зберегти Зміни";
            saveButton.Image = new Image(Stock.Save, IconSize.Button);
            saveButton.AlwaysShowImage = true;

            addButton.Clicked += AddRow;
            saveButton.Clicked += OnSaveButtonClicked;

            this.PackStart(addButton, false, false, 0);
            this.PackStart(deleteButton, false, false, 0);
            this.PackStart(saveButton, false, false, 0);
        }

        public List<string> GetColumnNamesFromType()
        {
            List<PropertyInfo> tableClassProperties = new List<PropertyInfo>();
            tableClassProperties.AddRange(typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public));

            var columnNames = new List<string>();
            tableClassProperties.ForEach(property => columnNames.Add(property.Name));
            return columnNames;
        }

        private void SetupTable()
        {
            var tableClassType = typeof(T);

            var columnNames = GetColumnNamesFromType();
            int columns = columnNames.Count;
            this.table = new TableWidget(columns);

            table.SetColumnLabels(columnNames);

            this.PackStart(table, true, true, 0);
            table.ShowAll();
            table.OnRowSelected += (row) =>
            {
                if (deleteButton != null) { table.Remove(deleteButton); }
                var image = new Image(Stock.Delete, IconSize.Button);
                deleteButton = new Button(image);
                deleteButton.Clicked += (sender, args) => { table.RemoveRow(row); table.Remove(deleteButton); deleteButton = null; };
                deleteButton.TooltipText = "Видалити рядок";
                table.Attach(deleteButton, table.columns + 1, row + 1, 1, 1);
                deleteButton.ShowAll();
            };
        }

        protected virtual void OnSaveButtonClicked(object sender, EventArgs e)
        {
            try
            {
                Console.Write("Saving changes.. ");
                context.SaveChanges();
                OnTableSaved?.Invoke();
                Console.WriteLine("Done");
            }
            catch (Exception ex)
            {
                errorsWindow.Report(ex.ToString());
            }
        }

        protected virtual void AddRow(object sender, EventArgs e)
        {
            List<string> values = new List<string>();
            for (int i = 0; i < table.columns; i++)
            {
                switch (entryTypes[i])
                {
                    case EntryType.IncrementedId:
                        values.Add((incrementedId++).ToString());
                        break;
                    case EntryType.NonIncrementedId:
                        values.Add("1");
                        break;
                    default:
                        if (defaultValues != null)
                        {
                            values.Add(defaultValues[i]);
                        }
                        else
                        {
                            values.Add("");
                        }
                        break;
                }
            }
            table.AddRow(values);
        }
    }
}
