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
    public partial class RecuperacionDentrodelSistema : Form
    {
        public RecuperacionDentrodelSistema(int action)
        {
            InitializeComponent();
            ControllerContraseñaAdmi2 objAdminUsuario = new ControllerContraseñaAdmi2(this, action);
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public static implicit operator RecuperacionDentrodelSistema(RecuperacionContraseña v)
        {
            throw new NotImplementedException();
        }
    }
}
