using Data.Contratos;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    internal class AppDbContext: DbContext
    {
        private ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings["RC-MYSQL"];

        public DbSet<IRoles> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString.ConnectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<IRoles>().ToTable("Roles");
        }
    }
}
