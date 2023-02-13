using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interfaces
{
    public interface IRolFeatures
    {
        int Count(List<RolDTO> Roles);
    }
}
