using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Shared.Dtos
{
    public class DiaTrabajoEditarDto
    {
        public int Id { get; set; }
        public string AbiertoPor { get; set; }
        public string Estado { get; set; }
        public string DiaDeSemana { get; set; }

    }
}
