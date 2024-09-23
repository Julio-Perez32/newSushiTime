using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controlador.OlvidarContraseñas;

namespace WindowsFormsApp1.Vista.Olvidar_contraseña
{
    public partial class RecuperacionContraseña : Form
    {
        public RecuperacionContraseña()
        {
            InitializeComponent();
            ControllerRecuperarContraseña RecuperacionC = new ControllerRecuperarContraseña(this);

        }

        private void RecuperacionContraseña_Load(object sender, EventArgs e)
        {

        }
    }
}
