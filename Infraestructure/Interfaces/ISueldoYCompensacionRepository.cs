using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Interfaces
{
    public interface ISueldoYCompensacionRepository
    {
        Task<SueldoYCompensacionDTO> GetSueldoYCompensacion(int rolId);
    }
}
