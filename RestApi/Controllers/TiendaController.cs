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
    public class TiendaController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Tienda/ComprarItemTienda")]
        public ResComprarItem ComprarItemTienda(ReqComprarItem req)
        {
            return new LogicaTienda().ComprarItemTienda(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Tienda/IngresarItem")]
        public ResIngresarItem IngresdarItem(ReqIngresarItem req)
        {
            return new LogicaTienda().IngresdarItem(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Tienda/ObtenerCompras")]
        public ResObtenerCompras ObtenerCompras(ReqObtenerCompras req)
        {
            return new LogicaTienda().ObtenerCompras(req);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Tienda/ObtenerItemsTienda")]
        public ResObtenerItemsTienda ObtenerItemsTienda(ReqObtenerItemsTienda req)
        {
            return new LogicaTienda().ObtenerItemsTienda(req);
        }
    }
}