using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Entrega
    {
        [Key]
        public int IdEntrega { get; set; }
        public int IdEmpleado { get; set; }
        public int IdMes { get; set; }
        public int CantidadEntregas { get; set; }
        [ForeignKey("IdEmpleado")]
        public Empleado Empleado { get; set; }
    }
}
