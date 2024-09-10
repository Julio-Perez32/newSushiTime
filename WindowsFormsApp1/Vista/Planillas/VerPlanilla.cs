using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Controlador.AdministracionUsuarios;

namespace Sushi_Time_PTC_2024.Vista.Planillas
{
    public partial class VerPlanilla : Form
    {
        public VerPlanilla()
        {
            InitializeComponent();
            AdministracionUsuarios objAdminUsuario = new AdministracionUsuarios(this);
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void VerPlanilla_Load(object sender, EventArgs e)
        {

        }

        private void txtbuscarT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
