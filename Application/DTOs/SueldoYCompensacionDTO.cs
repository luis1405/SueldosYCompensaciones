using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class SueldoYCompensacionDTO
    {
        public decimal SueldoBase { get; set; }
        public int HorasXJornada { get; set; }
        public int DiasXSemana { get; set; }
        public decimal CompensacionXEntrega { get; set; }
        public decimal BonoxHora { get; set; }
        public decimal PorcentajeValesDespensa { get; set; }
    }
}
