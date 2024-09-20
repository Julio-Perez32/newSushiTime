using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sushi_Time_PTC_2024.Vista;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Vista.Planillas;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Sushi_Time_PTC_2024.Controlador.Helpers;
using Sushi_Time_PTC_2024.Vista.Administración_de_Empleados;
using Sushi_Time_PTC_2024.Vista.Calendario;
using WindowsFormsApp1.Vista.Sanciones_y_Observaciones;

namespace Sushi_Time_PTC_2024.Controlador.Dashcarpet
{
    public class ControlD
    {
        private Dashboard ObjDashboard;
        private Form currentForm = null;

        // Constructor de la clase
        public ControlD(Dashboard View, string username)
        {
            // Asignar el objeto View a ObjDashboard
            ObjDashboard = View;

            // Asignar eventos a los botones del dashboard
            ObjDashboard.btnadminempleados.Click += new EventHandler(AbrirFormularioAdminUsuarios);
            /*ObjDashboard.btnAsignacionFunciones.Click += new EventHandler(AbrirAsignacionFunciones);*/
            ObjDashboard.btnCalendario.Click += new EventHandler(AbrirFormularioCalendario);
            ObjDashboard.btnSanciones.Click += new EventHandler(AbrirFormularioSanciones);
            ObjDashboard.btnCerrarSesion.Click += new EventHandler(CerrarSesion);
        }

        private void AbrirFormularioAdminUsuarios(object sender, EventArgs e)
        {
            AbrirFormulario<VerPlanilla>();
        }

        /*private void AbrirAsignacionFunciones(object sender, EventArgs e)
        {
            AbrirFormulario<Usuarios>();
        }*/

        private void AbrirFormularioCalendario(object sender, EventArgs e)
        {
            AbrirFormulario<calendario1>();
        }

        private void AbrirFormularioSanciones(object sender, EventArgs e)
        {
            AbrirFormulario<Sanciones>();
        }

        private void CerrarSesion(object sender, EventArgs e)
        {
            // Cerrar el formulario actual y mostrar el formulario de login
            ObjDashboard.Hide();
            Logincs loginForm = new Logincs();
            loginForm.Show();
        }

        private void AbrirFormulario<T>() where T : Form, new()
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = new T();
            currentForm.TopLevel = false;
            ObjDashboard.pnlVistas.Controls.Add(currentForm); // Cambiado a pnlVistas
            ObjDashboard.pnlVistas.Tag = currentForm;
            currentForm.BringToFront();
            currentForm.Show();
        }
    }
}
