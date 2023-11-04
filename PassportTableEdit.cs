using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Lab2.Models;
using Lab2;

namespace NataLab2
{
    public class PassportTableEdit : TableEditWindow<Passport>
    {
        public PassportTableEdit(Context context, DbSet<Passport> dbset, ErrorsWindow errorsWindow) :
           base(context, dbset, errorsWindow, 3, new List<EntryType>() {
                EntryType.IncrementedId,
                EntryType.String,
                EntryType.String,
                EntryType.String,
                EntryType.String,
                EntryType.String,
                EntryType.NonIncrementedId,
                EntryType.String
           }, new List<string>()
           {
                "",
                "І'мя",
                "По-Батькові",
                "Прізвище",
                "Стать",
                "Номер Паспорту",
                "",
                "1900-01-01",
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
                        entity.PassportId.ToString(),
                        entity.FirstName.ToString(),
                        entity.MiddleName.ToString(),
                        entity.LastName.ToString(),
                        entity.Sex.ToString(),
                        entity.PassportNumber.ToString(),
                        entity.AddressId.ToString(),
                        entity.BirthDate.ToString("yyyy-MM-dd")
                    });
                }
            }
        }

        protected override void OnSaveButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var entities = context.Passports.ToList();
                context.Passports.RemoveRange(entities);
                foreach (var row in table.entryRows)
                {
                    var passport = new Passport()
                    {
                        PassportId = int.Parse(row[0].Text),
                        FirstName = row[1].Text,
                        MiddleName = row[2].Text,
                        LastName = row[3].Text,
                        Sex = row[4].Text,
                        PassportNumber = row[5].Text,
                        AddressId = int.Parse(row[6].Text),
                        BirthDate = DateTime.ParseExact(row[7].Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
                    };
                    context.Passports.Add(passport);
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
