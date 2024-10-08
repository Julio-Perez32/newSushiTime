﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Vista.Olvidar_contraseña;

namespace WindowsFormsApp1.Controlador.OlvidarContraseñas
{
    internal class ControllerRecuperarContraseña
    {
        RecuperacionContraseña ObjRecup;


        public ControllerRecuperarContraseña(RecuperacionContraseña vista)
        {
            ObjRecup = vista;
            ObjRecup.pbSalir.Click += new EventHandler(CerrarForm);
            ObjRecup.btnConfirmar.Click += new EventHandler(RecuperarContraseña);
        }

        public void RecuperarContraseña(object sender, EventArgs e)
        {
            RecuperarContraseñaService servicio = new RecuperarContraseñaService();
            servicio.RecuperarContraseña(ObjRecup.txtUsername.Text);
            MessageBox.Show($"Se ha enviado un correo electrónico a {ObjRecup.txtUsername.Text} con la nueva contraseña.");
        }
        private void CerrarForm(Object sender, EventArgs e)
        {
            ObjRecup.Close();
        }
    }
}