using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Entidades
{
    public class SolicitudAmigo
    {
        public int? solicitudId {  get; set; }

        public string Token { get; set; }

        public string Estado { get; set; }

        public int? usuarioEmisorId { get; set; }

        public string nombreEmisor { get; set; }
    }
}
