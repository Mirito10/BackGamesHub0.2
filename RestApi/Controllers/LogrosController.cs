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
    public class LogrosController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/logros/DesbloquearLogros")]
        public ResDesbloquearLogros DesbloquearLogros (ReqDesbloquearLogros req)
        {
            return new LogicaLogros().DesbloquearLogros(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/logros/IngresarLogro")]
        public ResIngresarLogro IngresarLogro (ReqIngresarLogro req)
        {
            return new LogicaLogros().IngresarLogro(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/logros/ObtenerLogrosBloqueados")]
        public ResObtenerLogrosBloqueados ObtenerLogrosBloqueados (ReqObtenerLogrosBloqueados req)
        {
            return new LogicaLogros().ObtenerLogrosBloqueados(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/logros/ObtenerLogrosDesbloqueados")]
        public ResObtenerLogrosDesbloqueados ObtenerLogrosDesbloqueados (ReqObtenerLogrosDesbloqueados req)
        {
            return new LogicaLogros().ObtenerLogrosDesbloqueados(req);
        }
    }
}