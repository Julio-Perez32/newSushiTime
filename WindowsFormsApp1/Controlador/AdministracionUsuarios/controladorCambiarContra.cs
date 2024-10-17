using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Vista.Olvidar_contraseña;
using Sushi_Time_PTC_2024.Controlador.Helpers;
using Sushi_Time_PTC_2024.Vista;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1.Modelo.DAO;
using WindowsFormsApp1.Vista.Usuarios;
using WindowsFormsApp1.Vista.Primer_Uso;
using Sushi_Time_PTC_2024.Modelo.DAO;
using WindowsFormsApp1.Controlador.Helpers;

namespace WindowsFormsApp1.Controlador.AdministracionUsuarios
{
    internal class controladorCambiarContra
    {
        CambioDeContraseña objcontraseña;
        public controladorCambiarContra(CambioDeContraseña vista)
        {
            objcontraseña = vista;
            objcontraseña.btnGuardarC.Click += new EventHandler(cambiandocontra);
        }

        private void cambiandocontra(object sender, EventArgs e)
        {
            CambioDeContraseña objcambio = new CambioDeContraseña();
            DAOCambiarContraseña dao = new DAOCambiarContraseña();
            string nuevaContraseña = objcambio.txtnuevacontraseña.Text;
            Encriptado encriptado = new Encriptado();
            string contraseñaEncriptada = encriptado.ComputeSha256Hash(nuevaContraseña);
            int resultado = dao.CambiarContraseña(contraseñaEncriptada);
            if (string.IsNullOrWhiteSpace(nuevaContraseña))
            {
                MessageBox.Show("La contraseña no puede estar vacía.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (resultado == 1)
            {
                MessageBox.Show("Contraseña cambiada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objcambio.Hide();
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
    }
}
