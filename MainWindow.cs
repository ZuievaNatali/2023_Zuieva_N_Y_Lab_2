using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gtk;
using Lab2.Models;
using NataLab2;

namespace Lab2
{
    public class MainWindow : Window
    {
        public ErrorsWindow errorsWindow;

        public MainWindow() : base("Labwork #2 - Zuieva Natali")
        {
            SetupTabs();

            DeleteEvent += (o, args) => Application.Quit();
        }

        public void SetupTabs()
        {
            var db = new Context();
            if (db.IsEmpty())
            {
                db.Database.Delete();
            }
            Notebook notebook = new Notebook();

            Label tabLabel1 = new Label("Passport");
            Label tabLabel2 = new Label("Driver");
            Label tabLabel3 = new Label("Employer");
            Label tabLabel4 = new Label("Car");
            Label errorsWindowTabLabel = new Label("Системні Повідомлення");

            this.errorsWindow = new ErrorsWindow(this);

            var passportTableWindow = new PassportTableEdit(db, db.Passports, this.errorsWindow);
            passportTableWindow.table.OnTableModified += (row, column) => { tabLabel1.Text = tabLabel1.Text.Replace("*", "") + "*"; };
            passportTableWindow.OnTableSaved += () => { tabLabel1.Text = tabLabel1.Text.Replace("*", ""); };

            var driverTableWindow = new DriverTableEdit(db, db.Drivers, this.errorsWindow);
            driverTableWindow.table.OnTableModified += (row, column) => { tabLabel2.Text = tabLabel2.Text.Replace("*", "") + "*"; };
            driverTableWindow.OnTableSaved += () => { tabLabel2.Text = tabLabel2.Text.Replace("*", ""); };

            var employerTableWindow = new EmployerTableEdit(db, db.Employers, this.errorsWindow);
            employerTableWindow.table.OnTableModified += (row, column) => { tabLabel3.Text = tabLabel3.Text.Replace("*", "") + "*"; };
            employerTableWindow.OnTableSaved += () => { tabLabel3.Text = tabLabel3.Text.Replace("*", ""); };

            var carWindow = new CarTableEdit(db, db.Cars, this.errorsWindow);
            carWindow.table.OnTableModified += (row, column) => { tabLabel4.Text = tabLabel4.Text.Replace("*", "") + "*"; };
            carWindow.OnTableSaved += () => { tabLabel4.Text = tabLabel4.Text.Replace("*", ""); };

            notebook.AppendPage(passportTableWindow, tabLabel1);
            notebook.AppendPage(driverTableWindow, tabLabel2);
            notebook.AppendPage(employerTableWindow, tabLabel3);
            notebook.AppendPage(carWindow, tabLabel4);
            notebook.AppendPage(errorsWindow, errorsWindowTabLabel);

            Add(notebook);

            Resize(600, 600);
        }
    }
}
