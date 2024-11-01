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
    public class AmigosController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/amigos/ObtenerAmigos")]
        public ResObtenerAmigos ObtenerAmigos (ReqObtenerAmigos req)
        {
            return new LogicaAmigos().ObtenerAmigos(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/amigos/EliminarAmigos")]
        public ResElimiarAmigos EliminarAmigos (ReqEliminarAmigos req)
        {
            return new LogicaAmigos().EliminarAmigos(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/amigos/EnviarSolicitudAmistad")]
        public ResEnviarSolicitud EnviarSolicitudAmistad (ReqEnviarSolicitud req)
        {
            return new LogicaAmigos().EnviarSolicitud(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/amigos/ObtenerEstadoSolicitud")]
        public ResObtenerEstadoSolicitud ObtenerEstadoSolicitud (ReqObtenerEstadoSolicitud req)
        {
            return new LogicaAmigos().ObtenerEstadoSolicitud(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/amigos/ObtenerSolicitudesPendientes")]
        public ResObtenerSolicitudesPendientes ObtenerSolicitudesPendientes (ReqObtenerSolicitudesPendientes req)
        {
            return new LogicaAmigos().SolicitudesPendientes(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/amigos/AceptarSolicitud")]
        public ResAceptarSolicitudesAmistad AceptarSolicitud (ReqAceptarSolicitudAmistad req)
        {
            return new LogicaAmigos().AceptarSolicitudes(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/amigos/RechazarSolicitudAmistad")]
        public ResRechazarSolicitud RecahazrSolicitud(ReqRechazarSolicitud req)
        {
            return new LogicaAmigos().RecahazrSolicitud(req);
        }
    }
}