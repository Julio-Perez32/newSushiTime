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

        public bool RegistrarNegocio()
        {
            try
            {
                command.Connection = getConnection();
                string query = "INSERT INTO Negocio VALUES (@param1, @param2, @param3, @param4, @param5, @param6, @param7)";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("param1", Nombre);
                cmd.Parameters.AddWithValue("param2", Direccion);
                cmd.Parameters.AddWithValue("param3", CorreoElectronico);
                cmd.Parameters.AddWithValue("param4", FechaCreacion);
                cmd.Parameters.AddWithValue("param5", Telefono);
                cmd.Parameters.AddWithValue("param6", Pbx);
                cmd.Parameters.AddWithValue("param7", Logo);
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

        public int VerificarRegistroEmpresa()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT COUNT(*) FROM Negocio";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                int totalEmpresa = (int)cmd.ExecuteScalar();
                return totalEmpresa;
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
