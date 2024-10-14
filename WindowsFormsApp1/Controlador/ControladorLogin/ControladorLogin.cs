using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sushi_Time_PTC_2024.Controlador.Helpers;
using Sushi_Time_PTC_2024.Modelo.DAO;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Vista;
using Sushi_Time_PTC_2024.Vista.Olvidar_contraseña;

namespace Sushi_Time_PTC_2024.Controlador.ControladorLogin
{
    internal class ControladorLogin
    {
        private Logincs objvista;

        public ControladorLogin(Logincs vista)
        {
            objvista = vista;

            objvista.btnIngresar.Click += new EventHandler(DataAccess);
            objvista.pbSalida.Click += new EventHandler(QuitApplication);
            objvista.lblRecuC.Click += new EventHandler(RecuperacionC);
        }

        private void DataAccess(object sender, EventArgs e)
        {
            DAOLogin DAOData = new DAOLogin();

            DAOData.Username = objvista.txtUsuario.Text;
            DAOData.Password = objvista.txtIngresarContraseña.Text;

            int answer = DAOData.ValidarLogin();
            switch (answer)
            {
                case 1:
                    objvista.Hide();
                    Dashboard dashboard = new Dashboard(objvista.txtUsuario.Text);
                    dashboard.Show();
                    break;
                case 0:
                default:
                    MessageBox.Show("Datos incorrectos", "Error al iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case -1:
                    MessageBox.Show("Error al conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void QuitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RecuperacionC(object sender, EventArgs e)
        {
            DAOLogin daorecu = new DAOLogin();
            daorecu.Username = objvista.txtUsuario.Text;
            if (daorecu.ValidarUsuario() == 1)
            {
                olvidarcontraseña reinicio = new olvidarcontraseña();
                objvista.Hide();
                reinicio.Show();
            }
            else
            {
                MessageBox.Show("Usuario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}