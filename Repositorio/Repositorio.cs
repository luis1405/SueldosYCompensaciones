using Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Data.Contratos;
using Microsoft.EntityFrameworkCore;

namespace Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : Entidad, new()
    {
        public void Actualizar(T entidad)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Entry(entidad).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Agregar(T entidad)
        {
            using (var db = new AppDbContext())
            {
                db.Entry(entidad).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var db = new AppDbContext())
            {
                var entidad = new T() { Id = id };
                db.Entry(entidad).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public T ObtenerPorId(int id)
        {
            using (var db = new AppDbContext())
            {
                return db.Set<T>().FirstOrDefault(x => x.Id == id);
            }
        }

    }
}
