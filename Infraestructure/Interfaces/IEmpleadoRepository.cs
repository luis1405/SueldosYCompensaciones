using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Interfaces
{
    public interface IEmpleadoRepository
    {
        Task<EmpleadoDTO> GetEmpleado(int IdEmpleado);
        Task<List<EmpleadoDTO>> GetEmpleados();
        Task<int> Save(EmpleadoDTO empleado);
    }
}
