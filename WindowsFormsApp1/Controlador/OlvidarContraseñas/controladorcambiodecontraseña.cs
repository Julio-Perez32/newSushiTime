using Sushi_Time_PTC_2024.Controlador.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Modelo.DAO;
using WindowsFormsApp1.Modelo.DTO;

using WindowsFormsApp1.Vista.Olvidar_contraseña;






namespace Sushi_Time_PTC_2024.Controlador
    {
    internal class ControladorCambioDeContraseña
    {
        private cambiodecontraseña objFormCambioDeContraseña;
        private Encriptado encriptado;
        private DAOCambiarContraseña daoCambiarContraseña;

        public ControladorCambioDeContraseña(cambiodecontraseña vista)
        {
            objFormCambioDeContraseña = vista;
            daoCambiarContraseña = new DAOCambiarContraseña();

            // Asignar evento al botón de cambiar contraseña
            objFormCambioDeContraseña.Btncambiarcontra.Click += new EventHandler(CambiarContraseña);
        }

        private void CambiarContraseña(object sender, EventArgs e)
        {
            // Obtener la nueva contraseña del TextBox
            string nuevaContraseña = objFormCambioDeContraseña.txtnuevacontraseña.Text;
            // Aquí debes obtener el id del usuario, asumiendo que ya lo tienes definido en algún lugar

            

            // Asegúrate de que la instancia de Encriptado está creada correctamente
            Encriptado encriptado = new Encriptado(); // Esto debería estar al inicio de tu controlador

            // Encriptar la nueva contraseña
            string contraseñaEncriptada = encriptado.ComputeSha256Hash(nuevaContraseña);

            // Llama al DAO para cambiar la contraseña
            int resultado = daoCambiarContraseña.CambiarContraseña(contraseñaEncriptada);

            // Manejar el resultado
            if (resultado == 1)
            {
                MessageBox.Show("Contraseña cambiada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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





