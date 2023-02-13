using Application.DTOs;
using Domain.Entities;
using Infraestructure.Context;
using Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository
{
    public class SueldoYCompensacionRepository : ISueldoYCompensacionRepository
    {
        private readonly AppDbContext _appDbContext;

        public SueldoYCompensacionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<SueldoYCompensacionDTO> GetSueldoYCompensacion(int rolId)
        {
            SueldoYCompensacion sueldo = await _appDbContext.SueldosYCompensaciones.FirstOrDefaultAsync(sueldo => sueldo.IdRol == rolId);
            if (sueldo == null)
            {
                return new SueldoYCompensacionDTO()
                {
                    SueldoBase = 0,
                    HorasXJornada = 0,
                    DiasXSemana = 0,
                    CompensacionXEntrega = 0,
                    BonoxHora = 0,
                    PorcentajeValesDespensa = 0
                };
            }

            return new SueldoYCompensacionDTO()
            {
                SueldoBase = sueldo.SueldoBase,
                HorasXJornada = sueldo.HorasXJornada,
                DiasXSemana = sueldo.DiasXSemana,
                CompensacionXEntrega = sueldo.CompensacionXEntrega,
                BonoxHora = sueldo.BonoxHora,
                PorcentajeValesDespensa = sueldo.PorcentajeValesDespensa
            };
        }
    }
}
