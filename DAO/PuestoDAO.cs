using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto.DAO
{
    public class PuestoDAO
    {
        private readonly string _connectionString;
        public PuestoDAO()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
        }

        public List<Puesto> ListarPuestos()
        {
            List<Puesto> puestos = new List<Puesto>();
            Puesto puesto = new Puesto();
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("spListarPuesto", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    try
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                puesto = new Puesto()
                                {
                                    idPuesto = Convert.ToInt32(lector["idPuesto"]),
                                    nombre = Convert.ToString(lector["nombre"])
                                };
                                puestos.Add(puesto);
                            }
                        }
                        return puestos;
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error al intentar ingresar:" + e.Message, e);
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