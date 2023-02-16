using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public  class PagoDTO
    {
        private EmpleadoDTO _empleado { get; }
        private EntregaDTO _entrega { get; }
        private SueldoYCompensacionDTO _SyC { get; }
        private decimal _preSueldoBruto { get => SueldoBasePorMes + AdicionalPorEntrega + AdicionalPorHora; }
        [DisplayName("Nombre de Empleado")]
        public string Nombre { get => _empleado.Nombre; }
        [DisplayName("Puesto")]
        public string Rol { get => _empleado.Rol.Descripcion; }
        [DisplayName("Sueldo por hora")]
        public decimal SueldoBasePorHora { get => _SyC.SueldoBase; }
        [DisplayName("Sueldo diario")]
        public decimal SueldoDiario { get => _SyC.SueldoBase * _SyC.HorasXJornada; }
        [DisplayName("Dias trabajados por mes")]
        public decimal DiasPorMes { get=> _SyC.DiasXSemana * 4; }
        [DisplayName("Sueldo base por mes")]
        public decimal SueldoBasePorMes { get => SueldoDiario * DiasPorMes; }
        [DisplayName("Compensacion por entrega")]
        public decimal CompensacionPorEntregs { get => _SyC.CompensacionXEntrega; }
        [DisplayName("Entregas del mes")]
        public int Entregas { get => _entrega.CantidadEntregas; }
        [DisplayName("Adicional por entregas")]
        public decimal AdicionalPorEntrega { get => CompensacionPorEntregs * _entrega.CantidadEntregas; }
        [DisplayName("Horas Laboradas")]
        public int HorasLaboradas { get => (_SyC.HorasXJornada * _SyC.DiasXSemana) * 4; }
        [DisplayName("Bono por hora")]
        public decimal BonoPorHora { get => _SyC.BonoxHora; }
        [DisplayName("Adicional por horas trabajadas")]
        public decimal AdicionalPorHora { get => BonoPorHora * HorasLaboradas; }
        [DisplayName("Porcentaje en vales")]
        public decimal PorcentajeVales { get => _SyC.PorcentajeValesDespensa; }
        [DisplayName("Adicional en vales")]
        public decimal AdicionalPorVales { get => (PorcentajeVales * _preSueldoBruto) / 100; }
        [DisplayName("Sueldo Bruto")]
        public decimal SueldoBruto { get => _preSueldoBruto + AdicionalPorVales; }
        [DisplayName("Porcentaje de retencion de impuestos")]
        public decimal ImpuestosAplicables { get; set; }
        [DisplayName("Sueldo Neto")]
        public decimal SueldoNeto { get => SueldoBruto - ((SueldoBruto * ImpuestosAplicables) / 100); }


        public PagoDTO(EmpleadoDTO empleado, EntregaDTO entrega, SueldoYCompensacionDTO resultSyC)
        {
            _empleado = empleado;
            _entrega = entrega;
            _SyC = resultSyC;
        }
    }
}
