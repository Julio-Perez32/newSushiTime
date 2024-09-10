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
            DAOPrimerUso daoPrimerUso = new DAOPrimerUso();

            int totalUsuarios = daoPrimerUso.VerificarRegistroUsuario();

            if (totalUsuarios == -1)
            {
                MessageBox.Show("Error al verificar los registros de usuarios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (totalUsuarios > 0)
            {
                MessageBox.Show("Ya existe un usuario registrado. No se puede registrar otro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(string.IsNullOrEmpty(ObjVista.txtRegistrarUsuario.Text.Trim()) ||
                  string.IsNullOrEmpty(ObjVista.txtRegistrarContraseña.Text.Trim()) ||
                  string.IsNullOrEmpty(ObjVista.txtIngresarCorreo.Text.Trim())))
            {
                daoPrimerUso.Usuario = ObjVista.txtRegistrarUsuario.Text.Trim();
                daoPrimerUso.Contraseña = ObjVista.txtRegistrarContraseña.Text.Trim();
                daoPrimerUso.Correo = ObjVista.txtIngresarCorreo.Text.Trim();

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
            else
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
