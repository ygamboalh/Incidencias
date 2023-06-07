using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Shared.Models
{
    public class DiaTrabajo
    {
        public int Id { get; set; }
        public DateTime HoraInicio{ get; set; }
        public DateTime HoraFin { get; set; }
        public DateTime HoraCreado { get; set; } = DateTime.Now;
        public List<Ocurrencia> Ocurrencias { get; set; } = new List<Ocurrencia>();
        [Required(ErrorMessage = "¿Quién abrió el Día de trabajo?")]
        public string AbiertoPor { get; set; }
        public string Estado { get; set; } = "Abierto";
        public string DiaDeSemana { get; set; }
    }
}
