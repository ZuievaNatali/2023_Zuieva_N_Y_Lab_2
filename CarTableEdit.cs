using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Models;
using Lab2;
using Gtk;

namespace Lab2
{
    public class CarTableEdit : TableEditWindow<Car>
    {
        public CarTableEdit(Context context, DbSet<Car> dbset, ErrorsWindow errorsWindow) :
            base(context, dbset, errorsWindow, 3, new List<EntryType>() {
                EntryType.IncrementedId,
                EntryType.NonIncrementedId,
                EntryType.NonIncrementedId,
                EntryType.NonIncrementedId,
                EntryType.NonIncrementedId,
                EntryType.NonIncrementedId,
                EntryType.NonIncrementedId,
                EntryType.NonIncrementedId,
                EntryType.NonIncrementedId,
                EntryType.NonIncrementedId,
                EntryType.String
            }, new List<string>()
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "Кількість Сидінь",
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
                        entity.CarId.ToString(),
                        entity.MarkId.ToString(),
                        entity.ModelId.ToString(),
                        entity.ColorId.ToString(),
                        entity.AccountingId.ToString(),
                        entity.CarNumberId.ToString(),
                        entity.CategoriesId.ToString(),
                        entity.BodyTypeId.ToString(),
                        entity.EngineTypeId.ToString(),
                        entity.OwnershipTypeId.ToString(),
                        entity.Sit
                    });
                }
            }
        }

        protected override void OnSaveButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var entities = context.Cars.ToList();
                context.Cars.RemoveRange(entities);
                foreach (var row in table.entryRows)
                {
                    var car = new Car()
                    {
                        CarId = int.Parse(row[0].Text),
                        MarkId = int.Parse(row[1].Text),
                        ModelId = int.Parse(row[2].Text),
                        ColorId = int.Parse(row[3].Text),
                        AccountingId = int.Parse(row[4].Text),
                        CarNumberId = int.Parse(row[5].Text),
                        CategoriesId = int.Parse(row[6].Text),
                        BodyTypeId = int.Parse(row[7].Text),
                        EngineTypeId = int.Parse(row[8].Text),
                        OwnershipTypeId = int.Parse(row[9].Text),
                        Sit = row[10].Text
                    };
                    context.Cars.Add(car);
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
