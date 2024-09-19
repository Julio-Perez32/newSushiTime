using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sushi_Time_PTC_2024.Modelo.DAO;
using Sushi_Time_PTC_2024.Vista;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
            DAOPrimerUso daoPrimerUso = new DAOPrimerUso();

            int totalUsuarios = daoPrimerUso.VerificarRegistroUsuario();

            if (totalUsuarios == -1)
            {
                MessageBox.Show("Error al verificar los registros de usuarios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (totalUsuarios > 0)
            //{
              //  MessageBox.Show("Ya existe un usuario registrado. No se puede registrar otro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //return;
            //}

            // Validaciones para el campo "Usuario"
            string usuario = ObjVista.txtRegistrarUsuario.Text.Trim();
            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show("Ingrese un Usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (usuario.Length > 200)
            {
                MessageBox.Show("El Usuario no puede exceder los 200 caracteres.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(usuario, @"^[a-zA-Z0-9\s]+$"))
            {
                MessageBox.Show("El Usuario solo puede contener letras y números.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validaciones para el campo "Correo"
            string correo = ObjVista.txtIngresarCorreo.Text.Trim();
            if (string.IsNullOrWhiteSpace(correo))
            {
                MessageBox.Show("Ingrese un Correo Electronico.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (correo.Length > 100)
            {
                MessageBox.Show("El Correo no puede exceder los 100 caracteres.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!correo.Contains("@"))
            {
                MessageBox.Show("El Correo deber contener '@'.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validaciones para el campo "Contraseña"
            string contraseña = ObjVista.txtRegistrarContraseña.Text.Trim();
            if (string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Ingrese una contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (contraseña.Length > 100)
            {
                MessageBox.Show("La Contraseña no puede exceder el maximo de 100 caracteres.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si todas las validaciones son correctas, se registra el usuario.
            daoPrimerUso.Usuario = usuario;
            daoPrimerUso.Contraseña = contraseña;
            daoPrimerUso.Correo = correo;

            bool registroExitoso = daoPrimerUso.RegistrarUsuario();

            if (registroExitoso)
            {
                MessageBox.Show("Usuario registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Aquí abrimos la nueva vista de Login
                Logincs vistaLogin = new Logincs();
                vistaLogin.Show();

                ObjVista.Hide();
            }
            else
            {
                MessageBox.Show("Error al registrar el usuario. Intenta de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
