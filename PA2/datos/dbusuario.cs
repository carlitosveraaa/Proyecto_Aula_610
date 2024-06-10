using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using PA2.Models;
using System.Data;
using System.Data.SqlClient;

namespace PA2.datos
{
    public class dbusuario
    {
        private static string CadenaSQL = @"Data Source= .;Initial Catalog=PA;Integrated Security=True";

        public static bool registrar(usuariodts usuario)
        {
            bool respuesta = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaSQL))
                {
                    string query = "insert into Usuario(nombre, correo, clave, restablecer, confirmado, token)";
                    query += "  values (@nombre,@correo,@clave,@restablecer,@confirmado,@token)";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@nombre", usuario.nombre);
                    cmd.Parameters.AddWithValue("@correo", usuario.correo);
                    cmd.Parameters.AddWithValue("@clave", usuario.clave);
                    cmd.Parameters.AddWithValue("@restablecer", usuario.restablecer);
                    cmd.Parameters.AddWithValue("@confirmado", usuario.confirmado);
                    cmd.Parameters.AddWithValue("@token", usuario.token);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();
                    int filasafectadas=cmd.ExecuteNonQuery();
                    if (filasafectadas > 0) respuesta = true;
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static usuariodts validar(string correo, string clave)
        {
            usuariodts usuario = null;
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaSQL))
                {
                    string query = "SELECT nombre, restablecer, confirmado FROM usuario ";
                    query += "WHERE correo=@correo AND clave=@clave";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@clave", clave);
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new usuariodts()
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
            return usuario;
        }

        public static usuariodts obtener(string correo, string clave)
        {
            usuariodts usuario = null;
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaSQL))
                {
                    string query = "SELECT nombre, clave, token FROM usuario WHERE correo=@correo";


                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@correo", correo);


                    cmd.CommandType = CommandType.Text;

                    conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new usuariodts()
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
            return usuario;
        }


        public static bool restableceractualizar(int restablecer, string clave, string token)
        {
            bool respuesta = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaSQL))
                {
                    string query = @"update usuario set " +
                        "restablecer =@restablecer," +
                        "clave=@clave " +
                        "where token=@token";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@restablecer",restablecer);
                    cmd.Parameters.AddWithValue("@clave",clave);
                    cmd.Parameters.AddWithValue("@token",token);
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
                    string query = @"update usuario set " +
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

    }
}