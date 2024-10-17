using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sushi_Time_PTC_2024.Modelo.DTO;
using System.Windows.Forms;

namespace Sushi_Time_PTC_2024.Modelo.DAO
{
    internal class DAOTablaTareas : DTOTablaTareas
    {

        readonly SqlCommand Command = new SqlCommand();
        public DataSet ObtenerTareas()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT * FROM Tareas";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("valor", true);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Tareas");
                return ds;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                getConnection().Close();
            }

        }


        public int EliminarInspeccion()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "DELETE Tareas WHERE idTarea = @param1";
                SqlCommand cmdDelete = new SqlCommand(query, Command.Connection);
                cmdDelete.Parameters.AddWithValue("param1", IdTarea);
                return cmdDelete.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} No se pudo eliminar la informacion de la tarea, verifique su conexion a internet o que los servicios esten activos", "Error para Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;

            }
            finally
            {
                Command.Connection.Close();
            }
        }
    }
}
