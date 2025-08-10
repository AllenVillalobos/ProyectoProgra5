using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto.DAO
{
    public class DepartamentoDAO
    {
        private readonly string _connectionString;
        public DepartamentoDAO()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
        }

        public List<Departamento> ListarDepartamentos()
        {
            List<Departamento> departamentos = new List<Departamento>();
            Departamento departamento = new Departamento();
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("spListarDepartamentos", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    try
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                departamento = new Departamento()
                                {
                                    idDepartamento = Convert.ToInt32(lector["idDepartamento"]),
                                    nombre = Convert.ToString(lector["nombre"])
                                };
                                departamentos.Add(departamento);
                            }
                        }
                        return departamentos;
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