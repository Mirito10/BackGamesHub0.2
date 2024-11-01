using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Entidades
{
    public class Logros
    {
        public string Token { get; set; }

        public int LogroId { get; set; }

        public int CriterioValor { get; set; }

        public string nombreLogro { get; set; }

        public string descripcion { get; set; }

        public int juegoId { get; set; }

        public int puntosOtorgador { get; set; }

        public string criterioDesbloqueo { get; set; }

        public int usuarioId { get; set; }
    }
}
