using AccesoDatos.AccesoDatosLinq;
using Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.CapaLogica
{
    public class LogicaTienda
    {
        public ResComprarItem ComprarItemTienda (ReqComprarItem req)
        {
            ResComprarItem Res = new ResComprarItem ();
            Res.errores = new List<Errores> ();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req nulo" } });
                }
                else if (string.IsNullOrEmpty(req.tienda.Token))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Token Faltante" } });
                }
                else if (req.tienda.ObjetoId == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Id del objeto a comprar Faltante" } });
                }
                else
                {
                    int? idBD = 0;
                    int? idErrorBD = 0;
                    string errorDescripcionBD = "";

                    ConexionDataContext LinqComprarItem = new ConexionDataContext ();
                    LinqComprarItem.SP_COMPRAR_ITEM_TIENDA(req.tienda.Token, req.tienda.ObjetoId, ref idBD, ref idErrorBD, ref errorDescripcionBD);

                    if (idBD <= 0 || idBD == null)
                    {
                        Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { errorDescripcionBD } });
                    }
                    else
                    {
                        Res.errores.Add(new Errores { Respuesta = true });
                    }
                }
            }catch (Exception ex)
            {
                Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { ex.Message } });
            }
            return Res;
        }

        public ResIngresarItem IngresdarItem (ReqIngresarItem req)
        {
            ResIngresarItem Res = new ResIngresarItem ();
            Res.errores = new List<Errores> ();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.ingresarItems.nombreObjeto))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El nombre del item es Nulo" } });
                }
                else if (req.ingresarItems.precioPuntos == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El precio del item es Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.ingresarItems.descripcion))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "La descripcion del item es Nula" } });
                }
                else
                {
                    int? idBD = 0;
                    int? idErrorBD = 0;
                    string errorDescripcionBD = "";

                    ConexionDataContext LinqIngresarItem = new ConexionDataContext();
                    LinqIngresarItem.SP_INGRESAR_ITEM_TIENDA(req.ingresarItems.nombreObjeto, req.ingresarItems.precioPuntos, 
                        req.ingresarItems.descripcion, ref idBD, ref idErrorBD, ref errorDescripcionBD);

                    if (idBD <= 0 || idBD == null)
                    {
                        Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { errorDescripcionBD } });
                    }
                    else
                    {
                        Res.errores.Add(new Errores { Respuesta = true });
                    }
                }
            }catch (Exception ex)
            {
                Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { ex.Message } });
            }
            return Res;
        }

        public ResObtenerCompras ObtenerCompras (ReqObtenerCompras req)
        {
            ResObtenerCompras Res = new ResObtenerCompras();
            Res.errores = new List<Errores>();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req nulo" } });
                }
                else if (string.IsNullOrEmpty(req.token.Token))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Token nulo" } });
                }
                else
                {
                    ConexionDataContext LinqObtenerCompras = new ConexionDataContext();
                    List<SP_OBTENER_COMPRAS_USUARIOResult> ListaObtenerCompras = new List<SP_OBTENER_COMPRAS_USUARIOResult>();
                    ListaObtenerCompras = LinqObtenerCompras.SP_OBTENER_COMPRAS_USUARIO(req.token.Token).ToList();
                    foreach (SP_OBTENER_COMPRAS_USUARIOResult unTipo in ListaObtenerCompras)
                    {
                        Res.Compra.Add(this.factoriaObtenerCompras(unTipo));
                    }
                    Res.errores.Add(new Errores { Respuesta = true });
                }
            }
            catch (Exception ex)
            {
                Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { ex.Message } });
            }
            return Res;
        }

        public ResObtenerItemsTienda ObtenerItemsTienda (ReqObtenerItemsTienda req)
        {
            ResObtenerItemsTienda Res = new ResObtenerItemsTienda();
            Res.errores = new List<Errores>();

            try
            {
                ConexionDataContext LinqObtenerItemsTienda = new ConexionDataContext();
                List<SP_OBTENER_ITEMS_TIENDAResult> ListaObtenerItemsTienda = new List<SP_OBTENER_ITEMS_TIENDAResult>();
                ListaObtenerItemsTienda = LinqObtenerItemsTienda.SP_OBTENER_ITEMS_TIENDA().ToList();
                foreach(SP_OBTENER_ITEMS_TIENDAResult unTipo in ListaObtenerItemsTienda)
                {
                    Res.ItemsTiendas.Add(this.factoriaObtenerItemsTienda(unTipo));
                }
                Res.errores.Add(new Errores { Respuesta = true });
            }
            catch (Exception ex)
            {
                Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { ex.Message } });
            }
            return Res;
        }

        private Compra factoriaObtenerCompras (SP_OBTENER_COMPRAS_USUARIOResult tipoComplejoObtenerCompras)
        {
            Compra retornarCompras = new Compra();

            retornarCompras.compraId = tipoComplejoObtenerCompras.COMPRA_ID;
            retornarCompras.nombreObjeto = tipoComplejoObtenerCompras.NOMBRE_OBJETO;

            return retornarCompras;
        }

        private ItemsTienda factoriaObtenerItemsTienda (SP_OBTENER_ITEMS_TIENDAResult tipoComplejoObtenerItemsTienda)
        {
            ItemsTienda retornarItemsTienda = new ItemsTienda();

            retornarItemsTienda.objetoId = tipoComplejoObtenerItemsTienda.OBJETO_ID;
            retornarItemsTienda.nombreObjeto = tipoComplejoObtenerItemsTienda.NOMBRE_OBJETO;
            retornarItemsTienda.precioPuntos = tipoComplejoObtenerItemsTienda.PRECIO_PUNTOS;
            retornarItemsTienda.descripcion = tipoComplejoObtenerItemsTienda.DESCRIPCION;

            return retornarItemsTienda;
        }
    }
}
