using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Controlador;
using Sushi_Time_PTC_2024.Controlador.controllercalendario;

namespace Sushi_Time_PTC_2024.Vista.Calendario
{
    public partial class UserControlDias : UserControl
    {


        public static string static_day;

        public UserControlDias()
        {
            InitializeComponent();
            ControllerCalendario objCalendario = new ControllerCalendario(this);
        }

        private void UserControlDias_Load(object sender, EventArgs e)
        {
            
        }


        public void days(int numday)
        {
            lblDays.Text = numday + "";
        }

        private void UserControlDias_Click(object sender, EventArgs e)
        {
            static_day = lblDays.Text;
            AgregarTarea agregarTarea = new AgregarTarea(1);
            agregarTarea.Show();
        }
    }
}
