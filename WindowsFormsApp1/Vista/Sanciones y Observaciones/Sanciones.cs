﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sushi_Time_PTC_2024.Modelo.DAO;
using Sushi_Time_PTC_2024.Controlador;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Controlador.ControladorSanciones;

namespace WindowsFormsApp1.Vista.Sanciones_y_Observaciones
{
    public partial class Sanciones : Form
    {
        private readonly EmailController _emailController;
        public Sanciones()
        {
            InitializeComponent();
            var emailDao = new EmailDAO("observacionsushitime@gmail.com", "esbgovtsyuptagdc", "SushiTime");
            _emailController = new EmailController(emailDao);
        }

        private void ConfigurarTabIndex()
        {
            txtPara.TabIndex = 0;
            txtTipoSancion.TabIndex = 1;
            txtObservacionS.TabIndex = 2;
            BtnEnviar.TabIndex = 3;
        }
        private void BtnEnviar_Click_1(object sender, EventArgs e)
        {
            var to = txtPara.Text.Trim();
            var subject = txtTipoSancion.Text.Trim();
            var body = txtObservacionS.Text.Trim();
            _emailController.SendEmail(to, subject, body);
        }
    }
}
