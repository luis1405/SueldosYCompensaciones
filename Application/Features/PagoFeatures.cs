using Application.DTOs;
using Application.Features.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features
{
    public class PagoFeatures : IPagoFeatures
    {
        public decimal PagoAntesImpuestos(EntregaDTO entrega, SueldoYCompensacionDTO resultSyC)
        {
            decimal sueldoDiario = resultSyC.SueldoBase * resultSyC.HorasXJornada;
            decimal diasMes = resultSyC.DiasXSemana * 4;
            decimal sueldoMesBase = sueldoDiario * diasMes;

            decimal adicionalXEntrega = resultSyC.CompensacionXEntrega * entrega.CantidadEntregas;
            int horasLaboradas = (resultSyC.HorasXJornada * resultSyC.DiasXSemana) * 4;
            decimal adicionalXHora = resultSyC.BonoxHora * horasLaboradas;
            decimal preSueldoBruto = sueldoMesBase + adicionalXEntrega + adicionalXHora;
            decimal adicionalXVales = (resultSyC.PorcentajeValesDespensa * preSueldoBruto ) / 100;
            decimal sueldoBruto = preSueldoBruto + adicionalXVales;

            return sueldoBruto;
        }
    }
}
