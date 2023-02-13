using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class EmpleadoDTO
    {
        public int IdEmpleado { get; set; }
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public RolDTO Rol { get; set; }
    }
}
