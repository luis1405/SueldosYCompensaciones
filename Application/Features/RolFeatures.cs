using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features
{
    public class RolFeatures
    {
        public int Count (List<RolDTO> Roles)
        {
            return Roles.Count;
        }
    }
}
