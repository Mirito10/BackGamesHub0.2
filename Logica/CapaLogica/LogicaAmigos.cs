using AccesoDatos.AccesoDatosLinq;
using Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.CapaLogica
{
    public class LogicaAmigos
    {
        public ResObtenerAmigos ObtenerAmigos(ReqObtenerAmigos req)
        {
            ResObtenerAmigos Res = new ResObtenerAmigos();
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
                else;
                {
                    ConexionDataContext LinqObtenerAmigos = new ConexionDataContext();
                    List<SP_OBTENER_AMIGOSResult> miListaTipoComplejo = new List<SP_OBTENER_AMIGOSResult>();
                    miListaTipoComplejo = LinqObtenerAmigos.SP_OBTENER_AMIGOS(req.token.Token).ToList();
                    foreach (SP_OBTENER_AMIGOSResult unTipo in miListaTipoComplejo)
                    {
                        Res.amigos.Add(this.factoriaAmigos(unTipo));
                    }
                    Res.errores.Add(new Errores { Respuesta = true });
                }
            }catch (Exception ex)
            {
                Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { ex.Message } });
            }

            return Res;
        }

        public ResElimiarAmigos EliminarAmigos (ReqEliminarAmigos req)
        {
            ResElimiarAmigos Res = new ResElimiarAmigos();
            Res.errores = new List<Errores>();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.eliminarAmigo.Token))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Token Nulo" } });
                }
                else if (req.eliminarAmigo.AmigoUID == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "UID del amigo es Nulo" } });
                }
                else
                {
                    int? idBD = 0;
                    int? idErrorBD = 0;
                    string errorDescripcionBD = "";

                    ConexionDataContext LinqEliminarAmigo = new ConexionDataContext();
                    LinqEliminarAmigo.SP_ELIMINAR_AMIGO(req.eliminarAmigo.Token, req.eliminarAmigo.AmigoUID, ref idBD, ref idErrorBD, ref errorDescripcionBD);

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

        public ResEnviarSolicitud EnviarSolicitud (ReqEnviarSolicitud req)
        {
            ResEnviarSolicitud Res = new ResEnviarSolicitud();
            Res.errores = new List<Errores>();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.EnviarSolicitud.Token))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Token Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.EnviarSolicitud.AmigoUID))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "UID del amigo Nulo" } });
                }
                else
                {
                    int? idBD = 0;
                    int? idErrorBD = 0;
                    string errorDescripcionBD = "";

                    ConexionDataContext LinqEnviarSolicitud = new ConexionDataContext();
                    LinqEnviarSolicitud.SP_ENVIAR_SOLICITUD_AMISTAD(req.EnviarSolicitud.Token, req.EnviarSolicitud.AmigoUID, ref idBD, ref idErrorBD, ref errorDescripcionBD);

                    if (idBD <= 0 || idBD == null)
                    {
                        Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { errorDescripcionBD } });
                    }
                    else
                    {
                        Res.errores.Add(new Errores { Respuesta = true });
                    }
                }
            }
            catch (Exception ex)
            {
                Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { ex.Message } });
            }

            return Res;
        }

        public ResObtenerEstadoSolicitud ObtenerEstadoSolicitud (ReqObtenerEstadoSolicitud req)
        {
            ResObtenerEstadoSolicitud Res = new ResObtenerEstadoSolicitud();
            Res.errores = new List<Errores>();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req nulo" } });
                }
                else if (string.IsNullOrEmpty(req.obtenerSolicitudes.Token))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Token nulo" } });
                }
                else if (req.obtenerSolicitudes.solicitudId == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El id de la solicitud es nulo" } });
                }
                else
                {
                    ConexionDataContext LinqObtenerEstadoSolicitud = new ConexionDataContext();
                    List<SP_OBTENER_ESTADO_SOLICITUD_AMISTADResult> ListaObtenerEstadoSolicitud = new List<SP_OBTENER_ESTADO_SOLICITUD_AMISTADResult>();
                    ListaObtenerEstadoSolicitud = LinqObtenerEstadoSolicitud.SP_OBTENER_ESTADO_SOLICITUD_AMISTAD(req.obtenerSolicitudes.Token,
                        req.obtenerSolicitudes.solicitudId).ToList();
                    foreach(SP_OBTENER_ESTADO_SOLICITUD_AMISTADResult unTipo in ListaObtenerEstadoSolicitud)
                    {
                        Res.estadoSolicitud.Add(this.factoriaObtenerEstadoSolicitud(unTipo));
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

        public ResObtenerSolicitudesPendientes SolicitudesPendientes (ReqObtenerSolicitudesPendientes req)
        {
            ResObtenerSolicitudesPendientes Res = new ResObtenerSolicitudesPendientes();
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
                    ConexionDataContext LinqSolicitudesPendientes = new ConexionDataContext();
                    List<SP_OBTENER_SOLICITUDES_AMISTAD_PENDIENTESResult> listaSolicitudesPendientes = new List<SP_OBTENER_SOLICITUDES_AMISTAD_PENDIENTESResult>();
                    listaSolicitudesPendientes = LinqSolicitudesPendientes.SP_OBTENER_SOLICITUDES_AMISTAD_PENDIENTES(req.token.Token).ToList();
                    foreach (SP_OBTENER_SOLICITUDES_AMISTAD_PENDIENTESResult unTipo in listaSolicitudesPendientes)
                    {
                        Res.obtenerSolicitudesPendentes.Add(this.factoriaSolicitudesPendientes(unTipo));
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

        public ResAceptarSolicitudesAmistad AceptarSolicitudes(ReqAceptarSolicitudAmistad req)
        {
            ResAceptarSolicitudesAmistad Res = new ResAceptarSolicitudesAmistad();
            Res.errores = new List<Errores>();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req Nulo" } });
                }
                else if (req.aceptarSolicitud.solicitudId == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Id de la solicitud es nulo" } });
                }
                else if (string.IsNullOrEmpty(req.aceptarSolicitud.Token))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Token Nulo" } });
                }
                else
                {
                    int? idBD = 0;
                    int? idErrorBD = 0;
                    string errorDescripcionBD = "";

                    ConexionDataContext LinqAceptarSolicitudes = new ConexionDataContext();
                    LinqAceptarSolicitudes.SP_ACEPTAR_SOLICITUD_AMISTAD(req.aceptarSolicitud.solicitudId, req.aceptarSolicitud.Token, ref idBD, ref idErrorBD, ref errorDescripcionBD);

                    if (idBD <= 0 || idBD == null)
                    {
                        Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { errorDescripcionBD } });
                    }
                    else
                    {
                        Res.errores.Add(new Errores { Respuesta = true });
                    }
                }

            }
            catch (Exception ex)
            {
                Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { ex.Message } });
            }

            return Res;
        }

        public ResRechazarSolicitud RecahazrSolicitud (ReqRechazarSolicitud req)
        {
            ResRechazarSolicitud Res = new ResRechazarSolicitud();
            Res.errores = new List<Errores>();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.rechazarSolicitud.Token))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El token es Nulo" } });
                }
                else if (req.rechazarSolicitud.solicitudId == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El id del juego es Nulo" } });
                }
                else
                {
                    int? idBD = 0;

                    ConexionDataContext LinqRecahazarSolicitud = new ConexionDataContext();
                    LinqRecahazarSolicitud.SP_RECHAZAR_SOLICITUD_AMISTAD(req.rechazarSolicitud.Token,
                        req.rechazarSolicitud.solicitudId, ref idBD);

                    if (idBD <= 0 || idBD == null)
                    {
                        Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Error" } });
                    }
                    else
                    {
                        Res.errores.Add(new Errores { Respuesta = true });
                    }
                }
            }
            catch (Exception ex)
            {
                Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { ex.Message } });
            }
            return Res;
        }

        private Amigos factoriaAmigos(SP_OBTENER_AMIGOSResult tipoComplejoObtenerAmigos)
        {
            Amigos retornarAmigos = new Amigos();

            retornarAmigos.UIDAmigo = tipoComplejoObtenerAmigos.AMIGO_ID;
            retornarAmigos.EmailAmigo = tipoComplejoObtenerAmigos.EMAIL;
            retornarAmigos.NombreAmigo = tipoComplejoObtenerAmigos.NOMBRE_USUARIO;

            return retornarAmigos;
        }

        private SolicitudAmigo factoriaObtenerEstadoSolicitud(SP_OBTENER_ESTADO_SOLICITUD_AMISTADResult tipoComplejoObtenerEstadoSolicitud)
        {
            SolicitudAmigo retornarEstadoSolicitud = new SolicitudAmigo();

            retornarEstadoSolicitud.solicitudId = tipoComplejoObtenerEstadoSolicitud.SOLICITUD_ID;
            retornarEstadoSolicitud.Estado = tipoComplejoObtenerEstadoSolicitud.ESTADO;

            return retornarEstadoSolicitud;
        }

        private SolicitudAmigo factoriaSolicitudesPendientes (SP_OBTENER_SOLICITUDES_AMISTAD_PENDIENTESResult tipoComplejoSolicitudes)
        {
            SolicitudAmigo retornarSolicitudes = new SolicitudAmigo();

            retornarSolicitudes.solicitudId = tipoComplejoSolicitudes.SOLICITUD_ID;
            retornarSolicitudes.usuarioEmisorId = tipoComplejoSolicitudes.USUARIO_EMISOR_ID;
            retornarSolicitudes.nombreEmisor = tipoComplejoSolicitudes.NOMBRE_EMISOR;
            retornarSolicitudes.Estado = tipoComplejoSolicitudes.ESTADO;

            return retornarSolicitudes;
        }
    }
}
