using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Modelo.DTO;

namespace WindowsFormsApp1.Modelo.DAO
{
    internal class UsuarioDAO : UsuarioDTO
    {

        SqlCommand Command = new SqlCommand();
        public UsuarioDTO GetUsuarioByNombreUsuario(string nombreUsuario)
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT * FROM Usuarios WHERE Usuario = @Usuario";
                SqlCommand command = new SqlCommand(query, Command.Connection);
                command.Parameters.AddWithValue("@Usuario", nombreUsuario);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    UsuarioDTO usuario = new UsuarioDTO
                    {
                        Id_Usuario = (int)reader["idUsuario"],
                        NombreUsuario = (string)reader["Usuario"],
                        CorreoElectronico = (string)reader["Correo"],
                        Contraseña = (string)reader["Contraseña"]
                    };
                    return usuario;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
                return null;

            }


        }

        public void UpdateContraseña(int idUsuario, string nuevaContraseña)
        {

            Command.Connection = getConnection();
            string query = "UPDATE Usuarios SET Contraseña = @NuevaContraseña WHERE idUsuario = @idUsuario";
            SqlCommand command = new SqlCommand(query, Command.Connection);
            command.Parameters.AddWithValue("@NuevaContraseña", nuevaContraseña);
            command.Parameters.AddWithValue("@idUsuario", idUsuario);
            command.ExecuteNonQuery();

        }
    }
}