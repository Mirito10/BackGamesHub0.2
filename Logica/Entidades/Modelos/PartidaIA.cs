using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Entidades
{
    public class PartidaIA
    {
        public string Token { get; set; }

        public int? JuegoId { get; set; }

        public string InstruccionesIniciales { get; set; }

        public string ContextoJuego { get; set; }

        public string NarrativaFondo { get; set; }

        public string EstadoMental { get; set; }

        public string Configuracion { get; set; }
    }
}
