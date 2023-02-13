using Application.DTOs;
using Domain.Entities;
using Infraestructure.Context;
using Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class EntregaRepository : IEntregaRepository
    {
        private readonly AppDbContext _appDbContext;

        public EntregaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<EntregaDTO> GetEntregas(int IdEmpleado, int IdMes)
        {
            Entrega resultData = await _appDbContext.Entregas.Where(r => r.IdEmpleado == IdEmpleado && r.IdMes == IdMes)
                                .Include(r => r.Empleado).ThenInclude(r => r.Rol).FirstOrDefaultAsync();
            if (resultData == null)
                return null;

            EntregaDTO entrega = new EntregaDTO()
            {
                IdEmpleado = resultData.IdEmpleado,
                IdMes = resultData.IdMes,
                CantidadEntregas = resultData.CantidadEntregas,
                Empleado = new EmpleadoDTO() { 
                    IdRol = resultData.Empleado.IdRol,
                    IdEmpleado = resultData.Empleado.IdEmpleado,
                    Nombre = resultData.Empleado.Nombre,
                    Rol = new RolDTO()
                    {
                        IdRol = resultData.Empleado.Rol.IdRol,
                        Descripcion = resultData.Empleado.Rol.Descripcion
                    }
                }
            };

            return entrega;
        }
        public async Task<List<EntregaDTO>> GetAllEntregas()
        {
            List<Entrega> resultData = await _appDbContext.Entregas.Include(r => r.Empleado).ThenInclude(r => r.Rol).ToListAsync();
            if (resultData == null)
                return null;

            List<EntregaDTO> entrega = resultData.Select(r => new EntregaDTO()
            {
                IdEmpleado = r.IdEmpleado,
                IdMes = r.IdMes,
                CantidadEntregas = r.CantidadEntregas,
                Empleado = new EmpleadoDTO()
                {
                    IdRol = r.Empleado.IdRol,
                    IdEmpleado = r.Empleado.IdEmpleado,
                    Nombre = r.Empleado.Nombre,
                    Rol = new RolDTO()
                    {
                        IdRol = r.Empleado.Rol.IdRol,
                        Descripcion = r.Empleado.Rol.Descripcion
                    }
                }
            }).ToList();

            return entrega;
        }

        public async Task<int> Save(EntregaDTO entrega)
        {
            try
            {
                Entrega addEntrega = new Entrega()
                {
                    IdEmpleado = entrega.IdEmpleado,
                    IdMes = entrega.IdMes,
                    CantidadEntregas = entrega.CantidadEntregas
                };
                _appDbContext.Add(addEntrega);
                return await _appDbContext.SaveChangesAsync();
            }
            catch
            {
                return 0;

            }
        }
    }
}
