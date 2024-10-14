using System;
using System.Windows.Forms;
using WindowsFormsApp1.Modelo.DTO;
using Sushi_Time_PTC_2024.Modelo.DAO; // Asegúrate de que la ruta es correcta
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

        public controladorPreguntaSeguridad(FormPregunta_de_seguridad Vista)
        {
            objFormPregunta_de_seguridad = Vista;
            objFormPregunta_de_seguridad.btnEnviar.Click += new EventHandler(AccederPregunta);
            
        }

        private void AccederPregunta(object sender, EventArgs e)
        {
            string respuesta = objFormPregunta_de_seguridad.txtRespuesta.Text;

            if (respuesta == "2018")
            {
                objFormPregunta_de_seguridad.Hide();

                // Abre el formulario de ingreso de usuario
                usuariocambiodecontraseña formIngresarUsuario = new usuariocambiodecontraseña();
                if (formIngresarUsuario.ShowDialog() == DialogResult.OK)
                {
                    // Crear una instancia del DTO y asignar valores
                    DTOUsuarios dtoUsuario = new DTOUsuarios
                    {
                        NombreUsuario = formIngresarUsuario.txtUsername.Text,
                       
                    };

                    // Mostrar los valores en un MessageBox para depuración
                    MessageBox.Show($"Usuario: {dtoUsuario.NombreUsuario}");

                    // Crear una instancia del DAO
                    DAOUsuario daoUsuario = new DAOUsuario(new dbContext());

                    // Verificar el usuario usando el DAO
                    if (daoUsuario.VerificarUsuario(dtoUsuario))
                    {
                        // Si el usuario es válido, abrir el formulario de cambio de contraseña
                        cambiodecontraseña formCambioDeContraseña = new cambiodecontraseña();
                        formCambioDeContraseña.Show();
                    }
                    else
                    {
                        MessageBox.Show("Nombre de usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error", "Respuesta Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
