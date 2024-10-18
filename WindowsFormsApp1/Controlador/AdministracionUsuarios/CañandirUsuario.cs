using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms.Helpers.Transitions;
using Sushi_Time_PTC_2024.Controlador.Helpers;
using Sushi_Time_PTC_2024.Modelo.DAO;
using Sushi_Time_PTC_2024.Vista.Administración_de_Empleados;
using Sushi_Time_PTC_2024.Vista.Planillas;

namespace Sushi_Time_PTC_2024.Controlador.AdministracionUsuarios
{
    internal class CañandirUsuario
    {
        AgregarUsuario ObjAddUser;
        private int accion;
        private string idCargo;
        private string role;

        public CañandirUsuario(AgregarUsuario Vista, int accion)
        {
            //Acciones iniciales
            ObjAddUser = Vista;
            this.accion = accion;
            ObjAddUser.Load += new EventHandler(InitialCharge);
            VerificarAccion();
            ObjAddUser.txtnombreA.KeyPress += new KeyPressEventHandler(TxtDescripcionTarea_KeyPress);
            ObjAddUser.txtApellidoA.KeyPress += new KeyPressEventHandler(TxtDescripcionTarea_KeyPress);
            ObjAddUser.txtTelefonoA.KeyPress += new KeyPressEventHandler(TxtSoloNumeros_KeyPress);
            ObjAddUser.txtCuentabA.KeyPress += new KeyPressEventHandler(TxtSoloNumeros_KeyPress);
            ObjAddUser.txtHijos.KeyPress += new KeyPressEventHandler(TxtSoloNumeros_KeyPress);
            ObjAddUser.txtsalario.KeyPress += new KeyPressEventHandler(TxtSoloNumeros_KeyPress);
            ObjAddUser.txtCodigoeA.KeyPress += new KeyPressEventHandler(TxtSoloNumeros_KeyPress);
            //Métodos que se ejecutan al ocurrir eventos
            ObjAddUser.Agregar.Click += new EventHandler(NewRegister);


        }


