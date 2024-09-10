using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sushi_Time_PTC_2024.Modelo.DAO;
using Sushi_Time_PTC_2024.Vista;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Vista.Olvidar_contraseña;


namespace Sushi_Time_PTC_2024.Controlador
{
    internal class ControladorInicial
    {
        public static void DeterminarVistaInicial()
        {
            DAOLogin Objlogin = new DAOLogin();
            DAOPrimerUso Objfirst = new DAOPrimerUso();
            int primerUsuario = Objlogin.ValidarPrimerUsoSistema();
            if (primerUsuario == 0)
            {
                Application.Run(new PrimerUso_());
            }
            else
            {
                Application.Run(new Logincs());
            }
        }
    }
}
