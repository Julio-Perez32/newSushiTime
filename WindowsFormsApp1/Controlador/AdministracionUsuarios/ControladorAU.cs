using Sushi_Time_PTC_2024.Controlador.Helpers;
using Sushi_Time_PTC_2024.Modelo.DAO;
using Sushi_Time_PTC_2024.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Modelo.DAO;
using WindowsFormsApp1.Vista.Asignacion_de_Funciones;

namespace WindowsFormsApp1.Controlador.AdministracionUsuarios
{
    internal class ControladorAU
    {
        EdicionU objedit;
        PrimerUso_ objagg;
        public ControladorAU(EdicionU vista, int idUsuario, string Usuario, string Contraseña, string Correo)
        {
            objedit = vista;
            objedit.btnEdicionC.Click += new EventHandler(UpdateRegister);
            ChargeValues(idUsuario, Usuario, Contraseña, Correo);
            VerificarAccion();
        }

        public void UpdateRegister(object sender, EventArgs e)
        {
            DAOUsuarios daoUpdate = new DAOUsuarios();
            daoUpdate.IdUsuario = int.Parse(objedit.txtID.Text.Trim());
            daoUpdate.Usuario = objedit.txtUsuario.Text.Trim();
            daoUpdate.Contraseña = objedit.txtContraseña.Text.Trim();
            daoUpdate.Correo = objedit.txtCorreo.Text.Trim();


            int valorRetornado = daoUpdate.ActualizarUsuario();

            if (valorRetornado == 2)
            {
                MessageBox.Show("Los datos han sido actualizado exitosamente",
                                "Proceso completado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else if (valorRetornado == 1)
            {
                MessageBox.Show("Los datos no pudieron ser actualizados completamente",
                                "Proceso interrumpido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser actualizados debido a un error inesperado",
                                "Proceso interrumpido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        public void ChargeValues(int idUsuario, string Usuario, string Contraseña, string Correo)
        {
            try
            {
                objedit.txtID.Text = idUsuario.ToString();
                objedit.txtUsuario.Text = Usuario;
                objedit.txtContraseña.Text = Contraseña;
                objedit.txtCorreo.Text = Correo;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

        }
        public void NewRegister(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(objagg.txtRegistrarUsuario.Text.Trim()) ||
                string.IsNullOrEmpty(objagg.txtRegistrarContraseña.Text.Trim()) ||
                string.IsNullOrEmpty(objagg.txtIngresarCorreo.Text.Trim()))) 
            {
                //Se crea una instancia de la clase DAOAdminUsers llamada DAOInsert
                DAOUsuarios DAOInsert = new DAOUsuarios();
                Encriptado commonClasses = new Encriptado();
                //Datos para creación de persona
                DAOInsert.Usuario = objagg.txtRegistrarUsuario.Text.Trim();
                DAOInsert.Contraseña = objagg.txtRegistrarContraseña.Text.Trim();
                DAOInsert.Correo = objagg.txtIngresarCorreo.Text.Trim();
                int valorRetornado = DAOInsert.RegistrarUsuario();

                //Se verifica el valor que retornó el metodo anterior y que fue almacenado en la variable valorRetornado
                if (valorRetornado == 1)
                {
                    //SavePhoto();       
                    MessageBox.Show("Los datos han sido registrados exitosamente",
                                    "Proceso completado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    objagg.Hide();
                }
                else
                {
                    MessageBox.Show("Los datos no pudieron ser registrados",
                                    "Proceso interrumpido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Existen campos vacíos, complete cada uno de los apartados y verifique que la fecha seleccionada corresponde a una persona mayor de edad.",
                                    "Proceso interrumpido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
            }
        }
        public void VerificarAccion()
        {
            objedit.txtID.Enabled = false;
        }
    }
}
