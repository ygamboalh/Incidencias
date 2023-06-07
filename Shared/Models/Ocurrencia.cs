using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Shared.Models
{
    public class Ocurrencia
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="¿Cuál es la Descripción?")]
        public string Descripcion { get; set; }
        public string Resumen { get; set; }
        [Required(ErrorMessage = "¿Cuál fue la hora de la ocurrencia?")]
        public DateTime HoraOcurrencia { get; set; }
        public DateTime HoraCreada { get; set; } = DateTime.Now;
        [Required]
        public string ReportadaPor { get; set; }
        [Required(ErrorMessage = "¿Cuál es el tipo de la ocurrencia?")]
        public string TipoOcurrencia { get; set; }
        [Required(ErrorMessage = "¿Cuál es el estado de la ocurrencia?")]
        public string Estado { get; set; } = String.Empty;
        public int DiaTrabajoId { get; set; }

    }
}
