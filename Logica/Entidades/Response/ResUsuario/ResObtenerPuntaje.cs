using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Entidades
{
    public class ResObtenerPuntaje : ResBase
    {
        public List<PuntajeMultijugador> obtenerPuntaje { get; set; }
    }
}
