using DataBase.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Roles> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=HERNANDEZ;DataBase=SueldosYCompensaciones;Trusted_Connection=True;TrustServerCertificate=True");

        }
    }
}
