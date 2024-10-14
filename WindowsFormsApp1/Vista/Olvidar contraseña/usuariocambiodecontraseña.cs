using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Vista.Olvidar_contraseña
{
    public partial class usuariocambiodecontraseña : Form
    {
        public usuariocambiodecontraseña()
        {
            InitializeComponent();
            btnConfirmar.Click += new EventHandler(btnAceptar_Click); // Conecta el evento
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text)) // Verifica que haya un nombre de usuario
            {
                this.DialogResult = DialogResult.OK; // Establece el resultado
                this.Close(); // Cierra el formulario
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un nombre de usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
