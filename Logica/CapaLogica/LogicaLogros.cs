using AccesoDatos.AccesoDatosLinq;
using Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Logica.CapaLogica
{
    public class LogicaLogros
    {
        public ResDesbloquearLogros DesbloquearLogros (ReqDesbloquearLogros req)
        {
            ResDesbloquearLogros Res = new ResDesbloquearLogros ();
            Res.errores = new List<Errores> ();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.logros.Token))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Token Nulo" } });
                }
                else if (req.logros.LogroId == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Id del logro es nulo" } });
                }
                else if (req.logros.CriterioValor == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El criterio valor es nulo" } });
                }
                else
                {
                    int? idBD = 0;
                    int? idErrorBD = 0;
                    string errorDescripcion = "";

                    ConexionDataContext LinqDesbloquearLogro = new ConexionDataContext ();
                    LinqDesbloquearLogro.SP_DESBLOQUEAR_LOGRO_POR_TOKEN(req.logros.Token, req.logros.LogroId, req.logros.CriterioValor, ref idBD, ref idErrorBD, ref errorDescripcion);

                    if (idBD <= 0 || idBD == null)
                    {
                        Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { errorDescripcion } });
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

        public ResIngresarLogro IngresarLogro (ReqIngresarLogro req)
        {
            ResIngresarLogro Res = new ResIngresarLogro ();
            Res.errores = new List<Errores>();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.Logros.nombreLogro))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El nombre del logro es Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.Logros.descripcion))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "La descripcion del logro es Nulo" } });
                }
                else if (req.Logros.juegoId == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El id del juego es Nulo" } });
                }
                else if (req.Logros.puntosOtorgador == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Los puntos otorgados es Nulo" } });
                }
                else if (req.Logros.CriterioValor == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El criterio valor es Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.Logros.criterioDesbloqueo))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El valor criterio es Nulo" } });
                }
                else if (req.Logros.usuarioId == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El id del usuario es Nulo" } });
                }
                else
                {
                    int? idBD = 0;
                    int? idErrorBD = 0;
                    string errorDescripcionBD = "";

                    ConexionDataContext LinqIngresarLogro = new ConexionDataContext();
                    LinqIngresarLogro.SP_INGRESAR_LOGRO(req.Logros.nombreLogro, req.Logros.descripcion, req.Logros.juegoId,
                        req.Logros.puntosOtorgador, req.Logros.criterioDesbloqueo, req.Logros.CriterioValor, req.Logros.usuarioId,
                        ref idBD, ref idErrorBD, ref errorDescripcionBD);

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

        public ResObtenerLogrosBloqueados ObtenerLogrosBloqueados (ReqObtenerLogrosBloqueados req)
        {
            ResObtenerLogrosBloqueados Res = new ResObtenerLogrosBloqueados();
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
                    ConexionDataContext LinqObtenerLogrosBloqueados = new ConexionDataContext();
                    List<SP_OBTENER_LOGROS_BLOQUEADOSResult> ListaObtenerLogrosBloqueados = new List<SP_OBTENER_LOGROS_BLOQUEADOSResult>();
                    ListaObtenerLogrosBloqueados = LinqObtenerLogrosBloqueados.SP_OBTENER_LOGROS_BLOQUEADOS(req.token.Token).ToList();
                    foreach (SP_OBTENER_LOGROS_BLOQUEADOSResult unaTipo in ListaObtenerLogrosBloqueados)
                    {
                        Res.ObtenerLogrosBloqueados.Add(this.factoriaLogrosBloqueados(unaTipo));
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

        public ResObtenerLogrosDesbloqueados ObtenerLogrosDesbloqueados (ReqObtenerLogrosDesbloqueados req)
        {
            ResObtenerLogrosDesbloqueados Res = new ResObtenerLogrosDesbloqueados();
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
                    ConexionDataContext LinqObtenerLogrosDesbloqueados = new ConexionDataContext();
                    List<SP_OBTENER_LOGROS_DESBLOQUEADOSResult> ListaObtenerLogrosDesbloqueados = new List<SP_OBTENER_LOGROS_DESBLOQUEADOSResult>();
                    ListaObtenerLogrosDesbloqueados = LinqObtenerLogrosDesbloqueados.SP_OBTENER_LOGROS_DESBLOQUEADOS(req.token.Token).ToList();
                    foreach (SP_OBTENER_LOGROS_DESBLOQUEADOSResult unTipo in ListaObtenerLogrosDesbloqueados)
                    {
                        Res.obtenerLogrosDesbloqueados.Add(this.factoriaLogrosDesbloqueados(unTipo));
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

        private Logros factoriaLogrosBloqueados (SP_OBTENER_LOGROS_BLOQUEADOSResult tipoComplejoLogrosBloqueados)
        {
            Logros retornarLogrosBloqueados = new Logros();

            retornarLogrosBloqueados.LogroId = tipoComplejoLogrosBloqueados.LOGRO_ID;
            retornarLogrosBloqueados.descripcion = tipoComplejoLogrosBloqueados.DESCRIPCION;
            retornarLogrosBloqueados.juegoId = tipoComplejoLogrosBloqueados.JUEGO_ID;
            retornarLogrosBloqueados.criterioDesbloqueo = tipoComplejoLogrosBloqueados.CRITERIO_DESBLOQUEO;
            retornarLogrosBloqueados.CriterioValor = tipoComplejoLogrosBloqueados.VALOR_CRITERIO;

            return retornarLogrosBloqueados;
        }

        private Logros factoriaLogrosDesbloqueados (SP_OBTENER_LOGROS_DESBLOQUEADOSResult tipoComplejoLogrosDesbloqueados)
        {
            Logros retornarLogrosDesbloqueados = new Logros();

            retornarLogrosDesbloqueados.LogroId = tipoComplejoLogrosDesbloqueados.LOGRO_ID;
            retornarLogrosDesbloqueados.descripcion = tipoComplejoLogrosDesbloqueados.DESCRIPCION;
            retornarLogrosDesbloqueados.juegoId = tipoComplejoLogrosDesbloqueados.JUEGO_ID;

            return retornarLogrosDesbloqueados;
        }
    }
}
