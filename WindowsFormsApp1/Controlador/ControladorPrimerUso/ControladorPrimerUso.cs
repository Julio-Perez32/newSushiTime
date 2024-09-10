using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sushi_Time_PTC_2024.Modelo.DAO;
using Sushi_Time_PTC_2024.Vista;
using System.Windows.Forms;

namespace Sushi_Time_PTC_2024.Controlador.ControladorPrimerUso
{
    internal class ControladorPrimerUso
    {
        PrimerUso_ ObjVista;
        public ControladorPrimerUso(PrimerUso_ vista)
        {
            ObjVista = vista;
            vista.btnCrear.Click += new EventHandler(RegistroPrimerUsuario);
        }
        void RegistroPrimerUsuario(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(ObjVista.txtRegistrarUsuario.Text.Trim()) ||
               string.IsNullOrEmpty(ObjVista.txtRegistrarContraseña.Text.Trim()) ||
               string.IsNullOrEmpty(ObjVista.txtIngresarCorreo.Text.Trim())))
            {

            }
        }

    }
}
