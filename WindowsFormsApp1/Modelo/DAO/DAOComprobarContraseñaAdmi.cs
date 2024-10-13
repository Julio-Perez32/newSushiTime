using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controlador.AdministracionUsuario;
using Sushi_Time_PTC_2024.Modelo;
using Sushi_Time_PTC_2024.Modelo.DTO;
using WindowsFormsApp1.Modelo.DTO;

namespace WindowsFormsApp1.Modelo.DAO
{
    internal class DAOComprobarContraseñaAdmi : DTOadminU
    {
        SqlCommand Command = new SqlCommand();
        public bool VerificarContraseñaAdmin()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT Password FROM Users WHERE idRole = 1  AND Estado = @Estado AND Password = @ContraseñaAdmin";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                //cmd.Parameters.AddWithValue("ContraseñaAdmin", Password1);
                cmd.Parameters.AddWithValue("param1", Usuario1);
                cmd.Parameters.AddWithValue("param2", Contraseña1);
                cmd.Parameters.AddWithValue("param3", 1);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                getConnection().Close();
            }


        }

        public int NewPassword()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "UPDATE Usuarios SET " +
                               "ContraseñaUsuario = @param1 " +
                               "WHERE NombreUsuario = @param2";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("param1", Usuario1);
                cmd.Parameters.AddWithValue("param2", Contraseña1);
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
        public bool ComprobarAdmin()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT * FROM Usuarios WHERE NombreUsuario = @param1 AND ContraseñaUsuario = @param2 AND IdRol = @param3";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("param1", Usuario1);
                cmd.Parameters.AddWithValue("param2", Contraseña1);
                cmd.Parameters.AddWithValue("param3", 1);
                SqlDataReader rd = cmd.ExecuteReader();
                return rd.HasRows;
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                getConnection().Close();
            }

        }
    }
}
