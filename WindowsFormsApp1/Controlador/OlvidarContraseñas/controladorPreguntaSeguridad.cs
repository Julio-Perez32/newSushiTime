using System;
using System.Windows.Forms;
using WindowsFormsApp1.Modelo.DTO;
using Sushi_Time_PTC_2024.Modelo.DTO;
using Sushi_Time_PTC_2024.Modelo.DAO;
using Sushi_Time_PTC_2024.Vista;
using Sushi_Time_PTC_2024.Vista.Olvidar_contraseña;
using Sushi_Time_PTC_2024.Modelo;
using WindowsFormsApp1.Modelo.DAO;
using WindowsFormsApp1.Vista.Olvidar_contraseña;

namespace Sushi_Time_PTC_2024.Controlador.ControladorPreguntadeseguridad
{
    internal class controladorPreguntaSeguridad
    {
        private FormPregunta_de_seguridad objFormPregunta_de_seguridad;
        private DTOlogin dtoLogin;
        private DAOLogin daoLogin;

        public controladorPreguntaSeguridad(FormPregunta_de_seguridad vista)
        {
            objFormPregunta_de_seguridad = vista;
            objFormPregunta_de_seguridad.btnEnviar.Click += new EventHandler(AccederPregunta);
            dtoLogin = new DTOlogin();
            daoLogin = new DAOLogin();
        }

        private void AccederPregunta(object sender, EventArgs e)
        {
            string respuesta = objFormPregunta_de_seguridad.txtRespuesta.Text;

            // Verifica si la respuesta de seguridad es correcta
            if (respuesta == "2018")
            {
                objFormPregunta_de_seguridad.Hide();

                // Muestra el formulario para ingresar el nombre de usuario
                using (usuariocambiodecontraseña formIngresarUsuario = new usuariocambiodecontraseña())
                {
                    if (formIngresarUsuario.ShowDialog() == DialogResult.OK)
                    {
                        dtoLogin.Username = formIngresarUsuario.txtUsername.Text;
                        daoLogin.Username = dtoLogin.Username;

                        int usuarioValido = daoLogin.ValidarUsuario();

                        if (usuarioValido == 1)
                        {
                            // Usuario válido, muestra el formulario de cambio de contraseña
                            cambiodecontraseña formCambioDeContraseña = new cambiodecontraseña();
                            formCambioDeContraseña.Show();
                        }
                        else
                        {
                            // Usuario no encontrado, muestra el mensaje de error y mantiene el formulario abierto
                            MessageBox.Show("Nombre de usuario no encontrado. Intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Respuesta de seguridad incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


