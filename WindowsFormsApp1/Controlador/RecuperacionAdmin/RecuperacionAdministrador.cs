using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sushi_Time_PTC_2024.Modelo;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Vista;
using Sushi_Time_PTC_2024.Vista.Olvidar_contraseña;
using Sushi_Time_PTC_2024.Modelo.DAO;

namespace Sushi_Time_PTC_2024.Controlador.RecuperacionAdmin

{
    internal class RecuperacionAdministrador
    {
         Formaccesoporadministrador objadmin;

        public RecuperacionAdministrador(Formaccesoporadministrador vista)
        {
            objadmin = vista;
            objadmin.btningresar.Click += new EventHandler(IngresarAD);
        }

        private void IngresarAD(object sender, EventArgs e)
        {
            objadmin.Hide();
            Dashboard Dashboard = new Dashboard(objadmin.txtRespuesta.Text);
            Dashboard.Show();
        }


    }
}
