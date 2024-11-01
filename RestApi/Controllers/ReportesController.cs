using Logica.CapaLogica;
using Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RestApi.Controllers
{
    public class ReportesController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Reportes/ObtenerReportes")]
        public ResReportes ObtenerReportes(ReqReportes req)
        {
            return new LogicaReportes().ObtenerReportes(req);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Reportes/ReportarUsuario")]
        public ResReportarUsuario ReportarUsuario(ReqReportarUsuario req)
        {
            return new LogicaReportes().ReportarUsuario(req);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Reportes/SancionarUsuario")]
        public ResSancionar SancionarUsuario(ReqSancionar req)
        {
            return new LogicaReportes().SancionarUsuario(req);
        }
    }
}