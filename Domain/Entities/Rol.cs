using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        public string Descripcion { get; set; }
    }
}
