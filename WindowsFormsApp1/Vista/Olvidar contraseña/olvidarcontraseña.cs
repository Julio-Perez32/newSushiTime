using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Controlador.OlvidarContraseñas;

namespace Sushi_Time_PTC_2024.Vista.Olvidar_contraseña
{
    public partial class olvidarcontraseña : Form
    {
        public olvidarcontraseña()
        {
            InitializeComponent();
            OlvidarContraseñas control = new OlvidarContraseñas(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
