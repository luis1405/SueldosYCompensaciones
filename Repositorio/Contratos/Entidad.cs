using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Contratos
{
    public class Entidad:IEntidad
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
