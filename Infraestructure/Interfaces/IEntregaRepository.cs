using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Interfaces
{
    public interface IEntregaRepository
    {
        Task<EntregaDTO> GetEntregas(int IdEmpleado, int IdMes);
        Task<List<EntregaDTO>> GetAllEntregas();

        Task<int> Save(EntregaDTO entrega);
    }
}
