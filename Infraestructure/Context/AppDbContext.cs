using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Rol> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=HERNANDEZ;DataBase=SueldosYCompensaciones;Trusted_Connection=True;TrustServerCertificate=True");

        }
    }
}
