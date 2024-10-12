using Sushi_Time_PTC_2024.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Modelo.DTO;
using static TheArtOfDev.HtmlRenderer.Adapters.RGraphicsPath;
using Sushi_Time_PTC_2024.Modelo;

namespace WindowsFormsApp1.Modelo.DAO
{
    internal class DAOUsuarios : DTOPrimerUsuario
    {
        readonly SqlCommand Command = new SqlCommand();


        public int RegistrarUsuario()
        {
            try
            {
                Command.Connection = dbContext.getConnection();
                string query = "INSERT INTO Usuarios (Usuario, Contraseña, UserStatus, Intentos, idRol, Nombre, Apellido, Dui, Direccion, Correo, Telefono, FechaCreacion) " +
                               "VALUES (@username, @password, @userStatus, @userAttempts, @idRol, @nombre, @apellido, @dui, @direccion, @correo, @telefono, @fechaCreacion)";

                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("@username", Usuario);
                cmd.Parameters.AddWithValue("@password", Contraseña);
                cmd.Parameters.AddWithValue("@userStatus", UserStatus);
                cmd.Parameters.AddWithValue("@userAttempts", Intentos);
                cmd.Parameters.AddWithValue("@idRol", Rol); // Asegúrate de que este valor sea el id del rol
                cmd.Parameters.AddWithValue("@nombre", Nombre);
                cmd.Parameters.AddWithValue("@apellido", Apellido);
                cmd.Parameters.AddWithValue("@dui", Dui);
                cmd.Parameters.AddWithValue("@direccion", Direccion);
                cmd.Parameters.AddWithValue("@correo", Correo);
                cmd.Parameters.AddWithValue("@telefono", Telefono);
                cmd.Parameters.AddWithValue("@fechaCreacion", FechaCreacion);

                int respuesta = cmd.ExecuteNonQuery();
                return respuesta > 0 ? 1 : 0; // Retorna 1 si se insertó correctamente
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error SQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Indica un error
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Indica un error
            }
            finally
            {
                if (Command.Connection != null && Command.Connection.State == ConnectionState.Open)
                {
                    Command.Connection.Close(); // Cerrar conexión
                }
            }
        }
        public int ActualizarUsuario()
        {
            try
            {
                // Se crea una conexión para garantizar que efectivamente haya conexión a la base.
                Command.Connection = getConnection();
                string query = "UPDATE Empleados SET " +
                                "Usuario = @param1, " +
                                "Nombre = @param2, " +
                                "Dui = @param3, " +
                                "Correo = @param4, " +
                                "Telefono = @param5, " +
                                "Apellido = @param6, " +
                                "idRol = @param7, " +
                                "Direccion = @param8, " +
                                "FechaCreacion = @param9, " +
                                "UserStatus = @param10, " +
                                "Contraseña = @param11, " +
                                "Intentos = @param12, " +
                                "WHERE idUsuario = @param13";

                // Crear comando y asignar valores a los parámetros
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("param1", Usuario);
                cmd.Parameters.AddWithValue("param2", Nombre);
                cmd.Parameters.AddWithValue("param3", Dui);
                cmd.Parameters.AddWithValue("param4", Correo);
                cmd.Parameters.AddWithValue("param5", Telefono);
                cmd.Parameters.AddWithValue("param6", Apellido);
                cmd.Parameters.AddWithValue("param7", Rol);
                cmd.Parameters.AddWithValue("param8", Direccion);
                cmd.Parameters.AddWithValue("param9", FechaCreacion);
                cmd.Parameters.AddWithValue("param10", UserStatus);
                cmd.Parameters.AddWithValue("param11", Contraseña);
                cmd.Parameters.AddWithValue("param12", Intentos);
                cmd.Parameters.AddWithValue("param13", IdUsuario);

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
        public DataSet BuscarPersonas(string valor)
        {
            try
            {
                //Accedemos a la conexión que ya se tiene
                Command.Connection = getConnection();

                //Instrucción que se hará hacia la base de datos
                string query = $"SELECT * FROM VistaUsuario WHERE Nombre LIKE '{valor}' ";

                // Imprime la consulta para verificar que esté bien formada (usar solo en modo depuración)
                Console.WriteLine($"Consulta ejecutada: {query}");

                // Comando sql en el cual se pasa la instrucción y la conexión
                SqlCommand cmd = new SqlCommand(query, Command.Connection);

                // Se ejecuta el comando
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "VistaUsuario");

                // Verifica si se devolvieron filas
                if (ds.Tables["VistaUsuario"].Rows.Count > 0)
                {
                    Console.WriteLine("Búsqueda exitosa, se encontraron resultados.");
                }
                else
                {
                    Console.WriteLine("No se encontraron resultados.");
                }

                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la búsqueda: {ex.Message}");
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }

    }
}
