using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Modelo.DAO;
using WindowsFormsApp1.Vista.Olvidar_contraseña;
using Sushi_Time_PTC_2024.Controlador.Helpers;





namespace WindowsFormsApp1.Controlador.OlvidarContraseñas
{
    internal class ControllerContraseñaAdmi2
    {
        SqlCommand command = new SqlCommand();

        RecuperacionDentrodelSistema objUsuarios;
        RecuperacionContraseña formNuevaContraseñAdmi;
        private RecuperacionDentrodelSistema recuperacionDentrodelSistema;
        private int action;

        public ControllerContraseñaAdmi2(RecuperacionContraseña vista, int action)
        {
            objUsuarios = vista;
        }

        public ControllerContraseñaAdmi2(RecuperacionDentrodelSistema recuperacionDentrodelSistema, RecuperacionContraseña formNuevaContraseñAdmi)
        {
            this.formNuevaContraseñAdmi = formNuevaContraseñAdmi;
        }

        public ControllerContraseñaAdmi2(RecuperacionDentrodelSistema recuperacionDentrodelSistema, int action)
        {
            this.recuperacionDentrodelSistema = recuperacionDentrodelSistema;
            this.action = action;
        }

        void IngresarContraseña(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(objUsuarios.txtUsuarioAfectado.Text) || string.IsNullOrEmpty(objUsuarios.txtPassword.Text) || string.IsNullOrEmpty(objUsuarios.BtnConfirmarNuevaContra.Text)))
            {
                if (objUsuarios.txtPassword.Text.Trim() == objUsuarios.BtnConfirmarNuevaContra.Text.Trim())
                {
                    Encriptado common = new Encriptado();
                    DAOComprobarContraseñaAdmi daoRestaurar = new DAOComprobarContraseñaAdmi();
                    daoRestaurar.Usuario1 = objUsuarios.txtUsuarioAfectado.Text.Trim();
                    string PasswordEncript = common.ComputeSha256Hash(objUsuarios.txtPassword.Text.Trim());
                    daoRestaurar.Contraseña1 = PasswordEncript;
                    int Confirmar = daoRestaurar.NewPassword();
                    if (Confirmar == 1)
                    {
                        MessageBox.Show("Nueva Contraseña ingresada con exito", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        objUsuarios.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Hubo problemas para ingresar la nueva contraseña", "Proceso Interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(" Llene todos los campos para completar el proceso", "Proceso interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
