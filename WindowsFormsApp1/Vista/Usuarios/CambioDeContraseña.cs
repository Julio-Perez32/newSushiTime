﻿using System;
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
    public partial class CambioDeContraseña : Form
    {
        public CambioDeContraseña()
        {
            InitializeComponent();
            controladorCambiarContra objcontra = new controladorCambiarContra(this);
        }
    }
}
