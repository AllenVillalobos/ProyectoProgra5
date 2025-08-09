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
    public class LiquidacionDAO
    {
        private readonly string _connectionString;
        public LiquidacionDAO()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
        }
        public Liquidacion CrearLiquidacion(int idEmplado, DateTime FechaSalida)
        {
            Liquidacion liquidacion = null;
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                using (SqlCommand comando = new SqlCommand("spGenerarLiquidacionEmpleado", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@pIdEmpleado", idEmplado);
                    comando.Parameters.AddWithValue("@pFechaSalida", FechaSalida);
                    conexion.Open();
                    try
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                liquidacion = new Liquidacion
                                {
                                    idEmpleado = Convert.ToInt32(lector["idEmpleado"]),
                                    salarioMensual = Convert.ToSingle(lector["salarioMensual"]),
                                    salarioDiario = Convert.ToSingle(lector["salarioDiario"]),
                                    aniosTrabajados = Convert.ToSingle(lector["aniosTrabajados"]),
                                    vacacionesProporcionales = Convert.ToSingle(lector["vacacionesProporcionales"]),
                                    aguinaldoProporcional = Convert.ToSingle(lector["aguinaldoProporcional"]),
                                    montoPreaviso = Convert.ToSingle(lector["montoPreaviso"]),
                                    montoCesantia = Convert.ToSingle(lector["montoCesantia"]),
                                    totalLiquidacion = Convert.ToSingle(lector["totalLiquidacion"])
                                };
                            }
                        }
                        return liquidacion;
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error al crear la liquidación: " + e.Message, e);
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
