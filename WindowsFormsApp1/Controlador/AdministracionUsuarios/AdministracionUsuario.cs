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
            ObjAdminUser.txtbuscarT.KeyUp += new KeyEventHandler(Search);
            ObjAdminUser.btnBuscar.Click += new EventHandler(BuscarPeronasControllerEvent);
        }

        public void Search(object sender, KeyEventArgs e)
        {
            BuscarPeronasController();
        }

        public void BuscarPeronasControllerEvent(object sender, EventArgs e) { BuscarPeronasController(); }
        void BuscarPeronasController()
        {
            // Crear instancia del DAO
            DAOadminU dao = new DAOadminU();

            // Obtener el valor que el usuario está escribiendo
            string valorBusqueda = ObjAdminUser.txtbuscarT.Text.Trim(); // Trim para evitar espacios vacíos

            // Verificar que el valor de búsqueda no esté vacío y que tenga al menos 2 caracteres
            if (string.IsNullOrEmpty(valorBusqueda) || valorBusqueda.Length < 2)
            {
                // Si el cuadro de búsqueda está vacío, mostrar todos los datos o restaurar la tabla completa
                DataSet ds = dao.Obtenerempleados();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables["VistaEmpleados"].Rows.Count > 0)
                {
                    ObjAdminUser.dgvpersonas.DataSource = ds.Tables["VistaEmpleados"];
                }
                else
                {
                    ObjAdminUser.dgvpersonas.DataSource = null; // Limpiar si no hay datos
                }
                return;
            }

            // Ejecutar la búsqueda
            DataSet resultadoBusqueda = dao.BuscarPersonas(valorBusqueda);

            if (resultadoBusqueda != null && resultadoBusqueda.Tables.Count > 0 && resultadoBusqueda.Tables["VistaEmpleados"].Rows.Count > 0)
            {
                // Llenar el DataGridView con los resultados de la búsqueda
                ObjAdminUser.dgvpersonas.DataSource = resultadoBusqueda.Tables["VistaEmpleados"];
            }
            else
            {
                // Si no hay resultados, vaciar el DataGridView sin mostrar mensajes
                ObjAdminUser.dgvpersonas.DataSource = null;
            }
        }

        public void LoadData(object sender, EventArgs e)
        {
            RefrescarData();
        }

        //DataGridView

        private Dictionary<string, int> cargosDic;

        public void RefrescarData()
        {
            DAOadminU dAOadminU = new DAOadminU();
            DataSet ds = dAOadminU.Obtenerempleados();
            ObjAdminUser.dgvpersonas.DataSource = ds.Tables["VistaEmpleados"];

            // Crear el diccionario de cargos
            cargosDic = new Dictionary<string, int>();
            DataTable dtCargos = dAOadminU.LlenarCombo().Tables["CargoEmpleado"]; // Asumiendo que este método devuelve los cargos
            foreach (DataRow row in dtCargos.Rows)
            {
                cargosDic[row["NombreCargo"].ToString()] = (int)row["idCargo"];
            }

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
            try
            {
                // Obtén la fila actual seleccionada en el DataGridView
                int pos = ObjAdminUser.dgvpersonas.CurrentRow.Index;

                // Obtén los valores de la fila
                int idEmpleado;
                int idCargo;
                decimal Salario;
                string Nombre, Apellido, Numtelefono, NumCuenta, DUI, Direccion, Hijos, Correo;
                DateTime FechaNacimiento, FechaInicio, FechaFin;

                string cargoNombre = ObjAdminUser.dgvpersonas[3, pos].Value?.ToString();


                if (string.IsNullOrEmpty(cargoNombre) || !cargosDic.TryGetValue(cargoNombre, out idCargo))
                {
                    MessageBox.Show("No se encontró el ID del Cargo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Continuar con el resto del código para obtener otros datos y actualizar el usuario
                // ...




                idEmpleado = int.Parse(ObjAdminUser.dgvpersonas[0, pos].Value.ToString());
                Nombre = ObjAdminUser.dgvpersonas[1, pos].Value.ToString();
                Apellido = ObjAdminUser.dgvpersonas[2, pos].Value.ToString();
                //idCargo = int.Parse(ObjAdminUser.dgvpersonas[3, pos].Value.ToString());
                Numtelefono = ObjAdminUser.dgvpersonas[4, pos].Value.ToString();
                NumCuenta = ObjAdminUser.dgvpersonas[5, pos].Value.ToString();
                DUI = ObjAdminUser.dgvpersonas[6, pos].Value.ToString();
                FechaNacimiento = DateTime.Parse(ObjAdminUser.dgvpersonas[7, pos].Value.ToString());
                Direccion = ObjAdminUser.dgvpersonas[8, pos].Value.ToString();
                Hijos = ObjAdminUser.dgvpersonas[9, pos].Value.ToString();
                FechaInicio = DateTime.Parse(ObjAdminUser.dgvpersonas[10, pos].Value.ToString());
                Salario = decimal.Parse(ObjAdminUser.dgvpersonas[11, pos].Value.ToString());
                FechaFin = DateTime.Parse(ObjAdminUser.dgvpersonas[12, pos].Value.ToString());
                Correo = ObjAdminUser.dgvpersonas[13, pos].Value.ToString();


                // Crea una instancia de AgregarUsuario para la actualización
                AgregarUsuario objnuevoU = new AgregarUsuario(2, idEmpleado, Nombre, Apellido, idCargo, Numtelefono, NumCuenta, DUI, FechaNacimiento, Direccion, Hijos, FechaInicio, Salario, FechaFin, Correo);
                objnuevoU.ShowDialog();

                // Refresca los datos después de cerrar el diálogo
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
            int pos = ObjAdminUser.dgvpersonas.CurrentRow.Index;
            string userSelected = ObjAdminUser.dgvpersonas[1, pos].Value.ToString();
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
    
