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
    public class MensajesController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Mensajes/EnviarMensaje")]
        public ResEnviarMensaje EnviarMensaje(ReqEnviarMensajes req)
        {
            return new LogicaMensajes().EnviarMensaje(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Mensajes/MarcarMensajes")]
        public ResMarcarMensajes MarcarMensajes(ReqMarcarMensajes req)
        {
            return new LogicaMensajes().MarcarMensajes(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Mensajes/RecuperarMensajes")]
        public ResRecuperarMensajes RecuperarMensajes(ReqRecuperarMensajes req)
        {
            return new LogicaMensajes().RecuperarMensajes(req);
        }
    }
}