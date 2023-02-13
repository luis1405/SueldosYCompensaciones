using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Impuesto
    {
        [Key]
        public int IdImpuesto { get; set; }
        public decimal SalarioLimite { get; set; }
        public decimal PorcentajeImpuesto { get; set; }

    }
}
