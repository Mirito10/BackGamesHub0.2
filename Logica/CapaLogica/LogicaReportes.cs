using AccesoDatos.AccesoDatosLinq;
using Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.CapaLogica
{
    public class LogicaReportes
    {
        public ResReportes ObtenerReportes (ReqReportes req)
        {
            ResReportes Res = new ResReportes ();
            Res.errores = new List<Errores> ();

            try
            {
                ConexionDataContext LinqObtenerReportes = new ConexionDataContext ();
                List<SP_OBTENER_TODOS_LOS_REPORTESResult> listaObtenerReportes = new List<SP_OBTENER_TODOS_LOS_REPORTESResult> ();
                listaObtenerReportes = LinqObtenerReportes.SP_OBTENER_TODOS_LOS_REPORTES().ToList();
                foreach (SP_OBTENER_TODOS_LOS_REPORTESResult unTipo in listaObtenerReportes)
                {
                    Res.reportes.Add(this.factoriaReportes(unTipo));
                }
                Res.errores.Add(new Errores { Respuesta = true });
            }
            catch (Exception ex)
            {
                Res.errores.Add(new Errores { Respuesta = true });
            }
            return Res;
        }

        public ResReportarUsuario ReportarUsuario (ReqReportarUsuario req)
        {
            ResReportarUsuario Res = new ResReportarUsuario ();
            Res.errores = new List<Errores>();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.reportarUsuario.token))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El token es Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.reportarUsuario.ReportadoUID))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El UID del usuario reportado es Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.reportarUsuario.descripcion))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "La descripcion es Nula" } });
                }
                else
                {
                    int? idBD = 0;
                    int? idErrorBD = 0;
                    string errorDescripcionBD = "";

                    ConexionDataContext LinqReportarUsuario = new ConexionDataContext();
                    LinqReportarUsuario.SP_REPORTAR_USUARIO(req.reportarUsuario.token, req.reportarUsuario.ReportadoUID,
                        req.reportarUsuario.descripcion, ref idBD, ref idErrorBD, ref errorDescripcionBD);

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

        public ResSancionar SancionarUsuario (ReqSancionar req)
        {
            ResSancionar Res = new ResSancionar();
            Res.errores = new List<Errores>();

            try
            {
                if (req == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "Req Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.Sancionar.tipoSancion))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El tipo de sancion es Nulo" } });
                }
                else if (req.Sancionar.reporteId == null)
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "El id del reporte es Nulo" } });
                }
                else if (string.IsNullOrEmpty(req.Sancionar.descripcion))
                {
                    Res.errores.Add(new Errores { Respuesta = false, Error = new List<string> { "La descricpion es Nula" } });
                }
                else
                {
                    int? idBD = 0;
                    int? idErrorBD = 0;
                    string errorDescripcionBD = "";

                    ConexionDataContext LinqSancionar = new ConexionDataContext();
                    LinqSancionar.SP_SANCIONAR_USUARIO_REPORTADO(req.Sancionar.reporteId, req.Sancionar.tipoSancion,
                        req.Sancionar.descripcion, req.Sancionar.fechaFin, ref idBD, ref idErrorBD, ref errorDescripcionBD);

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

        private Reportes factoriaReportes (SP_OBTENER_TODOS_LOS_REPORTESResult tipoComplejoReportes)
        {
            Reportes retornarReportes = new Reportes ();

            retornarReportes.reporteId = tipoComplejoReportes.REPORTE_ID;
            retornarReportes.usuarioReportado = tipoComplejoReportes.USUARIO_REPORTADO;
            retornarReportes.usuarioReportador = tipoComplejoReportes.USUARIO_REPORTADOR;
            retornarReportes.descripcion = tipoComplejoReportes.DESCRIPCION;
            retornarReportes.estadoReporte = tipoComplejoReportes.ESTADO;

            return retornarReportes;
        }
    }
}
