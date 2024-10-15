using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Modelo;
using Sushi_Time_PTC_2024.Modelo.DTO;
using System.Web.Security;
using Sushi_Time_PTC_2024.Vista.Administración_de_Empleados;
namespace Sushi_Time_PTC_2024.Modelo.DAO
{
    internal class DAOadminU : DTOadminU
    {
        readonly SqlCommand Command = new SqlCommand();


        public int RegistrarUsuario()
        {
            try
            {
                Command.Connection = getConnection();
                int respuesta;
                string query = "INSERT INTO Empleados (idEmpleado, idCargo, Nombre, Apellido, NumTelefono, NumCuenta, DUI, FechaNacimiento, Direccion, Hijos, FechaInicio, Salario, FechaFin, Correo) VALUES (@param1, @param2, @param3, @param4, @param5, @param6, @param7, @param8, @param9, @param10, @param11, @param12, @param13, @param14)";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("param1", IDempleado);
                cmd.Parameters.AddWithValue("param2", idCargo);
                cmd.Parameters.AddWithValue("param3", nombre);
                cmd.Parameters.AddWithValue("param4", apellido);
                cmd.Parameters.AddWithValue("param5", numtelefono);
                cmd.Parameters.AddWithValue("param6", numcuenta);
                cmd.Parameters.AddWithValue("param7", dui);
                cmd.Parameters.AddWithValue("param8", fechanacimiento);
                cmd.Parameters.AddWithValue("param9", direccion);
                cmd.Parameters.AddWithValue("param10", hijos);
                cmd.Parameters.AddWithValue("param11", fechainicio);
                cmd.Parameters.AddWithValue("param12", salario);
                cmd.Parameters.AddWithValue("param13", fechafin);
                cmd.Parameters.AddWithValue("param14", correo);
                respuesta = cmd.ExecuteNonQuery();
                return respuesta;
            }
            finally
            {
                Command.Connection.Close();
            }
        }

        public DataSet LlenarCombo()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT * FROM CargoEmpleado";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "CargoEmpleado");
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




        public int ActualizarUsuario()
        {
            try
            {
                // Se crea una conexión para garantizar que efectivamente haya conexión a la base.
                Command.Connection = getConnection();
                string query = "UPDATE Empleados SET " +
                                "idCargo = @param1, " +
                                "Nombre = @param2, " +
                                "Apellido = @param3, " +
                                "NumTelefono = @param4, " +
                                "NumCuenta = @param5, " +
                                "DUI = @param6, " +
                                "FechaNacimiento = @param7, " +
                                "Direccion = @param8, " +
                                "Hijos = @param9, " +
                                "FechaInicio = @param10, " +
                                "Salario = @param11, " +
                                "FechaFin = @param12, " +
                                "Correo = @param13 " +
                                "WHERE idEmpleado = @param14";

                // Crear comando y asignar valores a los parámetros
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("param1", idCargo);
                cmd.Parameters.AddWithValue("param2", nombre);
                cmd.Parameters.AddWithValue("param3", apellido);
                cmd.Parameters.AddWithValue("param4", numtelefono);
                cmd.Parameters.AddWithValue("param5", numcuenta);
                cmd.Parameters.AddWithValue("param6", dui);
                cmd.Parameters.AddWithValue("param7", fechanacimiento);
                cmd.Parameters.AddWithValue("param8", direccion);
                cmd.Parameters.AddWithValue("param9", hijos);
                cmd.Parameters.AddWithValue("param10", fechainicio);
                cmd.Parameters.AddWithValue("param11", salario);
                cmd.Parameters.AddWithValue("param12", fechafin);
                cmd.Parameters.AddWithValue("param13", correo);
                cmd.Parameters.AddWithValue("param14", IDempleado);

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
                string query = "DELETE Empleados WHERE idEmpleado = @param1";
                //Se crea un comando de tipo sql al cual se le pasa el query y la conexión, esto para que el sistema sepa que hacer y donde hacerlo.
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                //Se le da un valor a los parametros contenidos en el query, es importante mencionar que lo que esta entre comillas es el nombre del parametro y lo que esta después de la coma es el valor que se le asignará al parametro, estos valores vienen del DTO respectivo.
                cmd.Parameters.AddWithValue("param1", IDempleado);
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet BuscarPersonas(string valor)
        {
            try
            {
                //Accedemos a la conexión que ya se tiene
                Command.Connection = getConnection();

                //Instrucción que se hará hacia la base de datos
                string query = $"SELECT * FROM VistaEmpleados WHERE Nombres LIKE '{valor}' OR DUI LIKE '{valor}' ";

                // Imprime la consulta para verificar que esté bien formada (usar solo en modo depuración)
                Console.WriteLine($"Consulta ejecutada: {query}");

                // Comando sql en el cual se pasa la instrucción y la conexión
                SqlCommand cmd = new SqlCommand(query, Command.Connection);

                // Se ejecuta el comando
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "VistaEmpleados");

                // Verifica si se devolvieron filas
                if (ds.Tables["VistaEmpleados"].Rows.Count > 0)
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



        public DataSet Obtenerempleados()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT * FROM VistaEmpleados"; // Vista o tabla que contiene los empleados
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "VistaEmpleados");
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
    }
}
