using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.EntityFrameworkCore.Extensions;
using System.Data.Entity;
using Lab2.Models;

namespace Lab2
{
    public class Context : DbContext
    {
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Car> Cars { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (optionsBuilder.IsConfigured)
        //    {
        //        throw new System.NotImplementedException();
        //    }
        //    optionsBuilder.UseMySQL("server=localhost;database=car_salon_cs;user=root;password=123;CharSet=utf8;");

        //}

        public bool IsEmpty()
        {
            try
            {
                return Passports.Count() == 0 && Drivers.Count() == 0 && Employers.Count() == 0 && Cars.Count() == 0;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
