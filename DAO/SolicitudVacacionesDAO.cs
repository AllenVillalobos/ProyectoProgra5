using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Proyecto.DAO
{
    public class SolicitudVacacionesDAO
    {
        private readonly string _connectionString;

        public SolicitudVacacionesDAO()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
        }

        public List<SolicitudVacaciones> ObtenerSolicitudes()
        {
            List<SolicitudVacaciones> solicitudes = new List<SolicitudVacaciones>();
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("spListarSolicitudVacaciones", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    try
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                SolicitudVacaciones solicitudVacaciones = new SolicitudVacaciones
                                {
                                    idSolicitudVacaciones = Convert.ToInt32(lector["idSolicitudVacaciones"]),
                                    detalle = lector["detalle"].ToString(),
                                    estado = lector["estado"].ToString(),
                                    fechaAdicion = Convert.ToDateTime(lector["FechaCreacion"]),
                                    empleadoNombre = Convert.ToString(lector["NombreCompleto"]),
                                    revisadoPor = lector["revisadoPor"] != DBNull.Value ? lector["revisadoPor"].ToString() : null,
                                    fechaRevision = lector["fechaRevision"] != DBNull.Value ? Convert.ToDateTime(lector["fechaRevision"]) : (DateTime?)null
                                };
                                solicitudes.Add(solicitudVacaciones);
                            }
                        }
                        return solicitudes;
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error al obtener las solicitudes de vacaciones: " + e.Message, e);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }
        }

        public void CrearSolicitudVacaciones(SolicitudVacaciones solicitudVacaciones)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("spCrearSolicitudVacaciones", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@pDetalle", solicitudVacaciones.detalle);
                    comando.Parameters.AddWithValue("@pIdEmpleado", solicitudVacaciones.idEmpleado);
                    comando.Parameters.AddWithValue("@pAdicionadoPor", solicitudVacaciones.adicionadoPor);

                    conexion.Open();
                    try
                    {
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error al crear la solicitud de vacaciones: " + e.Message, e);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }
        }

        public bool ModificarSolicitudVacaciones(SolicitudVacaciones solicitudVacaciones)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("spModificarSolicitudVacaciones", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@pidSolicitudVacaciones", solicitudVacaciones.idSolicitudVacaciones);
                    comando.Parameters.AddWithValue("@pResolucion", solicitudVacaciones.estado);
                    comando.Parameters.AddWithValue("@pRevisadoPor", solicitudVacaciones.revisadoPor);
                    conexion.Open();
                    try
                    {

                        int cambios = comando.ExecuteNonQuery();

                        return cambios > 0;

                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error al modificar la solicitud de vacaciones: " + e.Message, e);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }
        }
    }
}