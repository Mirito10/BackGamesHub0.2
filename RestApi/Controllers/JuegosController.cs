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
    public class JuegosController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Juegos/CerrarPartidaIndividual")]
        public ResCerrarPartidaIndividual CerrarPartidaIndividual(ReqCerrarJuegoIndividual req)
        {
            return new LogicaJuegos().CerrarPartidaIndividual(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Juegos/GenerarPartidaIA")]
        public ResGenerarPartidaIA GenerarPartidaIA(ReqGenerarPartidaIA req)
        {
            return new LogicaJuegos().GenerarPartidaIA(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Juegos/GenerarPartida")]
        public ResGenerarPartida GenerarPartida(ReqGenerarPartida req)
        {
            return new LogicaJuegos().GenerarPartida(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Juegos/IngresarJuego")]
        public ResIngresarJuego IngresarJuego(ReqIngresarJuego req)
        {
            return new LogicaJuegos().IngresarJuego(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Juegos/IniciarPartidaMulitjugador")]
        public ResIniciarPartidaMulitjugador IniciarPartidaMulitjugador(ReqIniciarPartidaMultijugador req)
        {
            return new LogicaJuegos().IniciarPartidaMulitjugador(req);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Juegos/ObtenerJuegos")]
        public ResObtenerJuegos ObtenerJuegos(ReqObtenerJuegos req)
        {
            return new LogicaJuegos().ObtenerJuegos(req);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Juegos/UnirsePartidaMultijugador")]
        public ResUnirseMultijugador UnirsePartidaMultijugador(ReqUnirseMultijugador req)
        {
            return new LogicaJuegos().UnirsePartidaMultijugador(req);
        }
    }
}