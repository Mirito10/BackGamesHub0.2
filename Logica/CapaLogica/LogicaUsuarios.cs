using AccesoDatos.AccesoDatosLinq;
using Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.CapaLogica
{
    public class LogicaUsuarios
    {
        public ResCrearUsuario Crear (ReqCrearUsuario req) 
        {
            ResCrearUsuario Res = new ResCrearUsuario();
            Res.errores = new List<Errores>();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req nulo" } });
                }
                else if (string.IsNullOrEmpty(req.usuario.Nombre_Usuario))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Nombre Faltante" } });
                }
                else if (string.IsNullOrEmpty(req.usuario.Email))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Email Faltante" } });
                }
                else if (string.IsNullOrEmpty(req.usuario.Password))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Contraseña Faltante" } });
                }
                else
                {
                    int? idBD = 0;
                    int? idErrorBD = 0;
                    string errorDescripcionBD = "";

                    ConexionDataContext LinqCrearUsuario = new ConexionDataContext();
                    LinqCrearUsuario.SP_CREAR_USUARIO(req.usuario.Nombre_Usuario, req.usuario.Email, req.usuario.Password, ref idBD, ref idErrorBD, ref errorDescripcionBD);

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

        public ResCerrarSesion CerrarSesion (ReqCerrarSesion req)
        {
            ResCerrarSesion Res = new ResCerrarSesion();
            Res.errores = new List<Errores>();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.Token.Token))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Token Nulo" } });
                }
                else
                {
                    int? idBD = 0;
                    int? idErrorBD = 0;
                    string errorDescripcionBD = "";

                    ConexionDataContext LinqCerrarSesion = new ConexionDataContext();
                    LinqCerrarSesion.SP_CERRAR_SESION_CON_TOKEN(req.Token.Token, ref idBD, ref idErrorBD, ref errorDescripcionBD);

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

        public ResEditarUsuario EditarUsuario (ReqEditarUsuario req)
        {
            ResEditarUsuario Res = new ResEditarUsuario();
            Res.errores = new List<Errores>();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.editarUsuario.Token))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Token Nulo" } });
                }
                else
                {
                    int? idBD = 0;
                    int? idErrorBD = 0;
                    string errorDescripcionBD = "";

                    ConexionDataContext LinqEditarUsuario = new ConexionDataContext();
                    LinqEditarUsuario.SP_EDITAR_USUARIO2(req.editarUsuario.Token, req.editarUsuario.NuevoNombre, req.editarUsuario.NuevoEmail, ref idBD, ref idErrorBD, ref errorDescripcionBD);

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

        public ResIniciarSesion IniciarSesion (ReqIniciarSesion req)
        {
            ResIniciarSesion Res = new ResIniciarSesion();
            Res.errores = new List<Errores>();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.sesion.emial))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Email es Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.sesion.password))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "La contraseña es Nula" } });
                }
                else if (string.IsNullOrEmpty(req.IpAddres))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "La ip es Nula" } });
                }
                else
                {
                    int? idBD = 0;
                    string token = "";
                    int? idErrorBD = 0;
                    string errorDescripcionBD = "";

                    ConexionDataContext LinqIniciarSesion = new ConexionDataContext();
                    LinqIniciarSesion.SP_INICIAR_SESION(req.sesion.emial, req.sesion.password, req.IpAddres, ref idBD, ref token,
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
        }//verificar a fondo

        public ResObtenerNotificaciones ObtenerNotificaciones (ReqObtenerNotificaciones req)
        {
            ResObtenerNotificaciones Res = new ResObtenerNotificaciones();
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
                    ConexionDataContext LinqObtenerNotificaciones = new ConexionDataContext();
                    List<SP_OBTENER_NOTIFICACIONES_USUARIOResult> ListaObtenerNotificaciones = new List<SP_OBTENER_NOTIFICACIONES_USUARIOResult>();
                    ListaObtenerNotificaciones = LinqObtenerNotificaciones.SP_OBTENER_NOTIFICACIONES_USUARIO(req.token.Token).ToList();
                    foreach (SP_OBTENER_NOTIFICACIONES_USUARIOResult unTipo in ListaObtenerNotificaciones)
                    {
                        Res.obtenerNotificaciones.Add(this.factoriaNotificaciones(unTipo));
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

        public ResObtenerPuntaje ObtenerPuntaje (ReqObtenerPuntaje req)
        {
            ResObtenerPuntaje Res = new ResObtenerPuntaje();
            Res.errores = new List<Errores>();

            try
            {
                ConexionDataContext LinqObtenerPuntaje = new ConexionDataContext();
                List<SP_OBTENER_PUNTAJE_TOTAL_USUARIOSResult> ListaObtenerPuntaje = new List<SP_OBTENER_PUNTAJE_TOTAL_USUARIOSResult>();
                ListaObtenerPuntaje = LinqObtenerPuntaje.SP_OBTENER_PUNTAJE_TOTAL_USUARIOS().ToList();
                foreach (SP_OBTENER_PUNTAJE_TOTAL_USUARIOSResult unTipo in ListaObtenerPuntaje)
                {
                    Res.obtenerPuntaje.Add(this.factoriaPuntaje(unTipo));
                }
                Res.errores.Add(new Errores { Respuesta = true });
            }
            catch (Exception ex)
            {
                Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { ex.Message } });
            }
            return Res;
        }

        public ResObtenerSanciones ObtenerSanciones (ReqObtenerSanciones req)
        {
            ResObtenerSanciones Res = new ResObtenerSanciones();
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
                    ConexionDataContext LinqObtenerSanciones = new ConexionDataContext();
                    List<SP_OBTENER_SANCIONESResult> listaObtenerSanciones = new List<SP_OBTENER_SANCIONESResult> ();
                    listaObtenerSanciones = LinqObtenerSanciones.SP_OBTENER_SANCIONES(req.token.Token).ToList();
                    foreach (SP_OBTENER_SANCIONESResult unTipo in listaObtenerSanciones)
                    {
                        Res.Sanciones.Add(this.factoriaSanciones(unTipo));
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

        private Notificaciones factoriaNotificaciones (SP_OBTENER_NOTIFICACIONES_USUARIOResult tipoComplejoNotificaciones)
        {
            Notificaciones retornarNotificaciones = new Notificaciones();

            retornarNotificaciones.tipoNotificacion = tipoComplejoNotificaciones.TIPO_NOTIFICACION;
            retornarNotificaciones.mensaje = tipoComplejoNotificaciones.MENSAJE;

            return retornarNotificaciones;
        }

        private PuntajeMultijugador factoriaPuntaje (SP_OBTENER_PUNTAJE_TOTAL_USUARIOSResult tipoComplejoPunataje)
        {
            PuntajeMultijugador retornarPuntaje = new PuntajeMultijugador();

            retornarPuntaje.usuarioId = tipoComplejoPunataje.USUARIO_ID;
            retornarPuntaje.puntaje = tipoComplejoPunataje.PUNTAJE_TOTAL;

            return retornarPuntaje;
        }

        private Sanciones factoriaSanciones (SP_OBTENER_SANCIONESResult tipoComplejoSanciones)
        {
            Sanciones retornarSanciones = new Sanciones();

            retornarSanciones.mensajeSancion = tipoComplejoSanciones.MENSAJE;

            return retornarSanciones;
        }
    }
}
