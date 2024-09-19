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

namespace WindowsFormsApp1.Vista.Asignacion_de_Funciones
{
    public partial class EdicionU : Form
    {
        public EdicionU(int idUsuario, string Usuario, string Contraseña, string Correo)
        {
            InitializeComponent();
            ControladorAU objau = new ControladorAU(this, idUsuario, Usuario, Contraseña, Correo);
        }
    }
}
