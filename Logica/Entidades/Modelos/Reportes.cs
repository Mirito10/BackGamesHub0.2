using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Entidades
{
    public class Reportes
    {
        public int reporteId { get; set; }

        public int usuarioReportado { get; set; }

        public int usuarioReportador { get; set; }

        public string descripcion { get; set; }

        public string estadoReporte { get; set; }

        public string token { get; set; }

        public string ReportadoUID { get; set; }
    }
}
