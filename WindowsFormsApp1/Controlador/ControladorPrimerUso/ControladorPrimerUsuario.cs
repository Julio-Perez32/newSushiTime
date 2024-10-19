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
using System.Text.RegularExpressions;

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
            // Validaciones de los campos de texto
            if (string.IsNullOrWhiteSpace(ObjVista.txtNombre.Text.Trim()) ||
                string.IsNullOrWhiteSpace(ObjVista.txtApellido.Text.Trim()) ||
                string.IsNullOrWhiteSpace(ObjVista.mskDocumento.Text.Trim()) ||
                string.IsNullOrWhiteSpace(ObjVista.txtDireccion.Text.Trim()) ||
                string.IsNullOrWhiteSpace(ObjVista.txtEmail.Text.Trim()) ||
                string.IsNullOrWhiteSpace(ObjVista.txtTelefono.Text.Trim()) ||
                string.IsNullOrWhiteSpace(ObjVista.txtUsuario.Text.Trim()))
            {
                MessageBox.Show("Existen campos vacíos. Por favor complete todos los campos requeridos.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; // Salir del método si hay campos vacíos
            }

            // Validar el formato del correo electrónico
            string email = ObjVista.txtEmail.Text.Trim();
            if (!ValidarCorreo(email)) // Supón que tienes un método ValidarCorreo
            {
                MessageBox.Show("El formato del correo electrónico es inválido.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; // Salir del método si el correo no es válido
            }

            // Validar que la fecha de creación corresponda a una persona mayor de edad (mínimo 18 años)
            DateTime fechaNacimiento = ObjVista.dtFecha.Value;
            DateTime fechaActual = DateTime.Now;
            int edad = fechaActual.Year - fechaNacimiento.Year;

            if (fechaNacimiento > fechaActual.AddYears(-edad)) // Ajustar si la fecha de cumpleaños es posterior a la fecha actual
            {
                edad--;
            }

            if (edad < 18)
            {
                MessageBox.Show("Debe ser mayor de edad (mínimo 18 años) para registrarse.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; // Salir del método si el usuario es menor de edad
            }

            // Continuar con el registro del usuario si las validaciones son correctas
            DAOPrimerUsuario DAOInsert = new DAOPrimerUsuario();
            Encriptado encriptado = new Encriptado();
            DAOInsert.Nombre = ObjVista.txtNombre.Text.Trim();
            DAOInsert.Apellido = ObjVista.txtApellido.Text.Trim();
            DAOInsert.FechaCreacion = ObjVista.dtFecha.Value.Date;
            DAOInsert.Dui = ObjVista.mskDocumento.Text.Trim();
            DAOInsert.Direccion = ObjVista.txtDireccion.Text.Trim();
            DAOInsert.Correo = email; // Utiliza el email validado
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
        public bool ValidarCorreo(string email)
        {
            // Expresión regular para validar el formato general del correo electrónico
            string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Validar formato del correo electrónico
            if (!Regex.IsMatch(email, patronCorreo))
            {
                MessageBox.Show("El formato del correo no es válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Lista de dominios permitidos
            List<string> dominiosPermitidos = new List<string> { "gmail.com", "ricaldone.edu.sv" };  // Puedes agregar más dominios aquí

            // Obtener el dominio del correo
            string dominioCorreo = email.Split('@')[1];

            // Verificar si el dominio pertenece a la lista de dominios permitidos
            if (!dominiosPermitidos.Contains(dominioCorreo, StringComparer.OrdinalIgnoreCase))
            {
                MessageBox.Show("El correo debe pertenecer a uno de los siguientes dominios: " + string.Join(", ", dominiosPermitidos),
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
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
