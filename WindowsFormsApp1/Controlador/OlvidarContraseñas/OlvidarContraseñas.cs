using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using Sushi_Time_PTC_2024.Vista.Olvidar_contraseña;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Vista;
using WindowsFormsApp1.Vista.Olvidar_contraseña;
namespace Sushi_Time_PTC_2024.Controlador.OlvidarContraseñas
{
    internal class OlvidarContraseñas
    {
        private olvidarcontraseña objbotones;
        public OlvidarContraseñas(olvidarcontraseña vistab)
        {
            objbotones = vistab;
            objbotones.btnadmin.Click += new EventHandler(EntrarporAdministracion);
            objbotones.btnPseguridad.Click += new EventHandler(EntrarporPregunta);
            objbotones.btnPCorreo.Click += new EventHandler(EntrarporCorreo);
            objbotones.pbsalir.Click += new EventHandler(QuitApplication);
        }

        private void EntrarporAdministracion(object sender, EventArgs e)
        {
            objbotones.Hide();
            olvidarcontraseñaprincipal1 olvidarContraA = new olvidarcontraseñaprincipal1();
            olvidarContraA.Show();
        }
        private void EntrarporPregunta(object sender, EventArgs e)
        {
            objbotones.Hide();
            FormPregunta_de_seguridad olvidarContraP = new FormPregunta_de_seguridad();
            olvidarContraP.Show();
        }

        private void EntrarporCorreo(object sender, EventArgs e)
        {
            objbotones.Hide();
            RecuperacionContraseña olvidarContraP = new RecuperacionContraseña();
            olvidarContraP.Show();
        }

        private void QuitApplication(object sender, EventArgs e)
        {
            objbotones.Hide();
            Logincs login = new Logincs();
            login.Show();
        }

    }
}