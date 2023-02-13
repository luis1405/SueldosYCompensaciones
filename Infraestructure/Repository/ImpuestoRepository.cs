using Application.DTOs;
using Domain.Entities;
using Infraestructure.Context;
using Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class ImpuestoRepository : IImpuestoRepository
    {
        private readonly AppDbContext _appDbContext;

        public ImpuestoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<decimal> GetTotalImpuestos(decimal salarioMensual)
        {
            var res = _appDbContext.Impuestos.Where(r => r.SalarioLimite <= salarioMensual);
            var sum1 = res.Sum(r => r.PorcentajeImpuesto);
            List<Impuesto> resultDb = await _appDbContext.Impuestos.Where(r => r.SalarioLimite <= salarioMensual).ToListAsync();
            decimal sum = resultDb.Sum(r => r.PorcentajeImpuesto);

            return sum;
        }

    }
}
