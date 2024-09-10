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
                //Accedemos a la conexión que ya se tiene
                Command.Connection = getConnection();
                //Instrucción que se hará hacia la base de datos
                string query = "SELECT * FROM Tareas";
                //Comando sql en el cual se pasa la instrucción y la conexión
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                //Asignando valor al parametro
                cmd.Parameters.AddWithValue("valor", true);
                //Se ejecuta el comando y con ExecuteNonQuery se verifica su retorno
                //ExecuteNonQuery devuelve un valor entero.
                cmd.ExecuteNonQuery();
                //Se utiliza un adaptador sql para rellenar el dataset
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                //Se crea un objeto Dataset que es donde se devolverán los resultados
                DataSet ds = new DataSet();
                //Rellenamos con el Adaptador el DataSet diciendole de que tabla provienen los datos
                adp.Fill(ds, "Tareas");
                //Devolvemos el Dataset
                return ds;

            }
            catch (Exception)
            {
                //Retornamos null si existiera algún error durante la ejecución
                return null;
            }
            finally
            {
                //Independientemente se haga o no el proceso cerramos la conexión
                getConnection().Close();
            }

        }


        public int EliminarInspeccion()
        {
            try
            {
                Command.Connection = getConnection();
                //Se define que queremos hacer
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
