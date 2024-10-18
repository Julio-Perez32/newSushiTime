using Sushi_Time_PTC_2024.Controlador.Helpers;
using Sushi_Time_PTC_2024.Vista;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Modelo.DAO;
using WindowsFormsApp1.Vista.Primer_Uso;
using WindowsFormsApp1.Vista.Usuarios;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static TheArtOfDev.HtmlRenderer.Adapters.RGraphicsPath;

namespace WindowsFormsApp1.Controlador.AdministracionUsuarios
{
    internal class ControladorAU
    {
        //CrearPrimerUsuario objagg;
        private int accion;
        private string Rol;
        editarUsuarios objed;
        CambioDeContraseña objcontraseña;
        public ControladorAU(editarUsuarios vista, int accion)
        {
            objed = vista;
            this.accion = accion;
            VerificarAccion();
            objed.Load += new EventHandler(InitialCharge);
            objed.btnCrear.Click += new EventHandler(NewRegister);
            objed.btnCancelar.Click += new EventHandler(minimizar);
            objed.txtNombre.KeyPress += new KeyPressEventHandler(TxtDescripcionTarea_KeyPress);
            objed.txtApellido.KeyPress += new KeyPressEventHandler(TxtDescripcionTarea_KeyPress);
            objed.txtUserStatus.KeyPress += new KeyPressEventHandler(TxtDescripcionTarea_KeyPress);
            objed.txtTelefono.KeyPress += new KeyPressEventHandler(TxtSoloNumeros_KeyPress);
        }
        public ControladorAU(editarUsuarios vista, int p_accion, int idUsuario, string Rol, string correo, string userStatus, string usuario, DateTime fechaCreacion, string nombre, string apellido, string dui, string direccion, string telefono)
        {
            objed = vista;
            this.Rol = Rol;
            this.accion = p_accion;
            objed.Load += new EventHandler(InitialCharge);
            ChargeValues(idUsuario, correo, userStatus, usuario, fechaCreacion, nombre, apellido, dui, direccion, telefono);
            objed.btnEdicionC.Click += new EventHandler(UpdateRegister);
            objed.btnCancelar.Click += new EventHandler(minimizar);
            objed.txtNombre.KeyPress += new KeyPressEventHandler(TxtDescripcionTarea_KeyPress);
            objed.txtApellido.KeyPress += new KeyPressEventHandler(TxtDescripcionTarea_KeyPress);
            objed.txtUserStatus.KeyPress += new KeyPressEventHandler(TxtDescripcionTarea_KeyPress);
            objed.txtTelefono.KeyPress += new KeyPressEventHandler(TxtSoloNumeros_KeyPress);

            VerificarAccion();
        }

