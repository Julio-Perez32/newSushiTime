﻿using Sushi_Time_PTC_2024.Vista.Olvidar_contraseña;
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
            btnConfirmar.Click += new EventHandler(btnAceptar_Click);
            pbSalir.Click += new EventHandler(salida);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un nombre de usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void salida(object sender, EventArgs e)
        {
                this.Hide();
                olvidarcontraseña login = new olvidarcontraseña();
                login.Show();
        }
      
    }
}

