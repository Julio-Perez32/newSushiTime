using System;
using Sushi_Time_PTC_2024.Modelo.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Sushi_Time_PTC_2024.Modelo.DAO
{
    internal class DAOPrimerUso : DTOPrimerUso
    {
        readonly SqlCommand command = new SqlCommand();
        public bool RegistrarUsuario()
        {
            try
            {
                command.Connection = getConnection();
                string query = "INSERT INTO Usuarios VALUES (@param1, @param2, @param3)";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("param1", Usuario);
                cmd.Parameters.AddWithValue("param2", correo);
                cmd.Parameters.AddWithValue("param3", contraseña);
                int retorno = cmd.ExecuteNonQuery();
                return retorno > 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Excepcion SQL: {ex.Message}", "Error al procesar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excepcion SQL: {ex.Message}", "Error al procesar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public int VerificarRegistroUsuario()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT COUNT(*) FROM Usuarios";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                int totalUsuario = (int)cmd.ExecuteScalar();
                return totalUsuario;
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}
