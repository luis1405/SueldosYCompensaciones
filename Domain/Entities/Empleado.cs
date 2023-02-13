using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        [ForeignKey("IdRol")]
        public Rol Rol { get; set; }
    }
}
