﻿using Sushi_Time_PTC_2024.Controlador.OlvidarContraseñas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sushi_Time_PTC_2024.Vista.Olvidar_contraseña
{
    public partial class olvidarcontraseñaprincipal1 : Form
    {
        public olvidarcontraseñaprincipal1()
        {
            InitializeComponent();

            ControladorPindeAdmincs Control = new ControladorPindeAdmincs(this);
        }
    }
}
