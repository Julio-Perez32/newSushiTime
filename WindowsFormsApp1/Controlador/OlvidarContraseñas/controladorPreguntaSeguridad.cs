using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sushi_Time_PTC_2024.Modelo;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Vista;
using Sushi_Time_PTC_2024.Vista.Olvidar_contraseña;
using Sushi_Time_PTC_2024.Modelo.DAO;

namespace Sushi_Time_PTC_2024.Controlador.ControladorPreguntadeseguridad
{
    internal class controladorPreguntaSeguridad
    {
        FormPregunta_de_seguridad objFormPregunta_de_seguridad;
        
        public controladorPreguntaSeguridad(FormPregunta_de_seguridad Vista)
        {
            objFormPregunta_de_seguridad = Vista;
            objFormPregunta_de_seguridad.btnEnviar.Click += new EventHandler(AccederPregunta);
            objFormPregunta_de_seguridad.pbSalir.Click += new EventHandler(QuitApplication);
        }
        private void AccederPregunta(object sender, EventArgs e)
        {
            string Respuesta = objFormPregunta_de_seguridad.txtRespuesta.Text;
            
            //hacer un if para respuesta y verificar valores con msgbox mostrando que recibe
            if (Respuesta == "2018")
            {
                objFormPregunta_de_seguridad.Hide();
                Dashboard Dashboard = new Dashboard(objFormPregunta_de_seguridad.txtRespuesta.Text);
                Dashboard.Show();
            }
            else
            {
                MessageBox.Show("Respuesta Incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
