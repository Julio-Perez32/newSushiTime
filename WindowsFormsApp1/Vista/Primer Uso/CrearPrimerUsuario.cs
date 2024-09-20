using System;
using WindowsFormsApp1.Controlador.ControladorPrimerUso;
using Sushi_Time_PTC_2024.Controlador.ControladorPrimerUso;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Vista.Primer_Uso
{
    public partial class CrearPrimerUsuario : Form
    {
        public CrearPrimerUsuario()
        {
            InitializeComponent();
            ControladorPrimerUsuario control = new ControladorPrimerUsuario(this);
        }
    }
}
