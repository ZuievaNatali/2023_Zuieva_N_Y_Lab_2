using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Models;
using Lab2;
using System.Data.Entity;

    namespace NataLab2
    {
        internal class EmployerTableEdit : TableEditWindow<Employer>
        {
            public EmployerTableEdit(Context context, DbSet<Employer> dbset, ErrorsWindow errorsWindow) :
              base(context, dbset, errorsWindow, 3, new List<EntryType>() {
                EntryType.IncrementedId,
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
                        entity.EmployerId.ToString(),
                        entity.EmployerPositionId.ToString(),
                        entity.EmployerRankId.ToString()
                    });
                    }
                }
            }

            protected override void OnSaveButtonClicked(object sender, EventArgs e)
            {
                try
                {
                    var entities = context.Employers.ToList();
                    context.Employers.RemoveRange(entities);
                    foreach (var row in table.entryRows)
                    {
                        var employer = new Employer()
                        {
                            EmployerId = int.Parse(row[0].Text),
                            EmployerPositionId = int.Parse(row[1].Text),
                            EmployerRankId = int.Parse(row[2].Text)
                        };
                        context.Employers.Add(employer);
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
