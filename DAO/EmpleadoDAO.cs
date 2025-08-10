using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto.DAO
{
    public class EmpleadoDAO
    {
        private readonly string _connectionString;

        public EmpleadoDAO()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
        }

        public List<Empleado> ObtenerEmpleados()
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("spListarEmpleadosGestion", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    try
                    {
                        List<Empleado> empleados = new List<Empleado>();
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                Empleado empleado = new Empleado
                                {
                                    idEmpleado = Convert.ToInt32(lector["idEmpleado"]),
                                    identificacion = lector["identificacion"].ToString(),
                                    primerNombre = lector["primerNombre"].ToString(),
                                    segundoNombre = lector["segundoNombre"].ToString(),
                                    primerApellido = lector["primerApellido"].ToString(),
                                    segundoApellido = lector["segundoApellido"].ToString(),
                                    salarioBruto = Convert.ToSingle(lector["salarioBruto"]),
                                    fechaContratacion = Convert.ToDateTime(lector["fechaContratacion"]),
                                    nombreDepartamento = lector["Departamento"].ToString(),
                                    nombrePuesto = lector["Puesto"].ToString(),
                                    nombreJornada = lector["Jornada"].ToString()

                                };
                                empleados.Add(empleado);
                            }
                        }
                        return empleados;
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error al obtener los empleados: " + e.Message, e);
                    }
                    finally
                    {
                         conexion.Close();
                    }

                }
            }
        }

        public void CrearEmpleado(Empleado empleado,int idDepartamento,int idJornada,int idPuesto)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("spCrearEmpleado", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@pIdentificacion", empleado.identificacion);
                    comando.Parameters.AddWithValue("@pPrimerNombre", empleado.primerNombre);
                    comando.Parameters.AddWithValue("@pSegundoNombre", empleado.segundoNombre);
                    comando.Parameters.AddWithValue("@pPrimerApellido", empleado.primerApellido);
                    comando.Parameters.AddWithValue("@pSegundoApellido", empleado.segundoApellido);
                    comando.Parameters.AddWithValue("@pFechaContratacion", empleado.fechaContratacion);
                    comando.Parameters.AddWithValue("@pSalarioBruto", empleado.salarioBruto);
                    comando.Parameters.AddWithValue("@pAdicionadoPor", empleado.adicionadoPor);
                    comando.Parameters.AddWithValue("@pIdDepartamento", idDepartamento);
                    comando.Parameters.AddWithValue("@pIdJornada", idJornada);
                    comando.Parameters.AddWithValue("@pIdPuesto", idPuesto);
                    conexion.Open();
                    try
                    {
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error al crear el empleado: " + e.Message, e);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }
        }
        public void ModificarEmpleado(Empleado empleado, int idDepartamento, int idJornada, int idPuesto)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("spModificarEmpleado", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@pIdEmpleado", empleado.idEmpleado);
                    comando.Parameters.AddWithValue("@pIdentificacion", empleado.identificacion);
                    comando.Parameters.AddWithValue("@pPrimerNombre", empleado.primerNombre);
                    comando.Parameters.AddWithValue("@pSegundoNombre", empleado.segundoNombre);
                    comando.Parameters.AddWithValue("@pPrimerApellido", empleado.primerApellido);
                    comando.Parameters.AddWithValue("@pSegundoApellido", empleado.segundoApellido);
                    comando.Parameters.AddWithValue("@pSalarioBruto", empleado.salarioBruto);
                    comando.Parameters.AddWithValue("@pModificadoPor", empleado.usuarioModificacion);
                    comando.Parameters.AddWithValue("@pIdDepartamento", idDepartamento);
                    comando.Parameters.AddWithValue("@pIdJornada", idJornada);
                    comando.Parameters.AddWithValue("@pIdPuesto", idPuesto);
                    conexion.Open();
                    try
                    {
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error al modificar el empleado: " + e.Message, e);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }
        }
        public void EliminarEmpleado(Empleado empleado)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("spEliminrEmpleaado", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@pIdEmpleado", empleado.idEmpleado);
                    comando.Parameters.AddWithValue("@pModificadoPor", empleado.usuarioModificacion);
                    conexion.Open();
                    try
                    {
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error al Eliminar el empleado: " + e.Message, e);
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