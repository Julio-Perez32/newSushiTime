using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using Sushi_Time_PTC_2024.Vista.Olvidar_contraseña;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Vista;
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
            objbotones.pbsalir.Click += new EventHandler(QuitApplication);
        }

        private void EntrarporAdministracion(object sender, EventArgs e)
        {
            objbotones.Hide();
            Formaccesoporadministrador olvidarContraA = new Formaccesoporadministrador();
            olvidarContraA.Show();
        }
        private void EntrarporPregunta(object sender, EventArgs e)
        {
            objbotones.Hide();
            FormPregunta_de_seguridad olvidarContraP = new FormPregunta_de_seguridad();
            olvidarContraP.Show();
        }
        private void QuitApplication(object sender, EventArgs e)
        {
            objbotones.Hide();
        }

    }
}
