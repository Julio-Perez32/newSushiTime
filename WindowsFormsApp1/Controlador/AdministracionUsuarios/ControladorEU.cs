using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Modelo.DAO;
using WindowsFormsApp1.Vista.Usuarios;

namespace WindowsFormsApp1.Controlador.AdministracionUsuarios
{
    internal class ControladorEU
    {
        private int accion;
        private string rol;
        editarUsuarios objed;
        public ControladorEU(editarUsuarios vista, int idUsuario, string Rol, string correo, string userStatus, string usuario, DateTime fechaCreacion, string nombre, string apellido, string dui, string direccion, string telefono)
        {
            objed = vista;
            this.rol = Rol;
            objed.Load += new EventHandler(InitialCharge);
            ChargeValues(idUsuario, Rol, correo, userStatus, usuario, fechaCreacion, nombre, apellido, dui, direccion, telefono);
            objed.btnEdicionC.Click += new EventHandler(UpdateRegister);
            objed.btnCancelar.Click += new EventHandler(minimizar);

            VerificarAccion();
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
            objed.comboRol.DisplayMember = "nombreRol";
            //La condición sirve para que al actualizar un registro, el valor del registro aparezca seleccionado.
            if (accion == 2)
            {
                objed.comboRol.Text = rol;
            }
        }

        public void UpdateRegister(object sender, EventArgs e)
        {
            DAOUsuarios daoUpdate = new DAOUsuarios();
            daoUpdate.Usuario = objed.txtUsuario.Text.Trim();
            daoUpdate.Nombre = objed.txtNombre.Text.Trim();
            daoUpdate.Dui = objed.mskDocumento.Text.Trim();
            daoUpdate.Correo = objed.txtEmail.Text.Trim();
            daoUpdate.Telefono = objed.txtTelefono.Text.Trim();
            daoUpdate.Apellido = objed.txtApellido.Text.Trim();
            daoUpdate.Rol = objed.comboRol.Text.Trim();
            daoUpdate.Direccion = objed.txtDireccion.Text.Trim();
            daoUpdate.FechaCreacion = DateTime.Parse(objed.dtFecha.Text.Trim());
            daoUpdate.IdUsuario = int.Parse(objed.txtid.Text.Trim());
            daoUpdate.UserStatus = objed.txtUserStatus.Text.Trim();


            int valorRetornado = daoUpdate.ActualizarUsuario();

            if (valorRetornado == 2)
            {
                MessageBox.Show("Los datos han sido actualizado exitosamente",
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


        public void ChargeValues(int idUsuario, string rol, string correo, string usuario, string userStatus, DateTime fechaCreacion, string nombre, string apellido, string dui, string direccion, string telefono)
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
                objed.comboRol.SelectedValue = rol;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

        }
        public void minimizar(object sender, EventArgs e)
        {
            objed.Hide();
        }
        public void VerificarAccion()
        {
            objed.txtid.Enabled = false;
        }

    }
}
