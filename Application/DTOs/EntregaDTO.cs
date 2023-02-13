using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class EntregaDTO
    {
        public int IdEntrega { get; set; }
        public int IdEmpleado { get; set; }
        public int IdMes { get; set; }
        public int CantidadEntregas { get; set; }
        public EmpleadoDTO Empleado { get; set; }
    }
}
