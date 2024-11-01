using AccesoDatos.AccesoDatosLinq;
using Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.CapaLogica
{
    public class LogicaMensajes
    {
        public ResEnviarMensaje EnviarMensaje (ReqEnviarMensajes req)
        {
            ResEnviarMensaje Res = new ResEnviarMensaje ();
            Res.errores = new List<Errores> ();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.mensaje.Token))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Token Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.mensaje.ReceptorUID))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "UID del receptor es Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.mensaje.Mensaje))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Mensaje Nulo" } });
                }
                else
                {
                    int? idBD = 0;
                    int? idErrorBD = 0;
                    string errorDescripcionBD = "";

                    ConexionDataContext LinqEnviarMensaje = new ConexionDataContext();
                    LinqEnviarMensaje.SP_ENVIAR_MENSAJE(req.mensaje.Token, req.mensaje.ReceptorUID, req.mensaje.Mensaje, ref idBD, ref idErrorBD, ref errorDescripcionBD);

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

        public ResMarcarMensajes MarcarMensajes (ReqMarcarMensajes req)
        {
            ResMarcarMensajes Res = new ResMarcarMensajes();
            Res.errores = new List<Errores>();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.mensajes.Token))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Token Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.mensajes.ReceptorUID))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El UID del amigo es Nulo" } });
                }
                else
                {
                    int? idBD = 0;
                    int? idErrorBD = 0;
                    string errorDescripcionBD = "";

                    ConexionDataContext LinqMarcarMensajes = new ConexionDataContext();
                    LinqMarcarMensajes.SP_MARCAR_MENSAJES_LEIDOS(req.mensajes.Token, req.mensajes.ReceptorUID, ref idBD, 
                        ref idErrorBD, ref errorDescripcionBD);

                    if (idBD <= 0 || idBD == null)
                    {
                        Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { errorDescripcionBD } });
                    }
                    else
                    {
                        Res.errores.Add(new Errores { Respuesta = true });
                    }
                }
            }catch(Exception ex)
            {
                Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { ex.Message } });
            }
            return Res;
        }

        public ResRecuperarMensajes RecuperarMensajes (ReqRecuperarMensajes req)
        {
            ResRecuperarMensajes Res = new ResRecuperarMensajes();
            Res.errores = new List<Errores>();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.recuperarMensajes.Token))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El token es Nulo" } });
                }
                else if (req.recuperarMensajes.ReceptorUID == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El UID del amigo es Nulo" } });
                }
                else
                {
                    int? idBD = 0;
                    int? idErrorBD = 0;
                    string errorDescripcionBD = "";

                    ConexionDataContext LinqRecuperarMensajes = new ConexionDataContext();
                    LinqRecuperarMensajes.SP_RECUPERAR_MENSAJES(req.recuperarMensajes.Token, req.recuperarMensajes.ReceptorUID,
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
            }
            catch(Exception ex)
            {
                Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { ex.Message } });
            }
            return Res;
        }
    }
}
