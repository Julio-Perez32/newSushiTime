using System;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Vista.Olvidar_contraseña;
using Sushi_Time_PTC_2024.Vista;
using WindowsFormsApp1.Vista.Olvidar_contraseña;

namespace Sushi_Time_PTC_2024.Controlador.OlvidarContraseñas
{
    internal class ControladorPindeAdmincs
    {
        olvidarcontraseñaprincipal1 objacces;

        public ControladorPindeAdmincs(olvidarcontraseñaprincipal1 Vista)
        {
            objacces = Vista;
            objacces.btningresar.Click += new EventHandler(AccederPregunta);
            objacces.pbSalir.Click += new EventHandler(QuitApplication);
        }

        private void AccederPregunta(object sender, EventArgs e)
        {
            string Respuesta = objacces.txtRespuesta.Text;
            if (Respuesta == "121824")
            {
                objacces.Hide();
                cambiodecontraseña formCambioDeContraseña = new cambiodecontraseña();
                formCambioDeContraseña.Show();
            }
            else
            {
                MessageBox.Show("Respuesta Incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QuitApplication(object sender, EventArgs e)
        {
            objacces.Hide();
            olvidarcontraseña login = new olvidarcontraseña();
            login.Show();
        }
    }
}
