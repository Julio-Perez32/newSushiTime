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
                string hashedPassword = new Encriptado().ComputeSha256Hash(Password); // Encripta la contraseña directamente

                cmd = new SqlCommand("Login", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar, 50) { Value = Username });
                cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 65) { Value = hashedPassword }); // Usa la contraseña encriptada

                rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    // Lee el resultado y el mensaje
                    int resultado = Convert.ToInt32(rd["Result"]);
                    return resultado;
                }
                else
                {
                    // Si no hay filas considera como error
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
    }
}
