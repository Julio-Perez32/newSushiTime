using Sushi_Time_PTC_2024.Modelo;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp1.Modelo.DTO; // Asegúrate de que la ruta es correcta

namespace WindowsFormsApp1.Modelo.DAO
{
    internal class DAOUsuario
    {
        private readonly SqlCommand Command = new SqlCommand();
        private readonly dbContext dbContext; // Asegúrate de tener un contexto adecuado para la conexión

        public DAOUsuario(dbContext context)
        {
            dbContext = context;
        }

        // Método para verificar si el usuario existe en la base de datos
        public bool VerificarUsuario(DTOUsuarios dtoUsuario)
        {
            string query = "SELECT COUNT(*) FROM usuarios WHERE Usuario = @Usuario";

            using (SqlConnection connection = dbContext.getConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@Usuario", dtoUsuario.NombreUsuario);

                        connection.Open();
                        int count = (int)command.ExecuteScalar();

                        return count > 0; 
                    }
                    catch (Exception ex)
                    {
                       
                        MessageBox.Show($"Error al verificar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false; 
                    }
                    
                }
            }
        }



    }
}