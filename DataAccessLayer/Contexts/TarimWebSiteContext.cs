using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contexts
{
    public class TarimWebSiteContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlServer(
                  @"Server=UMUTARDAVURAL\SQLEXPRESS;Database=DbTarim;Integrated Security=True;TrustServerCertificate=True;");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


        }

        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<Announcement> Announcements { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Team> Teams { get; set; }



    }
}
