using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<SueldoYCompensacion> SueldosYCompensaciones { get; set; }
        public DbSet<Entrega> Entregas { get; set; }
        public DbSet<Impuesto> Impuestos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=HERNANDEZ;DataBase=SueldosYCompensaciones;Trusted_Connection=True;TrustServerCertificate=True");

        }
    }
}
