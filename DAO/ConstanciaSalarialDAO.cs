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
    public class ConstanciaSalarialDAO
    {
        private readonly string _connectionString;
        public ConstanciaSalarialDAO()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
        }

        public ConstanciaSalarial CrearSolicitud(int id)
        {
            ConstanciaSalarial constanciaSalarial = null;
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("spConstanciaSalarial", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@pIdEmpleado", id);
                    conexion.Open();
                    try
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                constanciaSalarial = new ConstanciaSalarial
                                {
                                    idEmpleado = Convert.ToInt32(lector["idEmpleado"]),
                                    salarioBruto = lector["SalarioBruto"] != DBNull.Value ? Convert.ToSingle(lector["SalarioBruto"]) : (float?)null,
                                    nombreCompleto = lector["NombreCompleto"].ToString(),
                                    identificacion = lector["Identificacion"].ToString(),
                                    puesto = lector["Puesto"].ToString(),
                                    departamento = lector["Departamento"].ToString(),
                                    fechaContratacion = lector["FechaContratacion"] != DBNull.Value ? Convert.ToDateTime(lector["FechaContratacion"]) : (DateTime?)null,
                                    activo = lector["Activo"] != DBNull.Value ? Convert.ToChar(lector["Activo"]) : (char?)null,
                                    tipoContrato = lector["TipoContrato"].ToString()
                                };
                            }
                        }
                        return constanciaSalarial;
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error al crear la solicitud de constancia salarial: " + e.Message, e);
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