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
        // Método para registrar un nuevo usuario
        public bool RegistrarUsuario()
        {
            try
            {
                // Utilizando el patrón using para manejar la conexión y asegurar que se cierre automáticamente
                using (SqlConnection connection = getConnection("SQL8020.site4now.net", "db_aad0d7_sushitimedb", "db_aad0d7_sushitimedb_admin", "fabio123"))
                {
                    connection.Open();  // Abre la conexión a la base de datos

                    // Consulta SQL ajustada para incluir los campos adicionales requeridos
                    string query = "INSERT INTO Usuarios (Usuario, Correo, Contraseña, UserStatus, Intentos, Fecha, Hora) " +
                                   "VALUES (@Usuario, @Correo, @Contraseña, @UserStatus, @Intentos, @Fecha, @Hora)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Asignación de parámetros usando las propiedades de la clase DTOPrimerUso
                        cmd.Parameters.AddWithValue("@Usuario", Usuario);
                        cmd.Parameters.AddWithValue("@Correo", Correo);
                        cmd.Parameters.AddWithValue("@Contraseña", Contraseña);
                        cmd.Parameters.AddWithValue("@UserStatus", UserStatus);  // Campo UserStatus
                        cmd.Parameters.AddWithValue("@Intentos", 0);  // Valor predeterminado para Intentos
                        cmd.Parameters.AddWithValue("@Fecha", Fecha);  // Campo Fecha
                        cmd.Parameters.AddWithValue("@Hora", Hora);    // Campo Hora

                        // Ejecuta la consulta y verifica si se insertó algún registro
                        int retorno = cmd.ExecuteNonQuery();
                        return retorno > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Excepción SQL: {ex.Message}", "Error al procesar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excepción: {ex.Message}", "Error al procesar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Método para verificar el número de usuarios registrados
        public int VerificarRegistroUsuario()
        {
            try
            {
                // Utilizando el patrón using para asegurar que la conexión se cierre automáticamente
                using (SqlConnection connection = getConnection("SQL8020.site4now.net", "db_aad0d7_sushitimedb", "db_aad0d7_sushitimedb_admin", "fabio123"))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Usuarios";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Ejecuta la consulta y devuelve el número de registros
                        int totalUsuario = (int)cmd.ExecuteScalar();
                        return totalUsuario;
                    }
                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show($"Excepción SQL: {sqlex.Message}", "Error al procesar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excepción: {ex.Message}", "Error al procesar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
    }
}
