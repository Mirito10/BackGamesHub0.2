using AccesoDatos.AccesoDatosLinq;
using Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.CapaLogica
{
    public class LogicaJuegos
    {
        public ResCerrarPartidaIndividual CerrarPartidaIndividual(ReqCerrarJuegoIndividual req)
        {
            ResCerrarPartidaIndividual Res = new ResCerrarPartidaIndividual();
            Res.errores = new List<Errores>();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req nulo" } });
                }
                else if (req.partida.partidaId == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Id de la partida es nulo" } });
                }
                else if (string.IsNullOrEmpty(req.partida.Token))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Token Nulo" } });
                }
                else if (req.partida.puntajeObtenido == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Puntaje obtenido nulo" } });
                }
                else
                {
                    int? idBD = 0;
                    int? idErrorBD = 0;
                    string errorDescripcionBD = "";

                    ConexionDataContext LinqCerrarJuegoIndividual = new ConexionDataContext();
                    LinqCerrarJuegoIndividual.SP_CERRAR_JUEGO_INDIVIDUAL_POR_TOKEN(req.partida.partidaId, req.partida.Token, req.partida.puntajeObtenido, ref idBD, ref idErrorBD, ref errorDescripcionBD);

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

        //public ResCerrarPartidaMultijugador CerrarPartidaMultijugador(ReqCerrarPartidaMultijugador req)
        //{
        //    ResCerrarPartidaMultijugador Res = new ResCerrarPartidaMultijugador();
        //    Res.errores = new List<Errores>();

        //    try
        //    {
        //        if (req == null)
        //        {
        //            Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req nulo" } });
        //        }
        //        else if (req.cerrarPartidaMultijugador.partidaId == null)
        //        {
        //            Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Id de la partida es nulo" } });
        //        }
        //        else if (req.cerrarPartidaMultijugador.puntajesPartidaMultijugador == null)
        //        {
        //            Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Puntajes Nulos" } });
        //        }
        //        else
        //        {
        //            string puntajesCSV = string.Join(";", req.cerrarPartidaMultijugador.puntajesPartidaMultijugador.Select(p => $"{p.usuarioId},{p.puntaje}"));


        //            int? idBD = 0;
        //            int? idErrorBD = 0;
        //            string errorDescripcionBD = "";

        //            ConexionDataContext LinqCerrarPartidaMultijugador = new ConexionDataContext();
        //            LinqCerrarPartidaMultijugador.SP_CERRAR_PARTIDA_MULTIJUGADOR_CSV(req.cerrarPartidaMultijugador.partidaId, req.cerrarPartidaMultijugador.puntajesPartidaMultijugador, ref idBD, ref idErrorBD, ref errorDescripcionBD);
        //        }
        //    }catch (Exception ex)
        //    {
        //        Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { ex.Message } });
        //    }
        //    return Res;
        //}//error aqui

        public ResGenerarPartidaIA GenerarPartidaIA (ReqGenerarPartidaIA req)
        {
            ResGenerarPartidaIA Res = new ResGenerarPartidaIA();
            Res.errores = new List<Errores>();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.partidaIA.Token))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Token Nulo" } });
                }
                else if (req.partidaIA.JuegoId == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Id del juego es Nulo" } });
                }
                else
                {
                    int? PartidaID = 0;
                    int? PartidaUID = 0;
                    int? idBD = 0;
                    int? idErrorBD = 0;
                    string errorDescripcionBD = "";

                    ConexionDataContext LinqGenerarPartidaIA = new ConexionDataContext();
                    LinqGenerarPartidaIA.SP_GUARDAR_PARTIDA_IA(req.partidaIA.Token, req.partidaIA.JuegoId, req.partidaIA.InstruccionesIniciales,
                        req.partidaIA.ContextoJuego, req.partidaIA.NarrativaFondo, req.partidaIA.EstadoMental, req.partidaIA.Configuracion,
                        ref PartidaID, ref PartidaUID, ref idBD, ref idErrorBD, ref errorDescripcionBD);

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
        }//verificar a fondo sp que que recibe y da datos a la vez

        public ResGenerarPartida GenerarPartida (ReqGenerarPartida req)
        {
            ResGenerarPartida Res = new ResGenerarPartida();
            Res.errores = new List<Errores>();
            try
            {
                if(req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.partidaIndividual.Token))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Token Nulo" } });
                }
                else if (req.partidaIndividual.JuegoId == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Id del juego Nulo" } });
                }
                else
                {
                    int? PartidaID = 0;
                    int? PartidaUID = 0;
                    int? idBD = 0;
                    int? idErrorBD = 0;
                    string errorDescripcionBD = "";

                    ConexionDataContext LinqGenerarPartida = new ConexionDataContext();
                    LinqGenerarPartida.SP_GUARDAR_PARTIDA_INDIVIDUAL(req.partidaIndividual.Token, req.partidaIndividual.JuegoId, ref PartidaID, ref PartidaUID, ref idBD, ref idErrorBD, ref errorDescripcionBD);

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
        }//verificar a fondo

        public ResIngresarJuego IngresarJuego (ReqIngresarJuego req)
        {
            ResIngresarJuego Res = new ResIngresarJuego();
            Res.errores = new List<Errores>();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.Juego.nombreJuego))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El nombre del juego es Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.Juego.tipoJuego))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El tipo de juego esta Nulo" } });
                }
                else
                {
                    int? juegoId = 0;
                    int? idBD = 0;
                    int? idErrorBD = 0;
                    string errorDescripcionBD = "";

                    ConexionDataContext LinqIngresarJuego = new ConexionDataContext();
                    LinqIngresarJuego.SP_INGRESAR_JUEGO(req.Juego.nombreJuego, req.Juego.tipoJuego, ref juegoId, ref idBD, 
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
            }catch (Exception ex)
            {
                Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { ex.Message } });
            }
            return Res;
        }//verificar a fondo

        public ResIniciarPartidaMulitjugador IniciarPartidaMulitjugador (ReqIniciarPartidaMultijugador req)
        {
            ResIniciarPartidaMulitjugador Res = new ResIniciarPartidaMulitjugador();
            Res.errores = new List<Errores>();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.partida.Token))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El token es Nulo" } });
                }
                else if (req.partida.JuegoId == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El id del juego es Nulo" } });
                }
                else
                {
                    int? PartidaId = 0;
                    int? PartidaUID = 0;
                    int? idBD = 0;
                    int? idErrorBD = 0;
                    string errorDescripcionBD = "";

                    ConexionDataContext LinqIniciarPartidaMultijugador = new ConexionDataContext();
                    LinqIniciarPartidaMultijugador.SP_INICIAR_PARTIDA_MULTIJUGADOR(req.partida.Token, req.partida.JuegoId,
                        ref PartidaId, ref PartidaUID, ref idBD, ref idErrorBD, ref errorDescripcionBD);

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
        }//verificar a fondo

        public ResObtenerJuegos ObtenerJuegos (ReqObtenerJuegos req)
        {
            ResObtenerJuegos Res = new ResObtenerJuegos();
            Res.errores = new List<Errores>();

            try
            {
                ConexionDataContext LinqObtenerJuegos = new ConexionDataContext();
                List<SP_OBTENER_JUEGOSResult> ListaObtenerJuegos = new List<SP_OBTENER_JUEGOSResult> ();
                ListaObtenerJuegos = LinqObtenerJuegos.SP_OBTENER_JUEGOS().ToList();
                foreach(SP_OBTENER_JUEGOSResult unTipo in ListaObtenerJuegos)
                {
                    Res.ObtenerJuegos.Add(this.factoriaObtenerJuegos(unTipo));
                }
                Res.errores.Add(new Errores { Respuesta = true });
            }
            catch (Exception ex)
            {
                Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { ex.Message } });
            }
            return Res;
        }

        public ResUnirseMultijugador UnirsePartidaMultijugador(ReqUnirseMultijugador req)
        {
            ResUnirseMultijugador Res = new ResUnirseMultijugador();
            Res.errores = new List<Errores> ();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.UnirseMultijugador.token))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Token Nulo" } });
                }
                else if (req.UnirseMultijugador.PartidaUID == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "UID de la partida es Nulo" } });
                }
                else
                {
                    int? idBD = 0;
                    int? idErrorBD = 0;
                    string errorDescripcionBD = "";

                    ConexionDataContext LinqUnirsePartida = new ConexionDataContext();
                    LinqUnirsePartida.SP_UNIRSE_PARTIDA_MULTIJUGADOR_UID(req.UnirseMultijugador.token, req.UnirseMultijugador.PartidaUID,
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
            catch (Exception ex)
            {
                Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { ex.Message } });
            }
            return Res;
        }

        private Juego factoriaObtenerJuegos (SP_OBTENER_JUEGOSResult tipoComplejoObtenerJuegos)
        {
            Juego retornarJuegos = new Juego();

            retornarJuegos.juegoId = tipoComplejoObtenerJuegos.JUEGO_ID;
            retornarJuegos.nombreJuego = tipoComplejoObtenerJuegos.NOMBRE_JUEGO;
            retornarJuegos.tipoJuego = tipoComplejoObtenerJuegos.TIPO_JUEGO;

            return retornarJuegos;
        }
    }
}
