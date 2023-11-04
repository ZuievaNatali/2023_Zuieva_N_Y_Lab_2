using Lab2.Models;
using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace NataLab2
{
    internal class DriverTableEdit : TableEditWindow<Driver>
    {
        public DriverTableEdit(Context context, DbSet<Driver> dbset, ErrorsWindow errorsWindow) :
          base(context, dbset, errorsWindow, 3, new List<EntryType>() {
                EntryType.IncrementedId,
                EntryType.NonIncrementedId,
                EntryType.NonIncrementedId,
                EntryType.NonIncrementedId,
          }, new List<string>()
          {
                "",
                "",
                "",
                "",
          }
              )
        {
            if (context.IsEmpty())
            {
                AddRow(this, null);
            }
            else
            {
                foreach (var entity in dbset.ToList())
                {
                    table.AddRow(new List<string>() {
                        entity.DriverId.ToString(),
                        entity.PassportId.ToString(),
                        entity.DriverLicenseId.ToString(),
                        entity.CarId.ToString()
                    });
                }
            }
        }

        protected override void OnSaveButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var entities = context.Drivers.ToList();
                context.Drivers.RemoveRange(entities);
                foreach (var row in table.entryRows)
                {
                    var driver = new Driver()
                    {
                        DriverId = int.Parse(row[0].Text),
                        PassportId = int.Parse(row[1].Text),
                        DriverLicenseId = int.Parse(row[2].Text),
                        CarId = int.Parse(row[3].Text)
                    };
                    context.Drivers.Add(driver);
                    Console.Write(".");
                }
                base.OnSaveButtonClicked(sender, e);
            }
            catch (Exception ex)
            {
                errorsWindow.Report(ex.ToString());
            }
        }
    }
}
