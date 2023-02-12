using Application.DTOs;
using Domain.Entities;
using Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infraestructure.Interfaces;

namespace Infraestructure.Repository
{
    public class RolRepository : IRolRepository
    {
        private readonly AppDbContext _appDbContext;
        public RolRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<RolDTO> GetRol(int rolId)
        {
            Rol rolesDb = await _appDbContext.Roles.FirstOrDefaultAsync(rol => rol.IdRol == rolId);
            if (rolesDb == null)
                return null;

            return new RolDTO()
            {
                IdRol = rolesDb.IdRol,
                Descripcion = rolesDb.Descripcion
            };

        }
        public async Task<List<RolDTO>> GetRoles()
        {
            List<Rol> rolesDb = await _appDbContext.Roles.ToListAsync();

            List<RolDTO> roles = rolesDb.Select(rol => new RolDTO()
            {
                IdRol = rol.IdRol,
                Descripcion = rol.Descripcion
            }).ToList();

            return roles;

        }
        public async Task Save()
        {
            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }
        }
    }
}
