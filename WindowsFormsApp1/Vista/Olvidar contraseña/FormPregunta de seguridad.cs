using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Controlador.ControladorPreguntadeseguridad;

namespace Sushi_Time_PTC_2024.Vista.Olvidar_contraseña
{
    public partial class FormPregunta_de_seguridad : Form
    {
        public FormPregunta_de_seguridad()
        {
            InitializeComponent();
            controladorPreguntaSeguridad control = new controladorPreguntaSeguridad(this);
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
