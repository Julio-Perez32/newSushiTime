using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controlador.AdministracionUsuarios;

namespace Sushi_Time_PTC_2024.Vista.Asignacion_de_Funciones
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            dgvusuarios objinicio = new dgvusuarios(this);
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {

        }
    }
}
