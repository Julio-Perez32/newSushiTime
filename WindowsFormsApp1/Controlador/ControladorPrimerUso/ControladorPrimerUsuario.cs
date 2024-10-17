using System;
using System.Collections.Generic;
using System.Linq;
using Sushi_Time_PTC_2024.Vista;
using System.Data;
using WindowsFormsApp1.Vista.Primer_Uso;
using WindowsFormsApp1.Modelo.DAO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Modelo.DTO;
using Sushi_Time_PTC_2024.Modelo.DTO;
using Sushi_Time_PTC_2024.Controlador.Helpers;
using System.Runtime.Remoting;

namespace WindowsFormsApp1.Controlador.ControladorPrimerUso
{
    internal class ControladorPrimerUsuario
    {
        CrearPrimerUsuario ObjVista;
        DAOPrimerUsuario daoUsuario;

        public ControladorPrimerUsuario(CrearPrimerUsuario Vista)
        {
            ObjVista = Vista;

            Vista.Load += new EventHandler(CargarCombo);
            Vista.btnGuardar.Click += new EventHandler(RegistrarPrimerUsuario);
            Vista.comboRol.Enabled = true;
            ObjVista.pbSalir.Click += new EventHandler(QuitApplication);
            ObjVista.txtNombre.KeyPress += new KeyPressEventHandler(TxtDescripcionTarea_KeyPress);
            ObjVista.txtApellido.KeyPress += new KeyPressEventHandler(TxtDescripcionTarea_KeyPress);
            ObjVista.txtTelefono.KeyPress += new KeyPressEventHandler(TxtSoloNumeros_KeyPress);
        }

        void CargarCombo(object sender, EventArgs e)
        {
            DAOPrimerUsuario objAdmin = new DAOPrimerUsuario();
            DataSet ds = objAdmin.LlenarCombo();
            DataTable dt = ds.Tables["tbRol"];
            DataRow[] rows = dt.Select("nombreRol = 'Administrador'");
            if (rows.Length > 0)
            {
                DataTable dtFiltered = rows.CopyToDataTable();
                ObjVista.comboRol.DataSource = dtFiltered;
                ObjVista.comboRol.ValueMember = "idRol";
                ObjVista.comboRol.DisplayMember = "nombreRol";
            }
            else
            {
                MessageBox.Show("No se encontró el rol de Administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void RegistrarPrimerUsuario(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(ObjVista.txtNombre.Text.Trim()) ||
                string.IsNullOrEmpty(ObjVista.txtApellido.Text.Trim()) ||
                string.IsNullOrEmpty(ObjVista.mskDocumento.Text) ||
                string.IsNullOrEmpty(ObjVista.txtDireccion.Text.Trim()) ||
                string.IsNullOrEmpty(ObjVista.txtEmail.Text.Trim()) ||
                string.IsNullOrEmpty(ObjVista.txtTelefono.Text.Trim()) ||
                string.IsNullOrEmpty(ObjVista.txtUsuario.Text.Trim())))
            {
                DAOPrimerUsuario DAOInsert = new DAOPrimerUsuario();
                Encriptado encriptado = new Encriptado();
                DAOInsert.Nombre = ObjVista.txtNombre.Text.Trim();
                DAOInsert.Apellido = ObjVista.txtApellido.Text.Trim();
                DAOInsert.FechaCreacion = ObjVista.dtFecha.Value.Date;
                DAOInsert.Dui = ObjVista.mskDocumento.Text;
                DAOInsert.Direccion = ObjVista.txtDireccion.Text.Trim();
                DAOInsert.Correo = ObjVista.txtEmail.Text.Trim();
                DAOInsert.Telefono = ObjVista.txtTelefono.Text.Trim();
                DAOInsert.Usuario = ObjVista.txtUsuario.Text.Trim();
                DAOInsert.Contraseña = encriptado.ComputeSha256Hash(ObjVista.txtUsuario.Text.Trim() + "SushiTime24");
                DAOInsert.UserStatus = "Activo";
                DAOInsert.Intentos = 0;
                DAOInsert.Rol = int.Parse(ObjVista.comboRol.SelectedValue.ToString());
                int valorRetornado = DAOInsert.RegistrarUsuario();
                if (valorRetornado == 1)
                {
                    MessageBox.Show("Los datos han sido registrados exitosamente",
                                    "Proceso completado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    MessageBox.Show($"Usuario administrador: {ObjVista.txtUsuario.Text.Trim()}\nContraseña de usuario: {ObjVista.txtUsuario.Text.Trim()}SushiTime24",
                                    "Credenciales de acceso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    Logincs login = new Logincs();
                    login.Show();
                    ObjVista.Hide();
                }
                else
                {
                    MessageBox.Show("Los datos no pudieron ser registrados",
                                    "Proceso interrumpido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Existen campos vacíos, complete cada uno de los apartados y verifique que la fecha seleccionada corresponde a una persona mayor de edad.",
                                    "Proceso interrumpido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
            }
        }
        private void QuitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void TxtDescripcionTarea_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar))
            {

                e.Handled = true;
                MessageBox.Show("No se permiten números en este campo.",
                                "Entrada no válida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
        private void TxtSoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si el carácter ingresado es una letra o un carácter de control (como la tecla de retroceso)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // No permitir la entrada de caracteres que no sean dígitos
                MessageBox.Show("Solo se permiten números en este campo.",
                                "Entrada no válida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
    }
}
