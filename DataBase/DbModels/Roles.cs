using Data.Contratos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbModels
{
    public class Roles : IEntidad
    {
        [Key]
        public int Id { get ; set; }
        [Required(ErrorMessage ="Campo requerido")]
        [StringLength(20)]
        public string Descripcion { get; set; }
    }
}
