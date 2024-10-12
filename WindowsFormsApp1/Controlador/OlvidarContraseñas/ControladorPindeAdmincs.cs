using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Vista.Olvidar_contraseña;
using Sushi_Time_PTC_2024.Vista;

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

            //hacer un if para respuesta y verificar valores con msgbox mostrando que recibe
            if (Respuesta == "12345")
            {
                objacces.Hide();
                Dashboard Dashboard = new Dashboard(objacces.txtRespuesta.Text);
                Dashboard.Show();
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
