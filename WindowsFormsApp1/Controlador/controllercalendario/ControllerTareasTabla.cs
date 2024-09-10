using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Modelo.DAO;
using Sushi_Time_PTC_2024.Vista.Calendario;

namespace Sushi_Time_PTC_2024.Controlador.controllercalendario
{
    internal class ControllerTareasTabla
    {
        TablaTareas Objtabtable;

        public ControllerTareasTabla(TablaTareas vista)
        {
            Objtabtable = vista;
            Objtabtable.Load += new EventHandler(CargarDatos);
            
            Objtabtable.csmEliminar.Click += new EventHandler(EliminarRegistro);
            Objtabtable.csmActualizar.Click += new EventHandler(ActualizarInspeccion); 
            Objtabtable.pbsalir.Click += new EventHandler(salir);
        }
        private void salir(object sender, EventArgs e)
        {
            Objtabtable.Hide();
        }


        private void CargarDatos(object sender, EventArgs e)
        {
            RefrescarDatos();
        }

        private void RefrescarDatos()
        {
            DAOTablaTareas dAOTablaTareas = new DAOTablaTareas();
            DataSet ds = new DataSet();
            ds = dAOTablaTareas.ObtenerTareas();
            Objtabtable.dgvTareas.DataSource = ds.Tables["Tareas"];
            foreach (DataGridViewColumn column in Objtabtable.dgvTareas.Columns)
            {
                column.ReadOnly = true;
            }
        }

        private void ActualizarInspeccion(object sender, EventArgs e)
        {
            int pos = Objtabtable.dgvTareas.CurrentRow.Index;
            /*Se invoca al formulario llamado ViewAddUser y se crea un objeto de el, posteriormente se envían los datos del datagrid al constructor del formulario según el orden establecido (se sugiere ver el código del formulario para observar ambos constructores).
             * El numero dos indicado en la linea posterior significa que la acción que se desea realizar es una actualízación.*/
            AgregarTarea openForm = new AgregarTarea(2,
                int.Parse(Objtabtable.dgvTareas[0, pos].Value.ToString()),
                 Objtabtable.dgvTareas[1, pos].Value.ToString(),
                 Objtabtable.dgvTareas[2, pos].Value.ToString());
               


            //Una vez los datos han sido enviados al constructor de la vista se procede a mostrar el formulario (se sugiere ver el código del constructor que esta en la vista)
            openForm.ShowDialog();
            //Una vez el formulario se haya cerrado se procederá a refrescar el dataGrid para mostrar los nuevos datos.
            RefrescarDatos();
        }

        private void EliminarRegistro(object sender, EventArgs e)
        {
            int pos = Objtabtable.dgvTareas.CurrentRow.Index;
            DAOTablaTareas daodelete = new DAOTablaTareas();
            daodelete.IdTarea = int.Parse(Objtabtable.dgvTareas[0, pos].Value.ToString());
            int retorno = daodelete.EliminarInspeccion();

            if (retorno == 1)
            {
                MessageBox.Show("La tarea ha sido eliminada", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefrescarDatos();

            }
            else
            {
                MessageBox.Show("La tarea no pudo ser eliminada", "Proceso Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
