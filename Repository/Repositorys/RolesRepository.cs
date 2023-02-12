using DataBase.Context;
using DataBase.DbModels;
using DTO.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repositorys
{
    public class RolesRepository : IRolesRepository
    {
        private readonly AppDbContext _appDbContext;
        public RolesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<RolesDTO> GetRol(int rolId)
        {
            Roles rolesDb = await _appDbContext.Roles.FirstOrDefaultAsync(rol => rol.Id == rolId);
            if (rolesDb == null)
                return null;

            return new RolesDTO()
            {
                Id = rolesDb.Id,
                Descripcion = rolesDb.Descripcion
            };
            
        }
        public async Task<List<RolesDTO>> GetRoles()
        {
            List<Roles> rolesDb = await _appDbContext.Roles.ToListAsync();

            List<RolesDTO> roles = rolesDb.Select(rol => new RolesDTO()
            {
                Id = rol.Id,
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
            catch(Exception e)
            {
                
            }
        }
    }
}
