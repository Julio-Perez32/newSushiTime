using Sushi_Time_PTC_2024.Modelo;
using Sushi_Time_PTC_2024.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Modelo.DAO
{
    internal class DAOCambiarContraseña : DTOCambiarContraseña
    {
        SqlCommand Command = new SqlCommand();
        public int CambiarContraseña(string nuevaContraseña)
        {
            try
            {
                // Conectar con la base de datos
                Command.Connection = getConnection();

                // Definir la consulta para actualizar la contraseña
                string query = "UPDATE Usuarios SET Contraseña = @nuevaContraseña ";

                // Crear el comando SQL y agregar los parámetros
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("@nuevaContraseña", nuevaContraseña);
                

                // Ejecutar la consulta
                int resultado = cmd.ExecuteNonQuery();

                // Verificar el resultado
                return resultado > 0 ? 1 : 0;
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


    }
}

