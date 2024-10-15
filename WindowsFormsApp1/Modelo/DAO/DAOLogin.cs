using System;
using Sushi_Time_PTC_2024.Modelo.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Sushi_Time_PTC_2024.Controlador.Helpers;
using System.Data;

namespace Sushi_Time_PTC_2024.Modelo.DAO
{
    internal class DAOLogin : DTOlogin
    {
        public int ValidarLogin()
        {
            SqlConnection connection = null;
            SqlCommand cmd = null;
            SqlDataReader rd = null;

            try
            {
                connection = dbContext.getConnection();
                string hashedPassword = new Encriptado().ComputeSha256Hash(Password);

                cmd = new SqlCommand("Login", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar, 50) { Value = Username });
                cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 65) { Value = hashedPassword });

                rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    int resultado = Convert.ToInt32(rd["Result"]);
                    return resultado;
                }
                else
                {
                    return -1;
                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show($"SQL Error: {sqlex.Message}");
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return -1;
            }
            finally
            {
                if (rd != null && !rd.IsClosed)
                {
                    rd.Close();
                }
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public int ValidarPrimerUsoSistema()
        {
            SqlConnection connection = null;
            try
            {
                connection = dbContext.getConnection();
                string query = "SELECT COUNT(*) FROM Usuarios";
                SqlCommand cmd = new SqlCommand(query, connection);
                int totalUsuarios = (int)cmd.ExecuteScalar();
                return totalUsuarios;
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show($"SQL Error: {sqlex.Message}");
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return -1;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public int ValidarUsuario()
        {
            SqlConnection connection = null;
            try
            {
                connection = dbContext.getConnection();
                string query = $"SELECT COUNT(*) FROM Usuarios WHERE Usuario = '{Username}'";
                SqlCommand cmd = new SqlCommand(query, connection);
                int usuarioEncontrado = (int)cmd.ExecuteScalar();
                return usuarioEncontrado;
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show($"SQL Error: {sqlex.Message}");
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return -1;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public int ObtenerIdUsuario()
        {
            SqlConnection connection = null;
            try
            {
                connection = dbContext.getConnection();
                string query = $"SELECT IdUsuario FROM Usuarios WHERE Usuario = @Username AND Contraseña = @Password"; // Asegúrate de que el nombre de la columna para la contraseña sea el correcto
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Password", Password);

                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                return 0;
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show($"SQL Error: {sqlex.Message}");
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return -1;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
