using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controlador.AdministracionUsuarios;

namespace WindowsFormsApp1.Vista.Usuarios
{
    public partial class editarUsuarios : Form
    {
        public editarUsuarios(int accion)
        {
            InitializeComponent();
            ControladorAU objgu = new ControladorAU(this, accion);
        }

        public editarUsuarios(int accion, int idUsuario, string rol, string correo, string usuario, string userStatus, DateTime fechaCreacion, string nombre, string apellido, string dui, string direccion, string telefono)
        {
            InitializeComponent();
            ControladorAU objnuevo = new ControladorAU(this, accion, idUsuario, rol, correo, usuario, userStatus, fechaCreacion, nombre, apellido, dui, direccion, telefono);

        }

        private void editarUsuarios_Load(object sender, EventArgs e)
        {

        }
    }
}
