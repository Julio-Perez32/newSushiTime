using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sushi_Time_PTC_2024.Modelo
{
    internal class dbContext
    {
        public static SqlConnection getConnection()
        {
            try
            {
                string server = "SQL8005.site4now.net";
                string database = "db_aad0d7_sushitime24";
                string userId = "db_aad0d7_sushitime24_admin";
                string Password = "fabio123";
                SqlConnection conexion = new SqlConnection($"Server = {server}; DataBase = {database}; User Id = {userId}; Password = {Password}");
                conexion.Open();
                return conexion;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"{ex.Message} Código de error: EC-001 \nNo fue posible conectarse a la base de datos, favor verifique las credenciales o que tenga acceso al sistema.", "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
    }
}
