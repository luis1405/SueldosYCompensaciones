using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SueldoYCompensacion
    {
        [Key]
        public int IdSueldoCompensacion { get; set; }
        public int IdRol { get; set; }
        public decimal  SueldoBase { get; set; }
        public int HorasXJornada { get; set; }
        public int DiasXSemana { get; set; }
        public decimal CompensacionXEntrega { get; set; }
        public decimal BonoxHora { get; set; }
        public decimal PorcentajeValesDespensa { get; set; }
    }
}
