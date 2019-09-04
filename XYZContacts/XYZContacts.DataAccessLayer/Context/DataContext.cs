using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZContacts.Entities;

namespace XYZContacts.DataAccessLayer.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("cnn")
        {
          

            Database.SetInitializer<DataContext>(new DataInitializer());

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<AppIdentity> AppIdentities { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }

    }
}
