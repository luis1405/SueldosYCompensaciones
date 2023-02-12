using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Interfaces
{
    public interface IRolRepository
    {        Task<List<RolDTO>> GetRoles();
        Task<RolDTO> GetRol(int rolId);
        Task Save();
    }
}
