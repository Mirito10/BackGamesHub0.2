using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Entidades
{
    public class PartidaMultijugador
    {
        public int partidaId {  get; set; }

        public string token { get; set; }

        public int? PartidaUID { get; set; }

        public List<PartidaMultijugador> puntajesPartidaMultijugador = new List<PartidaMultijugador>();
    }
}
