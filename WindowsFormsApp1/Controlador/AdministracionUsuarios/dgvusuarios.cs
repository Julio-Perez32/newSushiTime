using Sushi_Time_PTC_2024.Controlador.Helpers;
using Sushi_Time_PTC_2024.Modelo.DAO;
using Sushi_Time_PTC_2024.Vista;
using Sushi_Time_PTC_2024.Vista.Administración_de_Empleados;
using Sushi_Time_PTC_2024.Vista.Asignacion_de_Funciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Modelo.DAO;
using WindowsFormsApp1.Vista.Asignacion_de_Funciones;

namespace WindowsFormsApp1.Controlador.AdministracionUsuarios
{
    internal class dgvusuarios
    {
        Usuarios objAdminU;
        PrimerUso_ objagg;
        public dgvusuarios(Usuarios Vista)
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
            DAOUsuarios dAOadminU = new DAOUsuarios();
            DataSet ds = dAOadminU.Obtenerempleados();
            objAdminU.dgvusuario.DataSource = ds.Tables["VistaUsuario"];

            foreach (DataGridViewColumn column in objAdminU.dgvusuario.Columns)
            {
                column.ReadOnly = true;
            }
        }
        private void NewUser(object sender, EventArgs e)
        {

            PrimerUso_ openForm = new PrimerUso_();
            openForm.ShowDialog();
            RefrescarData();
        }



        private void UpdateUser(object sender, EventArgs e)
        {
            try
            {
                int pos = objAdminU.dgvusuario.CurrentRow.Index;
                string Usuario, Contraseña, Correo;
                int idUsuario;
                idUsuario = int.Parse(objAdminU.dgvusuario[0, pos].Value.ToString());
                Usuario = objAdminU.dgvusuario[1, pos].Value.ToString();
                Contraseña = objAdminU.dgvusuario[2, pos].Value.ToString();
                Correo = objAdminU.dgvusuario[3, pos].Value.ToString();

                EdicionU objnuevo = new EdicionU(idUsuario, Usuario, Contraseña, Correo);
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
            string userSelected = objAdminU.dgvusuario[1, pos].Value.ToString();
            if (!(userSelected.Equals(SessionVar.Username)))
            {
                if (MessageBox.Show($"• Se eliminará la información de la persona.\n\n• ¿Esta seguro que desea elimar a: {objAdminU.dgvusuario[1, pos].Value.ToString()}, considere que dicha acción no se podrá revertir.", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
