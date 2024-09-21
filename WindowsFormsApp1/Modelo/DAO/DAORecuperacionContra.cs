using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Modelo;
using Sushi_Time_PTC_2024.Modelo.DTO;

namespace Sushi_Time_PTC_2024.Modelo.DAO
{
    internal class DAORecuperacionContra : DTORecuperacionContra
    {
        SqlCommand Command = new SqlCommand();
        public bool RecuContra()
        {
            SqlConnection connection = null;
            SqlCommand cmd = null;
            SqlDataReader rd = null;

            try
            {
                connection = getConnection();
                cmd = new SqlCommand("Login", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Passsword", PasssWord);


                connection.Open();
                rd = cmd.ExecuteReader();
                bool hasRows = rd.HasRows;

                while (rd.Read())
                {
                    string mensaje = rd["Message"].ToString();
                    int resultado = Convert.ToInt32(rd["Result"]);

                }


                return hasRows;

            }
            catch (SqlException sqlex)
            {
                MessageBox.Show($"SQL Error: {sqlex.Message}");
                return false;
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
    }
}
