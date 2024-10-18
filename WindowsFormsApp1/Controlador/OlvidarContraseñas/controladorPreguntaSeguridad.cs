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
            objFormPregunta_de_seguridad.pbSalir.Click += new EventHandler(QuitApplication);
            dtoLogin = new DTOlogin();
            daoLogin = new DAOLogin();
        }

        private void AccederPregunta(object sender, EventArgs e)
        {
            string respuesta = objFormPregunta_de_seguridad.txtRespuesta.Text;

            if (respuesta == "2018")
            {
                objFormPregunta_de_seguridad.Hide(); // Solo ocultar la ventana de la pregunta de seguridad

                using (usuariocambiodecontraseña formIngresarUsuario = new usuariocambiodecontraseña())
                {
                    while (true) // Bucle para permitir que el usuario reintente si el nombre es incorrecto
                    {
                        if (formIngresarUsuario.ShowDialog() == DialogResult.OK)
                        {
                            dtoLogin.Username = formIngresarUsuario.txtUsername.Text;
                            daoLogin.Username = dtoLogin.Username;

                            int usuarioValido = daoLogin.ValidarUsuario();

                            if (usuarioValido == 1)
                            {
                                // Usuario válido, abrir el formulario de cambio de contraseña
                                cambiodecontraseña formCambioDeContraseña = new cambiodecontraseña();
                                formCambioDeContraseña.Show();
                                break; // Salir del bucle si el usuario es válido
                            }
                            else
                            {
                                // Usuario no válido, mostrar mensaje pero no cerrar la ventana de ingreso
                                MessageBox.Show("Nombre de usuario no encontrado. Intente de nuevo.",
                                                "Error",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                                formIngresarUsuario.txtUsername.Clear(); // Limpiar el campo de usuario para reintentar
                            }
                        }
                        else
                        {
                            // Si se cancela el formulario, salir del bucle
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Respuesta de seguridad incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void QuitApplication(object sender, EventArgs e)
        {
            objFormPregunta_de_seguridad.Hide();
            olvidarcontraseña login = new olvidarcontraseña();
            login.Show();
        }
    }
}


