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
using Sushi_Time_PTC_2024.Modelo.DTO;

namespace WindowsFormsApp1.Controlador.AdministracionUsuarios
{
    internal class controladorCambiarContra
    {
        CambioDeContraseña objcontraseña;
        DAOCambiarContraseña daocambiarcontraseña;
        public controladorCambiarContra(CambioDeContraseña vista)
        {
            objcontraseña = vista;
            daocambiarcontraseña = new DAOCambiarContraseña();
            objcontraseña.btnGuardarC.Click += new EventHandler(cambiandocontra);
            objcontraseña.pbSalir.Click += new EventHandler(salir);
        }

        private void cambiandocontra(object sender, EventArgs e)
        {
            string nuevaContraseña = objcontraseña.txtnuevacontraseña.Text;

            // Validar si el campo está vacío o contiene solo espacios en blanco
            if (string.IsNullOrWhiteSpace(nuevaContraseña))
            {
                MessageBox.Show("El campo de la contraseña no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método si la contraseña es inválida
            }

            Encriptado encriptado = new Encriptado();
            string contraseñaEncriptada = encriptado.ComputeSha256Hash(nuevaContraseña);
            int resultado = daocambiarcontraseña.CambiarContraseña(contraseñaEncriptada);

            if (resultado == 1)
            {
                MessageBox.Show("Contraseña cambiada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objcontraseña.Hide();
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

        private void salir(object sender, EventArgs e)
        {
            objcontraseña.Hide();
        }
    }
}