        public void UpdateRegister(object sender, EventArgs e)
        {
            // Validaciones de los campos de texto
            if (string.IsNullOrWhiteSpace(objed.txtid.Text) ||
                string.IsNullOrWhiteSpace(objed.txtUsuario.Text.Trim()) ||
                string.IsNullOrWhiteSpace(objed.txtNombre.Text.Trim()) ||
                string.IsNullOrWhiteSpace(objed.mskDocumento.Text.Trim()) ||
                string.IsNullOrWhiteSpace(objed.txtEmail.Text.Trim()) ||
                string.IsNullOrWhiteSpace(objed.txtTelefono.Text.Trim()) ||
                string.IsNullOrWhiteSpace(objed.txtApellido.Text.Trim()) ||
                string.IsNullOrWhiteSpace(objed.txtDireccion.Text.Trim()) ||
                string.IsNullOrWhiteSpace(objed.txtUserStatus.Text.Trim()) ||
                string.IsNullOrWhiteSpace(objed.dtFecha.Text.Trim()))
            {
                MessageBox.Show("Existen campos vacíos. Por favor complete todos los campos requeridos.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; // Salir del método si hay campos vacíos
            }

            // Validar el formato del correo electrónico
            string email = objed.txtEmail.Text.Trim();
            if (!ValidarCorreo(email)) // Supón que tienes un método ValidarCorreo
            {
                MessageBox.Show("El formato del correo electrónico es inválido.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; // Salir del método si el correo no es válido
            }

            // Validar la fecha de creación
            DateTime fechaCreacion;
            if (!DateTime.TryParse(objed.dtFecha.Text.Trim(), out fechaCreacion))
            {
                MessageBox.Show("La fecha de nacimiento no es válida. El usuario debe ser mayor de edad",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; // Salir del método si la fecha no es válida
            }

            DAOUsuarios daoUpdate = new DAOUsuarios();
            Encriptado encriptado = new Encriptado();

            // Asigna los valores desde los campos de texto
            daoUpdate.IdUsuario = int.Parse(objed.txtid.Text.Trim());
            daoUpdate.Rol = int.Parse(objed.comboRol.SelectedValue.ToString());
            daoUpdate.Usuario = objed.txtUsuario.Text.Trim();
            daoUpdate.Nombre = objed.txtNombre.Text.Trim();
            daoUpdate.Dui = objed.mskDocumento.Text.Trim();
            daoUpdate.Correo = email; // Utiliza el email validado
            daoUpdate.Telefono = objed.txtTelefono.Text.Trim();
            daoUpdate.Apellido = objed.txtApellido.Text.Trim();
            daoUpdate.Direccion = objed.txtDireccion.Text.Trim();
            daoUpdate.FechaCreacion = fechaCreacion; // Utiliza la fecha validada
            daoUpdate.UserStatus = objed.txtUserStatus.Text.Trim();

            int valorRetornado = daoUpdate.ActualizarUsuario();

            // Verifica el valor de retorno
            if (valorRetornado == 1)
            {
                MessageBox.Show("Los datos han sido actualizados exitosamente",
                                "Proceso completado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                objed.Hide();
            }
            else if (valorRetornado == 0)
            {
                MessageBox.Show("Los datos no pudieron ser actualizados completamente",
                                "Proceso interrumpido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser actualizados debido a un error inesperado",
                                "Proceso interrumpido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }





        public void ChargeValues(int idUsuario, string correo, string usuario, string userStatus, DateTime fechaCreacion, string nombre, string apellido, string dui, string direccion, string telefono)
        {
            try
            {
                objed.txtid.Text = idUsuario.ToString();
                objed.txtEmail.Text = correo;
                objed.txtUsuario.Text = usuario;
                objed.txtNombre.Text = nombre;
                objed.txtTelefono.Text = telefono;
                objed.txtApellido.Text = apellido;
                objed.dtFecha.Value = fechaCreacion;
                objed.mskDocumento.Text = dui;
                objed.txtDireccion.Text = direccion;
                objed.txtUserStatus.Text = userStatus;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

        }
        public void VerificarAccion()
        {

            if (accion == 1)
            {
                objed.btnEdicionC.Enabled = false;
                objed.btnCrear.Enabled = true;
                objed.txtUserStatus.Enabled = false;
            }
            else if (accion == 2)
            {
                objed.btnEdicionC.Enabled = true;
                objed.btnCrear.Enabled = false;
                objed.txtUserStatus.Enabled = true;
            }
            objed.txtid.Enabled = false;
        }




        void NewRegister(object sender, EventArgs e)
        {
            // Validar campos vacíos
            if (!(string.IsNullOrEmpty(objed.txtNombre.Text.Trim()) ||
                  string.IsNullOrEmpty(objed.txtApellido.Text.Trim()) ||
                  string.IsNullOrEmpty(objed.mskDocumento.Text) ||
                  string.IsNullOrEmpty(objed.txtDireccion.Text.Trim()) ||
                  string.IsNullOrEmpty(objed.txtEmail.Text.Trim()) ||
                  string.IsNullOrEmpty(objed.txtTelefono.Text.Trim()) ||
                  string.IsNullOrEmpty(objed.txtUsuario.Text.Trim()) ||
                  string.IsNullOrEmpty(objed.txtUserStatus.Text.Trim())))
            {
                // Validar el correo electrónico
                string email = objed.txtEmail.Text.Trim();
                if (!ValidarCorreo(email))
                {
                    return; // Salir si el correo no es válido
                }

                // Validar la fecha de creación (mayor de edad)
                DateTime fechaCreacion = objed.dtFecha.Value.Date;
                if (fechaCreacion > DateTime.Now.AddYears(-18))
                {
                    MessageBox.Show("El usuario debe ser mayor de edad. Verifique la fecha de nacimiento.", "Proceso interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Salir si no es mayor de edad
                }

                // Continuar con el registro del usuario
                DAOUsuarios DAOInsert = new DAOUsuarios();
                Encriptado encriptado = new Encriptado();
                DAOInsert.Nombre = objed.txtNombre.Text.Trim();
                DAOInsert.Apellido = objed.txtApellido.Text.Trim();
                DAOInsert.FechaCreacion = fechaCreacion; // Aquí ya está validada la fecha
                DAOInsert.Dui = objed.mskDocumento.Text;
                DAOInsert.Direccion = objed.txtDireccion.Text.Trim();
                DAOInsert.Correo = email; // Aquí ya se validó el correo
                DAOInsert.Telefono = objed.txtTelefono.Text.Trim();
                DAOInsert.Usuario = objed.txtUsuario.Text.Trim();
                DAOInsert.Contraseña = encriptado.ComputeSha256Hash(objed.txtUsuario.Text.Trim() + "SushiTime24");
                DAOInsert.UserStatus = objed.txtUserStatus.Text.Trim();
                DAOInsert.Intentos = 0;
                DAOInsert.Rol = int.Parse(objed.comboRol.SelectedValue.ToString());

                int valorRetornado = DAOInsert.RegistrarUsuario();

                if (valorRetornado == 1)
                {
                    MessageBox.Show("Los datos han sido registrados exitosamente",
                                    "Proceso completado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    MessageBox.Show($"Usuario administrador: {objed.txtUsuario.Text.Trim()}\nContraseña de usuario: {objed.txtUsuario.Text.Trim()}SushiTime24",
                                    "Credenciales de acceso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    objed.Hide();
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

        public void InitialCharge(object sender, EventArgs e)
        {
            //Objeto de la clase DAOAdminUsuarios
            DAOPrimerUsuario objAdmin = new DAOPrimerUsuario();
            //Declarando nuevo DataSet para que obtenga los datos del metodo LlenarCombo
            DataSet ds = objAdmin.LlenarCombo();
            //Llenar combobox tbRole
            objed.comboRol.DataSource = ds.Tables["tbRol"];
            objed.comboRol.ValueMember = "idRol";
            objed.comboRol.DisplayMember = "NombreRol";
            //La condición sirve para que al actualizar un registro, el valor del registro aparezca seleccionado.
            if (accion == 2)
            {
                objed.comboRol.Text = Rol;
            }
        }
        public void minimizar(object sender, EventArgs e)
        {
            objed.Hide();
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
        private void cambiandocontra(object sender, EventArgs e)
        {
            CambioDeContraseña objcambio = new CambioDeContraseña();
            DAOCambiarContraseña dao = new DAOCambiarContraseña();
            string nuevaContraseña = objcambio.txtnuevacontraseña.Text;
            Encriptado encriptado = new Encriptado();
            string contraseñaEncriptada = encriptado.ComputeSha256Hash(nuevaContraseña);
            int resultado = dao.CambiarContraseña(contraseñaEncriptada);

            if (resultado == 1)
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
        private bool ValidarCorreo(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("El campo de correo electrónico no puede estar vacío.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!email.Contains("@"))
            {
                MessageBox.Show("Formato de correo inválido, verifica que contiene '@'.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string[] dominiosPermitidos = { "gmail.com", "ricaldone.edu.sv" };
            string extension = email.Substring(email.LastIndexOf('@') + 1);
            if (!dominiosPermitidos.Contains(extension))
            {
                MessageBox.Show("Dominio del correo es inválido. El sistema solo admite dominios 'gmail.com' y 'correo institucional'.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}