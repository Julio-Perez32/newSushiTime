using Sushi_Time_PTC_2024.Controlador.Helpers;
using Sushi_Time_PTC_2024.Vista;
using Sushi_Time_PTC_2024.Vista.Olvidar_contraseña;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using WindowsFormsApp1.Modelo.DAO;
using WindowsFormsApp1.Modelo.DTO;

using WindowsFormsApp1.Vista.Olvidar_contraseña;






namespace Sushi_Time_PTC_2024.Controlador
    {
    internal class ControladorCambioDeContraseña
    {

        private cambiodecontraseña objvista;
        private cambiodecontraseña objFormCambioDeContraseña;
        private Encriptado encriptado;
        private DAOCambiarContraseña daoCambiarContraseña;


        public ControladorCambioDeContraseña(cambiodecontraseña vista)
        {
            objvista = vista;

            objFormCambioDeContraseña = vista;
            daoCambiarContraseña = new DAOCambiarContraseña();
            objFormCambioDeContraseña.Btncambiarcontra.Click += new EventHandler(CambiarContraseña);
            objFormCambioDeContraseña.pbSalir.Click += new EventHandler(ReturnToLogin);
        }

        private void CambiarContraseña(object sender, EventArgs e)
        {
            string nuevaContraseña = objFormCambioDeContraseña.txtnuevacontraseña.Text;
            if (string.IsNullOrWhiteSpace(nuevaContraseña))
            {
                MessageBox.Show("El campo de la contraseña no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método si la contraseña es inválida
            }
            Encriptado encriptado = new Encriptado();
            string contraseñaEncriptada = encriptado.ComputeSha256Hash(nuevaContraseña);
            int resultado = daoCambiarContraseña.CambiarContraseña(contraseñaEncriptada);

            if (resultado == 1)
            {
                MessageBox.Show("Contraseña cambiada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objvista.Hide();
                Logincs login = new Logincs();
                login.Show();
            }
            else if (resultado == 0)
            {
                MessageBox.Show("No se pudo cambiar la contraseña. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Ocurrió un error inesperado. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ReturnToLogin(object sender, EventArgs e)
        {
            objvista.Hide();
            Logincs loginForm = new Logincs(); 
            loginForm.Show();
        }

    }
}





