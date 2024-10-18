using Sushi_Time_PTC_2024.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Modelo.DTO;
using static TheArtOfDev.HtmlRenderer.Adapters.RGraphicsPath;
using Sushi_Time_PTC_2024.Modelo;

namespace WindowsFormsApp1.Modelo.DAO
{
    internal class DAOUsuarios : DTOPrimerUsuario
    {
        readonly SqlCommand Command = new SqlCommand();


        public int RegistrarUsuario()
        {
            try
            {
                Command.Connection = dbContext.getConnection();
                string query = "INSERT INTO Usuarios (Usuario, Contraseña, UserStatus, Intentos, idRol, Nombre, Apellido, Dui, Direccion, Correo, Telefono, FechaCreacion) " +
                               "VALUES (@username, @password, @userStatus, @userAttempts, @idRol, @nombre, @apellido, @dui, @direccion, @correo, @telefono, @fechaCreacion)";

                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("@username", Usuario);
                cmd.Parameters.AddWithValue("@password", Contraseña);
                cmd.Parameters.AddWithValue("@userStatus", UserStatus);
                cmd.Parameters.AddWithValue("@userAttempts", Intentos);
                cmd.Parameters.AddWithValue("@idRol", Rol);
                cmd.Parameters.AddWithValue("@nombre", Nombre);
                cmd.Parameters.AddWithValue("@apellido", Apellido);
                cmd.Parameters.AddWithValue("@dui", Dui);
                cmd.Parameters.AddWithValue("@direccion", Direccion);
                cmd.Parameters.AddWithValue("@correo", Correo);
                cmd.Parameters.AddWithValue("@telefono", Telefono);
                cmd.Parameters.AddWithValue("@fechaCreacion", FechaCreacion);

                int respuesta = cmd.ExecuteNonQuery();
                return respuesta > 0 ? 1 : 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error SQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                if (Command.Connection != null && Command.Connection.State == ConnectionState.Open)
                {
                    Command.Connection.Close();
                }
            }
        }
        public int ActualizarUsuario()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "UPDATE Usuarios SET " +
                                "Usuario = @param1, " +
                                "Nombre = @param2, " +
                                "Dui = @param3, " +
                                "Correo = @param4, " +
                                "Telefono = @param5, " +
                                "Apellido = @param6, " +
                                "idRol = @param7, " +
                                "Direccion = @param8, " +
                                "FechaCreacion = @param9, " +
                                "UserStatus = @param10 " + // Asegúrate de que esta línea sea correcta
                                "WHERE idUsuario = @param11";

                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("param1", Usuario);
                cmd.Parameters.AddWithValue("param2", Nombre);
                cmd.Parameters.AddWithValue("param3", Dui);
                cmd.Parameters.AddWithValue("param4", Correo);
                cmd.Parameters.AddWithValue("param5", Telefono);
                cmd.Parameters.AddWithValue("param6", Apellido);
                cmd.Parameters.AddWithValue("param7", Rol);
                cmd.Parameters.AddWithValue("param8", Direccion);
                cmd.Parameters.AddWithValue("param9", FechaCreacion);
                cmd.Parameters.AddWithValue("param10", UserStatus);
                cmd.Parameters.AddWithValue("param11", IdUsuario);

                int respuesta = cmd.ExecuteNonQuery();

                // Aquí eliminamos el MessageBox de depuración
                return respuesta > 0 ? 1 : 0; // Asegúrate de que esto sea correcto
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error SQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Indica que hubo un error
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Indica que hubo un error
            }
            finally
            {
                if (Command.Connection != null && Command.Connection.State == ConnectionState.Open)
                {
                    Command.Connection.Close();
                }
            }
        }



        public int EliminarUsuario(int IdUsuarioActual)
        {
            try
            {
                Command.Connection = getConnection();

                if (IdUsuario == IdUsuarioActual)
                {
                    MessageBox.Show("No se puede eliminar el usuario que está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }

                string query = "DELETE FROM Usuarios WHERE idUsuario = @param1";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("@param1", IdUsuario);

                int respuesta = cmd.ExecuteNonQuery();

                if (respuesta == 1)
                {
                    MessageBox.Show("Los Datos Se Eliminaron correctamente.", "Completado", MessageBoxButtons.OK);
                }
                return respuesta;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet Obtenerempleados()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT * FROM VistaUsuario";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "VistaUsuario");
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet BuscarPersonas(string valor)
        {
            try
            {
                Command.Connection = getConnection();

                string query = $"SELECT * FROM VistaUsuario WHERE Nombre LIKE '{valor}' ";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "VistaUsuario");

                if (ds.Tables["VistaUsuario"].Rows.Count > 0)
                {
                    Console.WriteLine("Búsqueda exitosa, se encontraron resultados.");
                }
                else
                {
                    Console.WriteLine("No se encontraron resultados.");
                }

                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la búsqueda: {ex.Message}");
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
    }
}
