using DTO.Models;

namespace Repository.Interfaces
{
    public interface IRolesRepository
    {
        Task<List<RolesDTO>> GetRoles();
        Task<RolesDTO> GetRol(int rolId);
        Task Save();
    }
}
