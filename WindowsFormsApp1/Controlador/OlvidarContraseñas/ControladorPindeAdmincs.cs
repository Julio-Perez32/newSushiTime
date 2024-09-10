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
        private Logincs objvista;
        Formaccesoporadministrador objacces;
        
        public ControladorPindeAdmincs(Formaccesoporadministrador vista)
        {
            objacces = vista;
            objacces.btningresar.Click += new EventHandler(ingresarAdmin);
            objacces.pbSalir.Click += new EventHandler(QuitApplication);
        }

        private void ingresarAdmin(object sender, EventArgs e)
        {
            
            string pinIngresado = objacces.txtPinA.Text;
            

            if (pinIngresado == "12345")
            {
                objvista.Hide();
                objacces.Hide();
                Dashboard dashboard = new Dashboard(pinIngresado);
                dashboard.Show();
   
            }
            else
            {
                MessageBox.Show("Respuesta incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void QuitApplication(object sender, EventArgs e)
        {
            objacces.Hide();
        }
    }
}
