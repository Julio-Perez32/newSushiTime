using Sushi_Time_PTC_2024.Controlador.Helpers;
using Sushi_Time_PTC_2024.Vista;
using System.Data;
using System.Windows.Forms;
using System;
using WindowsFormsApp1.Modelo.DAO;
using WindowsFormsApp1.Vista.Usuarios;
using WindowsFormsApp1.Vista.Primer_Uso;
using Sushi_Time_PTC_2024.Modelo.DAO;
using System.Collections.Generic;

namespace WindowsFormsApp1.Controlador.AdministracionUsuario
{
    internal class CUsuarios
    {
        dgvususarios objAdminU;
        public CUsuarios(dgvususarios Vista)
        {
            objAdminU = Vista;
            objAdminU.Load += new EventHandler(LoadData);
            objAdminU.btnCrearUsuario.Click += new EventHandler(NewUser);
            objAdminU.btnEditar.Click += new EventHandler(UpdateUser);
            objAdminU.btnEliminar.Click += new EventHandler(DeleteUser);
        }



        public void LoadData(object sender, EventArgs e)
        {
            RefrescarData();
        }
       
        public void RefrescarData()
        {
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
                string usuario, Correo, userStatus, nombre, apellido, dui, direccion, telefono, rol;
                int idUsuario;
                DateTime fechaCreacion;
                idUsuario = int.Parse(objAdminU.dgvusuario[0, pos].Value.ToString());
               // intentos = int.Parse(objAdminU.dgvusuario[1, pos].Value.ToString());
                Correo = objAdminU.dgvusuario[2, pos].Value.ToString();
               // Contraseña = objAdminU.dgvusuario[3, pos].Value.ToString();
                usuario = objAdminU.dgvusuario[4, pos].Value.ToString();
                userStatus = objAdminU.dgvusuario[5, pos].Value.ToString();
                nombre = objAdminU.dgvusuario[6, pos].Value.ToString();
                apellido = objAdminU.dgvusuario[7, pos].Value.ToString();
                dui = objAdminU.dgvusuario[8, pos].Value.ToString();
                direccion = objAdminU.dgvusuario[9, pos].Value.ToString();
                telefono = objAdminU.dgvusuario[10, pos].Value.ToString();
                fechaCreacion = DateTime.Parse(objAdminU.dgvusuario[11, pos].Value.ToString());
                rol = objAdminU.dgvusuario[12, pos].Value.ToString();


                editarUsuarios objnuevoo = new editarUsuarios(2, idUsuario, rol, Correo, usuario, userStatus, fechaCreacion, nombre, apellido, dui, direccion, telefono);
                objnuevoo.ShowDialog();
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
            string userSelected = objAdminU.dgvusuario[6, pos].Value.ToString();
            if (!(userSelected.Equals(SessionVar.Username)))
            {
                if (MessageBox.Show($"• Se eliminará la información de la persona.\n\n• ¿Esta seguro que desea elimar a: {objAdminU.dgvusuario[6, pos].Value.ToString()}, considere que dicha acción no se podrá revertir.", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAOUsuarios daoDel = new DAOUsuarios();
                    daoDel.IdUsuario = int.Parse(objAdminU.dgvusuario[0, pos].Value.ToString());
                    int valorRetornado = daoDel.EliminarUsuario();
                    if (valorRetornado == 2)
                    {
                        MessageBox.Show("Registro eliminado", "Acción completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefrescarData();
                    }
                }
            }
            else
            {
                MessageBox.Show("No puede eliminar al usuario ya que la sesión está activa, cierre sesión en todos los dispositivos y vuelva a intentarlo.", "Error de proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}