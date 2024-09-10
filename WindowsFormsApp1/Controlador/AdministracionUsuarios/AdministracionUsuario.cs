using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using Sushi_Time_PTC_2024.Controlador.Helpers;
using Sushi_Time_PTC_2024.Vista.Administración_de_Empleados;
using Sushi_Time_PTC_2024.Vista.Planillas;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Modelo.DAO;
using Sushi_Time_PTC_2024.Modelo.DTO;

namespace Sushi_Time_PTC_2024.Controlador.AdministracionUsuarios
{
    internal class AdministracionUsuarios
    {

        VerPlanilla ObjAdminUser;
        public AdministracionUsuarios(VerPlanilla Vista)
        {
            ObjAdminUser = Vista;
            ObjAdminUser.Load += new EventHandler(LoadData);
            ObjAdminUser.btnIngresar.Click += new EventHandler(NewUser);
            ObjAdminUser.btnEditar.Click += new EventHandler(UpdateUser);
            ObjAdminUser.btneliminar.Click += new EventHandler(DeleteUser);
            ObjAdminUser.txtbuscarT.KeyPress += new KeyPressEventHandler(Search);
            ObjAdminUser.btnBuscar.Click += new EventHandler(BuscarPeronasControllerEvent);

        }

        public void Search(object sender, KeyPressEventArgs e)
        {
            BuscarPeronasController();
        }

        public void BuscarPeronasControllerEvent(object sender, EventArgs e) { BuscarPeronasController(); }
        void BuscarPeronasController()
        {
            DAOadminU objAdmin = new DAOadminU();

            // Verifica que ObjAdminUser no sea nulo antes de acceder a sus propiedades
            if (ObjAdminUser == null)
            {
                MessageBox.Show("El objeto ObjAdminUser no está inicializado.");
                return;
            }

            DataSet ds = objAdmin.BuscarPersonas(ObjAdminUser.txtbuscarT.Text.Trim());

            // Verificar si ds no es nulo y contiene la tabla esperada
            if (ds != null && ds.Tables.Contains("VistaEmpleados"))
            {
                ObjAdminUser.dgvpersonas.DataSource = ds.Tables["VistaEmpleados"];
            }

        }

        public void LoadData(object sender, EventArgs e)
        {
            RefrescarData();
        }

        //DataGridView
        public void RefrescarData()
        {
            DAOadminU dAOadminU = new DAOadminU();
            DataSet ds = new DataSet();
            ds = dAOadminU.Obtenerempleados();
            ObjAdminUser.dgvpersonas.DataSource = ds.Tables["VistaEmpleados"];
            foreach (DataGridViewColumn column in ObjAdminUser.dgvpersonas.Columns)
            {
                column.ReadOnly = true;
            }
        }

        private void NewUser(object sender, EventArgs e)
        {
           
            AgregarUsuario openForm = new AgregarUsuario(1);
            openForm.ShowDialog();  
            RefrescarData();
        }

        private void UpdateUser(object sender, EventArgs e)
        {
            int pos = ObjAdminUser.dgvpersonas.CurrentRow.Index;
            AgregarUsuario openForm = new AgregarUsuario(2,
            int.Parse(ObjAdminUser.dgvpersonas[0, pos].Value.ToString()),
            ObjAdminUser.dgvpersonas[1, pos].Value.ToString(),
            ObjAdminUser.dgvpersonas[2, pos].Value.ToString(),
            int.Parse(ObjAdminUser.dgvpersonas[3, pos].Value.ToString()),
            ObjAdminUser.dgvpersonas[4, pos].Value.ToString(),
            ObjAdminUser.dgvpersonas[5, pos].Value.ToString(),
            ObjAdminUser.dgvpersonas[6, pos].Value.ToString(),
            DateTime.Parse(ObjAdminUser.dgvpersonas[7, pos].Value.ToString()),
            ObjAdminUser.dgvpersonas[8, pos].Value.ToString(),
            ObjAdminUser.dgvpersonas[9, pos].Value.ToString(),
            DateTime.Parse(ObjAdminUser.dgvpersonas[10, pos].Value.ToString()),
            ObjAdminUser.dgvpersonas[11, pos].Value.ToString(),
            DateTime.Parse(ObjAdminUser.dgvpersonas[12, pos].Value.ToString()),
            ObjAdminUser.dgvpersonas[13, pos].Value.ToString()); 
            openForm.ShowDialog();
            RefrescarData();
        }
        private void DeleteUser(object sender, EventArgs e)
        {
            int pos = ObjAdminUser.dgvpersonas.CurrentRow.Index;
            string userSelected = ObjAdminUser.dgvpersonas[1, pos].Value.ToString();
            MessageBox.Show($"{userSelected}");
            if (!(userSelected.Equals(SessionVar.Username)))
            {
                if (MessageBox.Show($"• Se eliminará la información de la persona.\n\n• ¿Esta seguro que desea elimar a: {ObjAdminUser.dgvpersonas[1, pos].Value.ToString()} {ObjAdminUser.dgvpersonas[2, pos].Value.ToString()}, considere que dicha acción no se podrá revertir.", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAOadminU daoDel = new DAOadminU();
                    daoDel.IDempleado = int.Parse(ObjAdminUser.dgvpersonas[0, pos].Value.ToString());
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
    
