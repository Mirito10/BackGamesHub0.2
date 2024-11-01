using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Entidades
{
    public class ResObtenerEstadoSolicitud : ResBase
    {
        public List<SolicitudAmigo> estadoSolicitud { get; set; }
    }
}
