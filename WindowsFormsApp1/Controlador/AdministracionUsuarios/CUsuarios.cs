using Sushi_Time_PTC_2024.Controlador.Helpers;
using Sushi_Time_PTC_2024.Vista;
using System.Data;
using System.Windows.Forms;
using System;
using WindowsFormsApp1.Modelo.DAO;
using WindowsFormsApp1.Vista.Usuarios;
using WindowsFormsApp1.Vista.Primer_Uso;
using Sushi_Time_PTC_2024.Modelo.DAO;
using WindowsFormsApp1.Controlador.Helpers;

namespace WindowsFormsApp1.Controlador.AdministracionUsuario
{
    internal class CUsuarios
    {
        dgvususarios objAdminU;
        CrearPrimerUsuario objagg;
        public CUsuarios(dgvususarios Vista)
        {
            objAdminU = Vista;
            objAdminU.Load += new EventHandler(LoadData);
            objAdminU.btnCrearUsuario.Click += new EventHandler(NewUser);
            objAdminU.btnEditar.Click += new EventHandler(UpdateUser);
            objAdminU.btnEliminar.Click += new EventHandler(DeleteUser);
            objAdminU.btnBuscar.Click += new EventHandler(BuscarPeronasControllerEvent);
        }

        public void Search(object sender, KeyEventArgs e)
        {
            BuscarPeronasController();
        }

        public void BuscarPeronasControllerEvent(object sender, EventArgs e) { BuscarPeronasController(); }
        void BuscarPeronasController()
        {
            // Crear instancia del DAO
            DAOUsuarios dao = new DAOUsuarios();

            // Obtener el valor que el usuario está escribiendo
            string valorBusqueda = objAdminU.txtbuscarT.Text.Trim(); // Trim para evitar espacios vacíos

            // Verificar que el valor de búsqueda no esté vacío y que tenga al menos 2 caracteres
            if (string.IsNullOrEmpty(valorBusqueda) || valorBusqueda.Length < 2)
            {
                // Si el cuadro de búsqueda está vacío, mostrar todos los datos o restaurar la tabla completa
                DataSet ds = dao.Obtenerempleados();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables["VistaUsuario"].Rows.Count > 0)
                {
                    objAdminU.dgvusuario.DataSource = ds.Tables["VistaUsuario"];
                }
                else
                {
                    objAdminU.dgvusuario.DataSource = null; // Limpiar si no hay datos
                }
                return;
            }

            // Ejecutar la búsqueda
            DataSet resultadoBusqueda = dao.BuscarPersonas(valorBusqueda);

            if (resultadoBusqueda != null && resultadoBusqueda.Tables.Count > 0 && resultadoBusqueda.Tables["VistaUsuario"].Rows.Count > 0)
            {
                // Llenar el DataGridView con los resultados de la búsqueda
                objAdminU.dgvusuario.DataSource = resultadoBusqueda.Tables["VistaUsuario"];
            }
            else
            {
                // Si no hay resultados, vaciar el DataGridView sin mostrar mensajes
                objAdminU.dgvusuario.DataSource = null;
            }
        }



        public void LoadData(object sender, EventArgs e)
        {
            RefrescarData();
        }

        public void RefrescarData()
        {
            DAOUsuarios dAOadminU = new DAOUsuarios();
            DataSet ds = dAOadminU.Obtenerempleados();
            objAdminU.dgvusuario.DataSource = ds.Tables["VistaUsuario"];

            foreach (DataGridViewColumn column in objAdminU.dgvusuario.Columns)
            {
                column.ReadOnly = true;
            }
            objAdminU.dgvusuario.DataSource = ds.Tables["VistaUsuario"];
            objAdminU.dgvusuario.Columns[1].Visible = false;
            objAdminU.dgvusuario.Columns[3].Visible = false;
            objAdminU.dgvusuario.Columns[5].Visible = false;
            objAdminU.dgvusuario.Columns[9].Visible = false;
        }
        private void NewUser(object sender, EventArgs e)
        {

            editarUsuarios openForm = new editarUsuarios(1);
            openForm.ShowDialog();
            RefrescarData();
        }



