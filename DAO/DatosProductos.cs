using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAO
{
    public static class DatosProductos
    {

        public static List<Productos> listarClientes(string id)
        {

            SqlCommand command = null; ;
            SqlParameter sqlParameter = null;
            List<Productos> productos = null;

            try
            {
                productos = new List<Productos>();

                using (SqlConnection conexion = new SqlConnection(Constantes.cadenaConexion))
                {
                    conexion.Open();
                    command = new SqlCommand("USP_ListarProducto", conexion);
                    command.CommandType = CommandType.StoredProcedure;
                    sqlParameter = new SqlParameter("@Id", SqlDbType.Int);
                    sqlParameter.Value = id;
                    command.Parameters.Add(sqlParameter);
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        productos.Add(new Productos
                        {
                            ID = reader["IdProducto"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Precio = reader["Precio"].ToString(),
                            Stock = reader["Stock"].ToString(),
                            FechaCreacion = reader["FechaCreacion"].ToString()
                        }
                      );
                    }


                }

                return productos;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                command = null;
                sqlParameter = null;
                productos = null;
            }

        }





    }
}
