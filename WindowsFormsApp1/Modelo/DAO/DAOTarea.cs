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
    internal class DAOTarea : DTOTarea
    {
        readonly SqlCommand Command = new SqlCommand();

        /// <summary>
        /// Obtener los datos corresponde al segundo mantenimiento del CRUD
        /// Consultar datos a la base de datos
        /// </summary>
        /// <returns></returns>
        public DataSet ObtenerEmpleado()
        {
            SqlCommand command = new SqlCommand();

            try
            {
                //Creando un objeto de tipo conexion
                command.Connection = getConnection();
                //Definir la instruccion de lo que se desea hacer
                string query = "SELECT idEmpleado FROM TareasEmpleados";
                //Creando un objeto de tipo comando donde recibe la instruccion y conexion
                SqlCommand cmdSelect = new SqlCommand(query, command.Connection);
                cmdSelect.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdSelect);
                DataSet ds = new DataSet();
                adp.Fill(ds, "TareaEmpleados");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} Error al obtener los empleados, verfique su conexion a internet o" + $"que el acceso al servidor o base de datos esten activos", "Error de Ejecucion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public DataSet ObtenerDescripcion()
        {
            SqlCommand command = new SqlCommand();

            try
            {
                //Creando un objeto de tipo conexion
                command.Connection = getConnection();
                //Definir la instruccion de lo que se desea hacer
                string query = "SELECT Descripcion FROM TareasEmpleados";
                //Creando un objeto de tipo comando donde recibe la instruccion y conexion
                SqlCommand cmdSelect = new SqlCommand(query, command.Connection);
                cmdSelect.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdSelect);
                DataSet ds = new DataSet();
                adp.Fill(ds, "TareaEmpleados");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} Error al obtener la descripcion de la tarea, verfique su conexion a internet o" + $"que el acceso al servidor o base de datos esten activos", "Error de Ejecucion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }
        public DataSet ObtenerFecha()
        {
            SqlCommand command = new SqlCommand();

            try
            {
                //Creando un objeto de tipo conexion
                command.Connection = getConnection();
                //Definir la instruccion de lo que se desea hacer
                string query = "SELECT Fecha FROM TareasEmpleados";
                //Creando un objeto de tipo comando donde recibe la instruccion y conexion
                SqlCommand cmdSelect = new SqlCommand(query, command.Connection);
                cmdSelect.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdSelect);
                DataSet ds = new DataSet();
                adp.Fill(ds, "TareaEmpleados");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} Error al obtener la fecha, verfique su conexion a internet o" + $"que el acceso al servidor o base de datos esten activos", "Error de Ejecucion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }




        /// <summary>
        /// Registrar tarea corresponde al primer mantenimiento del CRUD
        /// Inserción de datos a la base de datos
        /// </summary>
        /// <returns></returns>
        public void RegistrarTareaEmpleado(DTOTarea TareaEmpleado)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    Command.Connection = getConnection();
                    string query = "UPDATE TareasEmpleados SET " +
                                    "idEmpleado = @IdEmpleado" +
                                    "Descripcion = @Descripcion" +
                                    "fecha = @FechaLimite";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@IdTarea", IdTarea);
                    command.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                    command.Parameters.AddWithValue("@Descripcion", Descripcion);
                    command.Parameters.AddWithValue("@FechaLimite", FechaLimite);

                    int rowsAffected = command.ExecuteNonQuery();



                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo actualizar la tarea", "Error de ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    getConnection().Close();
                }


            }


        }

        /// <summary>
        /// Actualizar tarea corresponde al tercer mantenimiento del CRUD
        /// Actualización de datos
        /// </summary>
        /// <returns></returns>

        public int ActualizarTarea()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "INSERT INTO TareasEmpleados (idTarea, idEmpleado, Descripcion, fecha) VALUES (@IdTarea, @IdEmpleado, @Descripcion, @FechaLimite) ";
                SqlCommand command = new SqlCommand(query, Command.Connection);

                command.Parameters.AddWithValue("@IdTarea", IdTarea);
                command.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                command.Parameters.AddWithValue("@Descripcion", Descripcion);
                command.Parameters.AddWithValue("@FechaLimite", FechaLimite);


                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    string query2 = "UPDATE = TareasEmpleado SET " +
                                    "idTarea = @IdTarea" +
                                    "WHERE nombreTarea = @nombreTarea";

                    SqlCommand command2 = new SqlCommand(query, Command.Connection);

                    command2.Parameters.AddWithValue("@IdTarea", IdTarea);
                    command2.Parameters.AddWithValue("@nombreTarea", NombreTarea);

                    rowsAffected = command2.ExecuteNonQuery();
                    rowsAffected = 2;


                }
                return rowsAffected;
            }
            catch (Exception)
            {
                //Se retorna -1 en caso que en el segmento del try haya ocurrido algún error.
                return -1;
            }
            finally
            {
                //Independientemente se haga o no el proceso cerramos la conexión
                getConnection().Close();
            }
        }

        /// <summary>
        /// Eliminar tarea corresponde al cuarto mantenimiento del CRUD
        /// Actualización de datos
        /// </summary>
        /// <returns></returns>
        public int EliminarTarea()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "DELETE FROM TareasEmpleados WHERE idTareaEmpleados = @idTareaEmpleados";
                SqlCommand cmddelete = new SqlCommand(query, Command.Connection);
                cmddelete.Parameters.AddWithValue("idTareaEmpleados", IdTareaEmpleado);
                int retorno = cmddelete.ExecuteNonQuery();
                return retorno;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo Eliminar la tarea", "Error de ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Se retorna -1 en caso que en el segmento del try haya ocurrido algún error.
                return -1;
            }
            finally
            {
                //Independientemente se haga o no el proceso cerramos la conexión
                getConnection().Close();
            }
        }
        //Metodo para buscar un tarea en el buscador 
        public DataSet BuscarTarea(string valor)
        {
            try
            {
                //Accedemos a la conexión que ya se tiene
                Command.Connection = getConnection();
                //Instrucción que se hará hacia la base de datos
                string query = $"SELECT * FROM TareaEmpleado WHERE Nombres LIKE '%{valor}%' OR Descripcion LIKE '%{valor}%' OR Tarea LIKE '%{valor}%' OR Fecha LIKE '%{valor}%'";
                //Comando sql en el cual se pasa la instrucción y la conexión
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                //Se ejecuta el comando y con ExecuteNonQuery se verifica su retorno
                //ExecuteNonQuery devuelve un valor entero.
                cmd.ExecuteNonQuery();
                //Se utiliza un adaptador sql para rellenar el dataset
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                //Se crea un objeto Dataset que es donde se devolverán los resultados
                DataSet ds = new DataSet();
                //Rellenamos con el Adaptador el DataSet diciendole de que tabla provienen los datos
                adp.Fill(ds, "TareaEmpleado");
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
    }

}
