using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Shared.Models
{
    public class TipoOcurrencia
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "¿Cuál es el nombre del Tipo?")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "¿Cuál es la descripción del Tipo?")]
        public string Descripcion { get; set; }
    }
}