        public CañandirUsuario(AgregarUsuario Vista, int p_accion, int idEmpleado, string idCargo, string Nombre, string Apellido, string NumTelefono, string NumCuenta, string DUI, DateTime FechaNacimiento, string Direccion, string Hijos, DateTime FechaInicio, decimal Salario, DateTime FechaFin, string Correo)
        {
            ObjAddUser = Vista;
            this.accion = p_accion;
            this.idCargo = idCargo;
            VerificarAccion();
            ObjAddUser.Load += new EventHandler(InitialCharge);
            ChargeValues(idEmpleado, Nombre, Apellido, NumTelefono, NumCuenta, DUI, FechaNacimiento, Direccion, Hijos, FechaInicio, Salario, FechaFin, Correo);
            ObjAddUser.txtnombreA.KeyPress += new KeyPressEventHandler(TxtDescripcionTarea_KeyPress);
            ObjAddUser.txtApellidoA.KeyPress += new KeyPressEventHandler(TxtDescripcionTarea_KeyPress);
            ObjAddUser.txtTelefonoA.KeyPress += new KeyPressEventHandler(TxtSoloNumeros_KeyPress);
            ObjAddUser.txtCuentabA.KeyPress += new KeyPressEventHandler(TxtSoloNumeros_KeyPress);
            ObjAddUser.txtHijos.KeyPress += new KeyPressEventHandler(TxtSoloNumeros_KeyPress);
            ObjAddUser.txtsalario.KeyPress += new KeyPressEventHandler(TxtSoloNumeros_KeyPress);
            ObjAddUser.txtCodigoeA.KeyPress += new KeyPressEventHandler(TxtSoloNumeros_KeyPress);
            ObjAddUser.btnActualizar.Click += new EventHandler(UpdateRegister);

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

        public void InitialCharge(object sender, EventArgs e)
        {
            //Objeto de la clase DAOAdminUsuarios
            DAOadminU objAdmin = new DAOadminU();
            //Declarando nuevo DataSet para que obtenga los datos del metodo LlenarCombo
            DataSet ds = objAdmin.LlenarCombo();
            //Llenar combobox tbRole
            ObjAddUser.cmbCargo.DataSource = ds.Tables["CargoEmpleado"];
            ObjAddUser.cmbCargo.ValueMember = "idCargo";
            ObjAddUser.cmbCargo.DisplayMember = "NombreCargo";
            //La condición sirve para que al actualizar un registro, el valor del registro aparezca seleccionado.
            if (accion == 2)
            {
                ObjAddUser.cmbCargo.Text = idCargo;
            }
        }


        public void NewRegister(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(ObjAddUser.txtCodigoeA.Text.Trim()) ||
                string.IsNullOrEmpty(ObjAddUser.txtnombreA.Text.Trim()) ||
                string.IsNullOrEmpty(ObjAddUser.txtApellidoA.Text.Trim()) ||
                string.IsNullOrEmpty(ObjAddUser.txtTelefonoA.Text) ||
                string.IsNullOrEmpty(ObjAddUser.mskDUI.Text.Trim()) ||
                string.IsNullOrEmpty(ObjAddUser.txtDireccionA.Text.Trim()) ||
                string.IsNullOrEmpty(ObjAddUser.txtHijos.Text.Trim()) ||
                string.IsNullOrEmpty(ObjAddUser.txtCorreoA.Text.Trim())))
            {
                // Validar el correo electrónico antes de continuar
                string email = ObjAddUser.txtCorreoA.Text.Trim();
                if (!ValidarCorreo(email))
                {
                    return; // Salir si el correo no es válido
                }

                // Validar la fecha de nacimiento
                DateTime fechaNacimiento = ObjAddUser.dpNacimientoA.Value;
                if (!EsMayorDeEdad(fechaNacimiento))
                {
                    MessageBox.Show("Debe ser mayor de 18 años para poder registrarse.",
                                    "Registro no permitido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return; // Salir si no es mayor de 18 años
                }

                // Validar que la fecha de fin de contrato no sea anterior a la fecha de inicio
                DateTime fechaInicio = ObjAddUser.DPfechainicioA.Value;
                DateTime fechaFin = ObjAddUser.DPfechafinA.Value;

                if (fechaFin < fechaInicio)
                {
                    MessageBox.Show("La fecha de finalización del contrato no puede ser anterior a la fecha de inicio.",
                                    "Fecha no válida",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return; // Salir si la fecha de finalización es anterior a la de inicio
                }

                // Continuar con el registro si todos los campos son válidos
                DAOadminU DAOInsert = new DAOadminU();
                Encriptado commonClasses = new Encriptado();
                // Datos para creación de persona
                DAOInsert.IDempleado = int.Parse(ObjAddUser.txtCodigoeA.Text.Trim());
                DAOInsert.idCargo = int.Parse(ObjAddUser.cmbCargo.SelectedValue.ToString());
                DAOInsert.nombre = ObjAddUser.txtnombreA.Text.Trim();
                DAOInsert.apellido = ObjAddUser.txtApellidoA.Text.Trim();
                DAOInsert.numtelefono = ObjAddUser.txtTelefonoA.Text.Trim();
                DAOInsert.fechanacimiento = fechaNacimiento;
                DAOInsert.numcuenta = ObjAddUser.txtCuentabA.Text.Trim();
                DAOInsert.dui = ObjAddUser.mskDUI.Text.Trim();
                DAOInsert.direccion = ObjAddUser.txtDireccionA.Text.Trim();
                DAOInsert.hijos = ObjAddUser.txtHijos.Text.Trim();
                DAOInsert.salario = decimal.Parse(ObjAddUser.txtsalario.Text.Trim());
                DAOInsert.fechainicio = fechaInicio;
                DAOInsert.fechafin = fechaFin;
                DAOInsert.correo = email; // Usar el correo ya validado

                int valorRetornado = DAOInsert.RegistrarUsuario();

                // Verificar el valor que retornó el método RegistrarUsuario
                if (valorRetornado == 1)
                {
                    MessageBox.Show("Los datos han sido registrados exitosamente",
                                    "Proceso completado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ObjAddUser.Hide();
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

        // Método para validar si la persona es mayor de 18 años
        public bool EsMayorDeEdad(DateTime fechaNacimiento)
        {
            DateTime hoy = DateTime.Today;
            int edad = hoy.Year - fechaNacimiento.Year;

            // Si la fecha de nacimiento aún no ha ocurrido este año, restar un año de la edad
            if (fechaNacimiento > hoy.AddYears(-edad))
            {
                edad--;
            }

            return edad >= 18;
        }

        public void UpdateRegister(object sender, EventArgs e)
        {
            // Validar campos vacíos
            if (!(string.IsNullOrEmpty(ObjAddUser.txtCodigoeA.Text.Trim()) ||
                string.IsNullOrEmpty(ObjAddUser.txtnombreA.Text.Trim()) ||
                string.IsNullOrEmpty(ObjAddUser.txtApellidoA.Text.Trim()) ||
                string.IsNullOrEmpty(ObjAddUser.txtTelefonoA.Text) ||
                string.IsNullOrEmpty(ObjAddUser.mskDUI.Text.Trim()) ||
                string.IsNullOrEmpty(ObjAddUser.txtDireccionA.Text.Trim()) ||
                string.IsNullOrEmpty(ObjAddUser.txtHijos.Text.Trim()) ||
                string.IsNullOrEmpty(ObjAddUser.txtCorreoA.Text.Trim())))
            {
                // Validar el correo electrónico antes de continuar
                string email = ObjAddUser.txtCorreoA.Text.Trim();
                if (!ValidarCorreo(email))
                {
                    return; // Salir si el correo no es válido
                }

                // Validar la fecha de nacimiento
                DateTime fechaNacimiento = ObjAddUser.dpNacimientoA.Value;
                if (!EsMayorDeEdad(fechaNacimiento))
                {
                    MessageBox.Show("Debe ser mayor de 18 años para poder registrarse.",
                                    "Actualización no permitida",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return; // Salir si no es mayor de 18 años
                }

                // Validar que la fecha de fin de contrato no sea anterior a la fecha de inicio
                DateTime fechaInicio = ObjAddUser.DPfechainicioA.Value;
                DateTime fechaFin = ObjAddUser.DPfechafinA.Value;

                if (fechaFin < fechaInicio)
                {
                    MessageBox.Show("La fecha de finalización del contrato no puede ser anterior a la fecha de inicio.",
                                    "Fecha no válida",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return; // Salir si la fecha de finalización es anterior a la de inicio
                }

                // Continuar con la actualización de datos si todo es válido
                DAOadminU daoUpdate = new DAOadminU();
                daoUpdate.IDempleado = int.Parse(ObjAddUser.txtCodigoeA.Text.Trim());
                daoUpdate.idCargo = int.Parse(ObjAddUser.cmbCargo.SelectedValue.ToString());
                daoUpdate.nombre = ObjAddUser.txtnombreA.Text.Trim();
                daoUpdate.apellido = ObjAddUser.txtApellidoA.Text.Trim();
                daoUpdate.numtelefono = ObjAddUser.txtTelefonoA.Text.Trim();
                daoUpdate.fechanacimiento = fechaNacimiento;
                daoUpdate.numcuenta = ObjAddUser.txtCuentabA.Text.Trim();
                daoUpdate.dui = ObjAddUser.mskDUI.Text.Trim();
                daoUpdate.direccion = ObjAddUser.txtDireccionA.Text.Trim();
                daoUpdate.hijos = ObjAddUser.txtHijos.Text.Trim();
                daoUpdate.fechainicio = fechaInicio;
                daoUpdate.salario = decimal.Parse(ObjAddUser.txtsalario.Text.Trim());
                daoUpdate.fechafin = fechaFin;
                daoUpdate.correo = email; // Usar el correo ya validado

                // Validar que se haya seleccionado un cargo
                if (ObjAddUser.cmbCargo.SelectedValue != null)
                {
                    daoUpdate.idCargo = int.Parse(ObjAddUser.cmbCargo.SelectedValue.ToString());
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún cargo.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Llamar al método para actualizar el usuario
                int valorRetornado = daoUpdate.ActualizarUsuario();

                // Manejar los posibles resultados de la actualización
                if (valorRetornado == 2)
                {
                    MessageBox.Show("Los datos han sido actualizados exitosamente",
                                    "Proceso completado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else if (valorRetornado == 1)
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
            else
            {
                MessageBox.Show("Existen campos vacíos, complete cada uno de los apartados.",
                                "Proceso interrumpido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
        public void ChargeValues(int idEmpleado, string Nombre, string Apellido, string NumTelefono, string NumCuenta, string DUI, DateTime FechaNacimiento, string Direccion, string Hijos, DateTime FechaInicio, decimal salario, DateTime FechaFin, string Correo)
        {
            try
            {
                ObjAddUser.txtCodigoeA.Text = idEmpleado.ToString();
                ObjAddUser.txtnombreA.Text = Nombre;
                ObjAddUser.txtApellidoA.Text = Apellido;
                ObjAddUser.txtTelefonoA.Text = NumTelefono;
                ObjAddUser.dpNacimientoA.Value = FechaNacimiento;
                ObjAddUser.txtCuentabA.Text = NumCuenta;
                ObjAddUser.mskDUI.Text = DUI;
                ObjAddUser.txtDireccionA.Text = Direccion;
                ObjAddUser.txtHijos.Text = Hijos;
                ObjAddUser.DPfechainicioA.Value = FechaInicio;
                ObjAddUser.txtsalario.Text = salario.ToString();
                ObjAddUser.DPfechafinA.Value = FechaFin;
                ObjAddUser.txtCorreoA.Text = Correo;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

        }
        // En el método Load o similar del formulario AgregarUsuario
        public void VerificarAccion()
        {
            if (accion == 1)
            {
                ObjAddUser.btnActualizar.Enabled = false;
                ObjAddUser.Agregar.Enabled = true;
            }
            else if (accion == 2)
            {
                ObjAddUser.btnActualizar.Enabled = true;
                ObjAddUser.Agregar.Enabled = false;
            }
        }
        public bool ValidarCorreo(string email)
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

