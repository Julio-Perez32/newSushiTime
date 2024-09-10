using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Controlador.controllercalendario;

namespace Sushi_Time_PTC_2024.Vista.Calendario
{
    public partial class AgregarTarea : Form
    {
        public AgregarTarea(int accion)
        {
            InitializeComponent();
            ControllerAgregarTarea objAgregar = new ControllerAgregarTarea(this, accion);
        }

        public AgregarTarea(int accion, int id, string NombreTarea, string fecha)
        {
            InitializeComponent();
            ControllerAgregarTarea agregarTarea = new ControllerAgregarTarea(this, accion, id, NombreTarea, fecha);
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
