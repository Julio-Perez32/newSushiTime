using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Controlador.Dashcarpet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Sushi_Time_PTC_2024.Vista
{
    public partial class Dashboard : Form
    {
        public Dashboard(string username)
        {
            InitializeComponent();
            ControlD objdashboard = new ControlD(this, username);
        }
    }
}
