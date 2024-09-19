using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Controlador.AdministracionUsuarios;

namespace Sushi_Time_PTC_2024.Vista.Administración_de_Empleados
{
    public partial class AgregarUsuario : Form
    {
        public AgregarUsuario(int accion)
        {
            InitializeComponent();
            CañandirUsuario objnuevoU = new CañandirUsuario(this, accion);
        }

        public AgregarUsuario(int accion, int idEmpleado, string Nombre, string Apellido, string idCargo, string NumTelefono, string NumCuenta, string DUI, DateTime FechaNacimiento, string Direccion, string Hijos, DateTime FechaInicio, decimal Salario, DateTime FechaFin, string Correo)
        {
            InitializeComponent();
            CañandirUsuario objnuevoU = new CañandirUsuario(this, accion, idEmpleado, idCargo, Apellido, Nombre, NumTelefono, NumCuenta, DUI, FechaNacimiento, Direccion, Hijos, FechaInicio, Salario, FechaFin, Correo);
            {

            }
        }

        private void AgregarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
