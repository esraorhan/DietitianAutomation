using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class DietContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-8AK4CAP;Database=DietitianAutomationDB;User Id=sa;Password=esra1905;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<AdultCustomer> AdultCustomers { get; set; }
        public DbSet<AdultCustomerDetail> AdultCustomerDetails { get; set; }
        public DbSet<AdultMeeting> AdultMeetings { get; set; }
        public DbSet<DietPlan> DietPlans { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<GeneralDietList> GeneralDietLists { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<CustomerFolder> CustomerFolders { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<CustomerDietList> CustomerDietLists { get; set; }
        public DbSet<CustomerDietPlan> CustomerDietPlans { get; set; }
    }
}
