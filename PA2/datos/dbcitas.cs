using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PA2.Models;

namespace PA2.datos
{
    public static class dbcitas
    {
        private static string CadenaSQL = @"Data Source=.;Initial Catalog=PA;Integrated Security=True";

        public static bool Registrar(Citas cita)
        {
            bool respuesta = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaSQL))
                {
                    string query = "INSERT INTO citas (Fecha, Hora, Nombre, Apellido, Ocupado) VALUES (@Fecha, @Hora, @Nombre, @Apellido, 1)";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Fecha", cita.Fecha);
                    cmd.Parameters.AddWithValue("@Hora", cita.Hora);
                    cmd.Parameters.AddWithValue("@Nombre", cita.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", cita.Apellido);

                    conexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                        respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        public static bool Eliminar(int idCita)
        {
            bool respuesta = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaSQL))
                {
                    string query = "DELETE FROM citas WHERE IdCita = @IdCita";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@IdCita", idCita);

                    conexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                        respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        public static List<Citas> ObtenerCitas()
        {
            List<Citas> citas = new List<Citas>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaSQL))
                {
                    string query = "SELECT * FROM citas";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Citas cita = new Citas
                            {
                                IdCita = Convert.ToInt32(dr["IdCita"]),
                                Fecha = Convert.ToDateTime(dr["Fecha"]),
                                Hora = dr["Hora"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Ocupado = Convert.ToBoolean(dr["Ocupado"])
                            };
                            citas.Add(cita);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return citas;
        }
    }
}


/*
CREATE TABLE citas (
    IdCita INT PRIMARY KEY IDENTITY,
    Fecha DATE NOT NULL,
    Hora VARCHAR(10) NOT NULL,
    Nombre NVARCHAR(50) NOT NULL,
    Apellido NVARCHAR(50) NOT NULL,
    Ocupado BIT NOT NULL DEFAULT 0
);
*/
