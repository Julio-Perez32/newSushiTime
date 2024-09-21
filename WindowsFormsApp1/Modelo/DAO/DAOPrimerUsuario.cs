using System;
using WindowsFormsApp1.Modelo.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Modelo.DTO;
using System.Net;
using System.Data;
using Sushi_Time_PTC_2024.Modelo;

namespace WindowsFormsApp1.Modelo.DAO
{
    internal class DAOPrimerUsuario : DTOPrimerUsuario
    {
        readonly SqlCommand Command = new SqlCommand();

        public DataSet LlenarCombo()
        {
            try
            {
                Command.Connection = dbContext.getConnection();
                string query = "SELECT * FROM tbRol";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "tbRol");
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (Command.Connection != null && Command.Connection.State == ConnectionState.Open)
                {
                    Command.Connection.Close();
                }
            }
        }

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
                cmd.Parameters.AddWithValue("@idRol", Rol); // Asegúrate de que este valor sea el id del rol
                cmd.Parameters.AddWithValue("@nombre", Nombre);
                cmd.Parameters.AddWithValue("@apellido", Apellido);
                cmd.Parameters.AddWithValue("@dui", Dui);
                cmd.Parameters.AddWithValue("@direccion", Direccion);
                cmd.Parameters.AddWithValue("@correo", Correo);
                cmd.Parameters.AddWithValue("@telefono", Telefono);
                cmd.Parameters.AddWithValue("@fechaCreacion", FechaCreacion);

                int respuesta = cmd.ExecuteNonQuery();
                return respuesta > 0 ? 1 : 0; // Retorna 1 si se insertó correctamente
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error SQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Indica un error
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Indica un error
            }
            finally
            {
                if (Command.Connection != null && Command.Connection.State == ConnectionState.Open)
                {
                    Command.Connection.Close(); // Cerrar conexión
                }
            }
        }
    }
}
