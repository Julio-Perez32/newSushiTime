using Sushi_Time_PTC_2024.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controlador.AdministracionUsuario;

namespace WindowsFormsApp1.Vista.Olvidar_contraseña
{
    public partial class cambiodecontraseña : Form
    {
        private ControladorCambioDeContraseña controlador;
        private CUsuarios objcambio2;

        public cambiodecontraseña()
        {
            InitializeComponent();
            controlador = new ControladorCambioDeContraseña(this);
        }


        private void txtnuevacontraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void ReturnToLogin(object sender, EventArgs e)
        {

        }
    }

}
