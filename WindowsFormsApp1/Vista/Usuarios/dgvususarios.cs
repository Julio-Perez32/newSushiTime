using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sushi_Time_PTC_2024.Controlador.AdministracionUsuarios;
using System.Windows.Forms;
using WindowsFormsApp1.Controlador.AdministracionUsuarios;
using WindowsFormsApp1.Controlador.AdministracionUsuario;
using Sushi_Time_PTC_2024.Controlador;

namespace WindowsFormsApp1.Vista.Usuarios
{
    public partial class dgvususarios : Form
    {
        public dgvususarios()
        {
            InitializeComponent();
            CUsuarios objusuari = new CUsuarios(this);
        }
    }
}
