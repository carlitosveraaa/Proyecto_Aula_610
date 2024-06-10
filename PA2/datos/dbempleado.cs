using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using PA2.Models;
using System.Data;
using System.Data.SqlClient;

namespace PA2.datos
{
    public class bdempleado
    {
        private static string CadenaSQL = @"Data Source= .;Initial Catalog=PA;Integrated Security=True";

        public static bool registrar(empleadodts empleado)
        {
            bool respuesta = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaSQL))
                {
                    string query = "insert into empleado (nombre, cdempleado, correo, clave, restablecer, confirmado, token)";
                    query += "  values (@nombre,@cdempleado,@correo,@clave,@restablecer,@confirmado,@token)";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@nombre", empleado.nombre);
                    cmd.Parameters.AddWithValue("@cdempleado", empleado.cdempleado);
                    cmd.Parameters.AddWithValue("@correo", empleado.correo);
                    cmd.Parameters.AddWithValue("@clave", empleado.clave);
                    cmd.Parameters.AddWithValue("@restablecer", empleado.restablecer);
                    cmd.Parameters.AddWithValue("@confirmado", empleado.confirmado);
                    cmd.Parameters.AddWithValue("@token", empleado.token);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();
                    int filasafectadas = cmd.ExecuteNonQuery();
                    if (filasafectadas > 0) respuesta = true;
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool confirmar(string token)
        {
            bool respuesta = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaSQL))
                {
                    string query = @"update empleado set " +
                        "confirmado = 1 " +
                        "where token=@token";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@token", token);
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();

                    int filasafectadas = cmd.ExecuteNonQuery();
                    if (filasafectadas > 0) respuesta = true;
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static empleadodts obtener(string correo, string clave)
        {
            empleadodts empleado = null;
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaSQL))
                {
                    string query = "SELECT nombre, clave, token FROM empleado WHERE correo=@correo";


                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@correo", correo);


                    cmd.CommandType = CommandType.Text;

                    conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            empleado = new empleadodts()
                            {
                                nombre = dr["nombre"].ToString(),

                                clave = dr["clave"].ToString(),
                                token = dr["token"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empleado;
        }

        public static empleadodts validar(string cdempleado, string clave)
        {
            empleadodts empleado = null;
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaSQL))
                {
                    string query = "SELECT nombre, restablecer, confirmado FROM empleado ";
                    query += "WHERE cdempleado=@cdempleado AND clave=@clave";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@cdempleado", cdempleado);
                    cmd.Parameters.AddWithValue("@clave", clave);
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            empleado = new empleadodts()
                            {
                                nombre = dr["nombre"].ToString(),
                                restablecer = (bool)dr["restablecer"],
                                confirmado = (bool)dr["confirmado"]
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empleado;
        }

        public static bool eliminar(string cdempleado, string nombre)
        {
            bool respuesta = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaSQL))
                {
                    string query = "DELETE FROM empleado WHERE cdempleado=@cdempleado AND nombre=@nombre";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@cdempleado", cdempleado);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();
                    int filasafectadas = cmd.ExecuteNonQuery();
                    if (filasafectadas > 0) respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }


    }
}
