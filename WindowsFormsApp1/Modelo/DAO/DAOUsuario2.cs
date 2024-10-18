using Sushi_Time_PTC_2024.Modelo;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp1.Modelo.DTO;

namespace WindowsFormsApp1.Modelo.DAO
{
    internal class DAOUsuario
    {
        private readonly SqlCommand Command = new SqlCommand();
        private readonly dbContext dbContext;

        public DAOUsuario(dbContext context)
        {
            dbContext = context;
        }

        public bool VerificarUsuario(DTOUsuarios dtoUsuario)
        {
            string query = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario";

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