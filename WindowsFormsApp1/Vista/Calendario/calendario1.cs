﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Controlador.controllercalendario;

namespace Sushi_Time_PTC_2024.Vista.Calendario
{
    public partial class calendario1 : Form
    {
        public calendario1()
        {
            InitializeComponent();
            ControllerCalendario objCalendario = new ControllerCalendario(this);
        }
    }
}
