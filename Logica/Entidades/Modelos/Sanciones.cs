using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Entidades
{
    public class Sanciones
    {
        public string mensajeSancion { get; set; }

        public int? reporteId { get; set; }

        public string tipoSancion { get; set; }

        public string descripcion { get; set; } 

        public DateTime fechaFin {  get; set; }
    }
}
