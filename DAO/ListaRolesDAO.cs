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
    public class ListaRolesDAO
    {
        private readonly string _connectionString;

        public ListaRolesDAO()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
        }

        public List<ListaRoles> ObtenerListaRolesPorUsuario(int idUsuario)
        {
            List<ListaRoles> listaRoles = new List<ListaRoles>();
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("spListarPermisosPorUsuario", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@pidUsuario", idUsuario);

                    conexion.Open();   
                    try
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                ListaRoles listaRole = new ListaRoles()
                                {
                                    nombreRol = Convert.ToString(lector["nombreRol"])
                                };
                                listaRoles.Add(listaRole);
                            }
                        }
                        return listaRoles;
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error al optener los permisos del usuario: " + e.Message, e);
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
