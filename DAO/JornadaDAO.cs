using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto.DAO
{
    public class JornadaDAO
    {
        private readonly string _connectionString;
        public JornadaDAO()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
        }

        public List<Jornada> ListarJornadas()
        {
            List<Jornada> jornadas = new List<Jornada>();
            Jornada jornada = new Jornada();
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("spListarJornada", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    try
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                jornada = new Jornada()
                                {
                                    idJornada = Convert.ToInt32(lector["idJornada"]),
                                    nombre = Convert.ToString(lector["nombre"])
                                };
                                jornadas.Add(jornada);
                            }
                        }
                        return jornadas;
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