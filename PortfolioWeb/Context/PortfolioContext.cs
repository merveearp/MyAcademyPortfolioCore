using Microsoft.EntityFrameworkCore;
using PortfolioWeb.Entities;

namespace PortfolioWeb.Context
{
    public class PortfolioContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-QN7HAT1\\SQLEXPRESS; database=MyAcademyPortfolioDb; integrated security=true; trustServerCertificate=true");
        }

        //pluralizen
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Project> Projects { get; set; }


    }
}
