using HWW8WithEF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWW8WithEF.DataAccess
{
    public class AppDbContext : DbContext
    {

        public DbSet<ContactInfo> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Dessert> Desserts { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Food>  Foods { get; set; }
        public DbSet<MainCourse> MainCourses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(@"Server=ALI\SQLEXPRESS;Database=MyRestaurantDb;Integrated Security=True;TrustServerCertificate=True;");
        }
    }
}
