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
    public class UsuarioDAO
    {
        private readonly string _connectionString;
        public UsuarioDAO()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
        }

        public Usuario Login(string nombreUsuario, string contrasenna)
        {
            Usuario usuario = new Usuario();
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("spLogin", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@pNombreUsuario", nombreUsuario);
                    comando.Parameters.AddWithValue("@pcontrasenna", contrasenna);

                    conexion.Open();
                    try
                    {
                        using (var lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                usuario = new Usuario()
                                {
                                    idUsuario = Convert.ToInt32(lector["idUsuario"]),
                                    nombreUsuario = Convert.ToString(lector["nombreUsuario"]),
                                    idEmpleado = Convert.ToInt32(lector["idEmpleado"]),
                                    nombreEmpleado = Convert.ToString(lector["NombreCompleto"])
                                };
                            }
                        }
                        return usuario;
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
