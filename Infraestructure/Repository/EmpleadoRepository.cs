using Application.DTOs;
using Domain.Entities;
using Infraestructure.Context;
using Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmpleadoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<EmpleadoDTO> GetEmpleado(int IdEmpleado)
        {
            Empleado empleado = await _appDbContext.Empleados.Where(r => r.IdEmpleado == IdEmpleado)
                                        .Include(r => r.Rol).FirstOrDefaultAsync();
            if (empleado == null)
                return null;

            return new EmpleadoDTO()
            {
                IdEmpleado = empleado.IdEmpleado,
                IdRol = empleado.IdRol,
                Nombre = empleado.Nombre,
                Rol = new RolDTO(){
                    IdRol = empleado.Rol.IdRol,
                    Descripcion = empleado.Rol.Descripcion
                }
            };
        }
        public async Task<List<EmpleadoDTO>> GetEmpleados()
        {
            List<Empleado> resultDb = await _appDbContext.Empleados.ToListAsync();

            List<EmpleadoDTO> roles = resultDb.Select(r => new EmpleadoDTO()
            {
                IdEmpleado=r.IdEmpleado,
                IdRol = r.IdRol,
                Nombre = r.Nombre
            }).ToList();

            return roles;

        }

        public async Task<int> Save(EmpleadoDTO empleado)
        {
            try
            {
                Empleado newEmpleado = new Empleado()
                {
                    IdRol = empleado.IdRol,
                    Nombre = empleado.Nombre
                };
                _appDbContext.Add(newEmpleado);
                return await _appDbContext.SaveChangesAsync();
            }
            catch
            {
                return 0;

            }
        }
    }
}
