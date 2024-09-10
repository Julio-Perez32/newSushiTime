using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sushi_Time_PTC_2024.Modelo.DTO;

namespace Sushi_Time_PTC_2024.Modelo.DAO
{
    internal class DAOAgregarTarea : DTOAgregarTarea
    {
        readonly SqlCommand command = new SqlCommand();
        public int AgregarTarea()
        {
            try
            {
                command.Connection = getConnection();
                string query = "INSERT INTO Tareas(NombreTarea, FechaTarea) VALUES (@NombreTarea, @FechaTarea)";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("NombreTarea", Nombretarea);
                cmd.Parameters.AddWithValue("FechaTarea", Fechatarea);
               
                int respuesta = cmd.ExecuteNonQuery();
                return respuesta; // Aseguramos que siempre se devuelve un valor en caso de éxito
            }

            finally
            {
                command.Connection.Close();
            }
        }


        public int ActualizarTarea()
        {
            try
            {
                command.Connection = getConnection();
                string query = "UPDATE Tareas SET " +
                               "NombreTarea = @param1, " +
                               "FechaTarea = @param2 " +
                               "WHERE idTarea = @param3";
                SqlCommand cmd = new SqlCommand(query, command.Connection);

                cmd.Parameters.AddWithValue("param1", Nombretarea);
                cmd.Parameters.AddWithValue("param2", Fechatarea);
                cmd.Parameters.AddWithValue("param3", IdTarea);
                return cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                getConnection().Close();
            }


        }

    }
}
