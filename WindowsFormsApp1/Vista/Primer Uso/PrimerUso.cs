using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Controlador.ControladorPrimerUso;

namespace Sushi_Time_PTC_2024.Vista
{
    public partial class PrimerUso_ : Form
    {
        public PrimerUso_()
        {
            InitializeComponent();
            ControladorPrimerUso control = new ControladorPrimerUso(this);
        }

    }
}
