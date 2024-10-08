﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sushi_Time_PTC_2024.Modelo.DAO;
using WindowsFormsApp1.Modelo.DAO;
using Sushi_Time_PTC_2024.Vista;
using WindowsFormsApp1.Vista.Primer_Uso;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Vista.Planillas;


namespace Sushi_Time_PTC_2024.Controlador
{
    internal class ControladorInicial
    {
        public static void DeterminarVistaInicial()
        {
            DAOLogin Objlogin = new DAOLogin();
            DAOPrimerUso Objfirst = new DAOPrimerUso();
            int primerEmpresa = Objfirst.VerificarRegistroEmpresa();
            int primerUsuario = Objlogin.ValidarPrimerUsoSistema();
            if (primerEmpresa == 0)
            {
                Application.Run(new PrimerUso_());
            }
            else if(primerUsuario == 0)
            {
                Application.Run(new CrearPrimerUsuario(1));
            }
            else
            {
                Application.Run(new Logincs());
            }
        }
    }
}
