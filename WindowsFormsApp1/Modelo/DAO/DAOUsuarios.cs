using Sushi_Time_PTC_2024.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TheArtOfDev.HtmlRenderer.Adapters.RGraphicsPath;

namespace WindowsFormsApp1.Modelo.DAO
{
   /* internal class DAOUsuarios : DTOPrimerUso
    {
        readonly SqlCommand Command = new SqlCommand();


        public int RegistrarUsuario()
        {
            try
            {
                Command.Connection = getConnection();
                int respuesta;
                string query = "INSERT INTO Empleados (idUsuario, Correo, Contraseña, Usuario) VALUES (@param1, @param2, @param3, @param4)";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("param1", IdUsuario);
                cmd.Parameters.AddWithValue("param2", Correo);
                cmd.Parameters.AddWithValue("param3", Contraseña);
                cmd.Parameters.AddWithValue("param4", Usuario);
                respuesta = cmd.ExecuteNonQuery();
                return respuesta;
            }
            finally
            {
                Command.Connection.Close();
            }

            
            }
        public int ActualizarUsuario()
        {
            try
            {
                // Se crea una conexión para garantizar que efectivamente haya conexión a la base.
                Command.Connection = getConnection();
                string query = "UPDATE Empleados SET " +
                                "Correo = @param1, " +
                                "Contraseña = @param2, " +
                                "Usuario = @param3, " +
                                "WHERE idEmpleado = @param4";

                // Crear comando y asignar valores a los parámetros
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("param1", Correo);
                cmd.Parameters.AddWithValue("param2", Contraseña);
                cmd.Parameters.AddWithValue("param3", Usuario);
                cmd.Parameters.AddWithValue("param4", IdUsuario);

                // Ejecutar la consulta
                int respuesta = cmd.ExecuteNonQuery();

                // Retorna 2 si la actualización fue exitosa
                return respuesta == 1 ? 2 : 1;
            }
            catch (Exception)
            {
                // Retorna -1 en caso de error
                return -1;
            }
            finally
            {
                // Cerrar la conexión
                getConnection().Close();
            }
        }
        public int EliminarUsuario()
        {
            try
            {
                //Se crea una conexión para garantizar que efectivamente haya conexión a la base.
                Command.Connection = getConnection();
                //**
                //Se crea el query que indica la acción que el sistema desea realizar con la base de datos
                //el query posee parametros para evitar algún tipo de ataque como SQL Injection
                string query = "DELETE Usuarios WHERE idUsuario = @param1";
                //Se crea un comando de tipo sql al cual se le pasa el query y la conexión, esto para que el sistema sepa que hacer y donde hacerlo.
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                //Se le da un valor a los parametros contenidos en el query, es importante mencionar que lo que esta entre comillas es el nombre del parametro y lo que esta después de la coma es el valor que se le asignará al parametro, estos valores vienen del DTO respectivo.
                cmd.Parameters.AddWithValue("param1", IdUsuario);
                //Se ejecuta el comando ya con todos los valores de sus parametros.
                //ExecuteNonQuery indicará cuantos filas fueron afectadas, es decir, cuantas filas de datos se ingresaron, por lo general devolvera 1 porque se hace una eliminación a la vez.
                int respuesta = cmd.ExecuteNonQuery();
                //Si la ejecución del comando no ha generado errores se procederá a retornar el valor de la variable respuesta que por lo general almacenará un 1 ya que solo se hace una acción a la vez.
                if (respuesta == 1)
                {

                    MessageBox.Show("Los Datos Se Eliminaron correctamente.", "Completado", MessageBoxButtons.OK);
                }
                return respuesta;
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
        public DataSet Obtenerempleados()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT * FROM VistaUsuario"; // Vista o tabla que contiene los empleados
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "VistaUsuario");
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
    }*/
}
