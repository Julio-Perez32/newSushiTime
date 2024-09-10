using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Controlador.ControladorLogin;
using Sushi_Time_PTC_2024.Controlador.RecuperacionAdmin;

namespace Sushi_Time_PTC_2024.Vista.Olvidar_contraseña
{
    public partial class Formaccesoporadministrador : Form
    {
        public Formaccesoporadministrador()
        {
            InitializeComponent();
            RecuperacionAdministrador recu = new RecuperacionAdministrador(this);
            
        }

        private void Formaccesoporadministrador_Load(object sender, EventArgs e)
        {

        }
    }
}
