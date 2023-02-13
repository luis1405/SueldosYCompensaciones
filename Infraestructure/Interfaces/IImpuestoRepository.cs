using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Interfaces
{
    public interface IImpuestoRepository
    {
        Task<decimal> GetTotalImpuestos(decimal salarioMensual);
    }
}
