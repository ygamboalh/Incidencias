using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Shared.Models
{
    public class Estado
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="¿Cuál es el nombre del Estado?")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "¿Cuál es la descripción del Estado?")]
        public string Descripcion { get; set; }
    }
}
