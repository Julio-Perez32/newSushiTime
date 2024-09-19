using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sushi_Time_PTC_2024.Modelo.DAO;
using Sushi_Time_PTC_2024.Vista.Asignacion_de_Funciones;
using System.Windows.Forms;

namespace Sushi_Time_PTC_2024.Controlador.ControladorAsignacionFunciones
{
    internal class ControladorTarea
    {
        Usuarios ObjTarea;
        //public ControladorTarea(Tarea Vista)
        //{
        //    ObjTarea = Vista;
        //    ObjTarea.Load += new EventHandler(LoadData);
        //    ObjTarea.btnAsignarTarea.Click += new EventHandler(NuevaTarea);
        //    ObjTarea.btnActualizarTarea += new EventHandler(ActualizarTarea);
        //    ObjTarea.btnEliminar += new EventHandler(EliminarTarea);
        //    ObjTarea.btnBuscar += new EventHandler(BuscarTarea);
        //    ObjTarea.txtBuscar.KeyPress += new KeyPressEventHandler(Search);


        //}
        //public void Search(object sender, KeyPressEventArgs e)
        //{
        //    BuscarTarea();
        //}
        //public void Checked(object sender, EventArgs e)
        //{
        //    RefrescarData();
        //}

        //public void BuscarTareaControllerEvent(object sender, EventArgs e) { BuscarTareaController(); }
        //void BuscarTareaController()
        //{
        //    //Objeto de la clase DAOAdminUsuarios
        //    DAOTarea objAdmin = new DAOTarea();
        //    //Declarando nuevo DataSet para que obtenga los datos del metodo ObtenerPersonas
        //    DataSet ds = objAdmin.BuscarTarea(ObjTarea.txtBuscar.Text.Trim());
        //    //Llenar DataGridView
        //    ObjTarea.dgvVerTareas.DataSource = ds.Tables["viewTarea"];
        //}
    }
}
