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
    public class UsuarioController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Usuario/CrearUsuario")]
        public ResCrearUsuario Crear(ReqCrearUsuario req)
        {
            return new LogicaUsuarios().Crear(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Usuario/CerrarSesion")]
        public ResCerrarSesion CerrarSesion(ReqCerrarSesion req)
        {
            return new LogicaUsuarios().CerrarSesion(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Usuario/EditarUsuario")]
        public ResEditarUsuario EditarUsuario(ReqEditarUsuario req)
        {
            return new LogicaUsuarios().EditarUsuario(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Usuario/IniciarSesion")]
        public ResIniciarSesion IniciarSesion(ReqIniciarSesion req)
        {
            return new LogicaUsuarios().IniciarSesion(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Usuario/ObtenerNotificaciones")]
        public ResObtenerNotificaciones ObtenerNotificaciones(ReqObtenerNotificaciones req)
        {
            return new LogicaUsuarios().ObtenerNotificaciones(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Usuario/ObtenerPuntaje")]
        public ResObtenerPuntaje ObtenerPuntaje(ReqObtenerPuntaje req)
        {
            return new LogicaUsuarios().ObtenerPuntaje(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Usuario/ObtenerSanciones")]
        public ResObtenerSanciones ObtenerSanciones(ReqObtenerSanciones req)
        {
            return new LogicaUsuarios().ObtenerSanciones(req);
        }
    }
}