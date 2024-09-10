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

namespace Sushi_Time_PTC_2024.Vista
{
    public partial class Logincs : Form
    {
        public Logincs()
        {
            InitializeComponent();
            ControladorLogin control = new ControladorLogin(this);
            this.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
