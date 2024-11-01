using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Entidades
{
    public class Partida
    {
        public int? partidaId {  get; set; }

        public string Token { get; set; }

        public int? puntajeObtenido { get; set; }

        public int? JuegoId { get; set; }
    }
}