        private void UpdateUser(object sender, EventArgs e)
        {
            try
            {
                int pos = objAdminU.dgvusuario.CurrentRow.Index;
                string usuario, Correo, userStatus, nombre, apellido, dui, direccion, telefono, rol, Contraseña;
                int idUsuario, intentos;
                DateTime fechaCreacion;
                idUsuario = int.Parse(objAdminU.dgvusuario[0, pos].Value.ToString());
                intentos = int.Parse(objAdminU.dgvusuario[1, pos].Value.ToString());
                Correo = objAdminU.dgvusuario[2, pos].Value.ToString();
                Contraseña = objAdminU.dgvusuario[3, pos].Value.ToString();
                usuario = objAdminU.dgvusuario[4, pos].Value.ToString();
                userStatus = objAdminU.dgvusuario[5, pos].Value.ToString();
                nombre = objAdminU.dgvusuario[6, pos].Value.ToString();
                apellido = objAdminU.dgvusuario[7, pos].Value.ToString();
                dui = objAdminU.dgvusuario[8, pos].Value.ToString();
                direccion = objAdminU.dgvusuario[9, pos].Value.ToString();
                telefono = objAdminU.dgvusuario[10, pos].Value.ToString();
                fechaCreacion = DateTime.Parse(objAdminU.dgvusuario[11, pos].Value.ToString());
                rol = objAdminU.dgvusuario[12, pos].Value.ToString();


                editarUsuarios objnuevo = new editarUsuarios(2, idUsuario, rol, Correo, usuario, userStatus, fechaCreacion, nombre, apellido, dui, direccion, telefono);
                objnuevo.ShowDialog();
                RefrescarData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el usuario: {ex.Message}\n{ex.StackTrace}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private void DeleteUser(object sender, EventArgs e)
        {
            int pos = objAdminU.dgvusuario.CurrentRow.Index;
            string userSelected = objAdminU.dgvusuario[4, pos].Value.ToString();

            // Verifica si el usuario seleccionado no es el usuario actual en sesión
            if (!userSelected.Equals(SessionInfo.UsernameActual))
            {
                if (MessageBox.Show($"• Se eliminará la información de la persona.\n\n• ¿Está seguro que desea eliminar a: {objAdminU.dgvusuario[6, pos].Value.ToString()}? Considere que dicha acción no se podrá revertir.", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAOUsuarios daoDel = new DAOUsuarios();
                    daoDel.IdUsuario = int.Parse(objAdminU.dgvusuario[0, pos].Value.ToString());

                    // Llama a EliminarUsuario con el IdUsuarioActual de la sesión
                    int valorRetornado = daoDel.EliminarUsuario(SessionInfo.IdUsuarioActual);

                    if (valorRetornado == 1)
                    {
                        MessageBox.Show("Registro eliminado", "Acción completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (valorRetornado == 0)
                    {
                        MessageBox.Show("No se pudo eliminar el usuario actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No puede eliminar al usuario ya que la sesión está activa, cierre sesión en todos los dispositivos y vuelva a intentarlo.", "Error de proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RefrescarData();
        }

        void RestaurarContra(object sender, EventArgs e)
        {
            DAOadminU daoRestartPassword = new DAOadminU();
            Encriptado commonClasses = new Encriptado();
            int pos = objAdminU.dgvusuario.CurrentRow.Index;
            string firstName = objAdminU.dgvusuario[1, pos].Value.ToString();
            string lastName = objAdminU.dgvusuario[2, pos].Value.ToString();
            string nombrePersona = firstName + " " + lastName;
            string emailDestinatario = objAdminU.dgvusuario[6, pos].Value.ToString();
            daoRestartPassword.Usuario1 = objAdminU.dgvusuario[8, pos].Value.ToString();
        }

    }
}
