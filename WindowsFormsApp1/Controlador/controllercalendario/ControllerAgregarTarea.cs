using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Sushi_Time_PTC_2024.Modelo.DAO;
using Sushi_Time_PTC_2024.Vista.Calendario;

namespace Sushi_Time_PTC_2024.Controlador.controllercalendario
{
    internal class ControllerAgregarTarea
    {
        AgregarTarea ObjAgr;
        private int accion;
        private string estado;
        private AgregarTarea agregarInspeccion;

        public ControllerAgregarTarea(AgregarTarea vista, int accion)
        {
            ObjAgr = vista;
            this.accion = accion;

            VerificarAccion();
            ObjAgr.Load += new EventHandler(AgregarTareaLoad);
            ObjAgr.BtnTarea.Click += new EventHandler(AgregarTarea);
            ObjAgr.TxtDescripcionTarea.KeyPress += new KeyPressEventHandler(TxtDescripcionTarea_KeyPress);
            ObjAgr.pbsalir.Click += new EventHandler(salir);
            ObjAgr.TxtDescripcionTarea.KeyPress += new KeyPressEventHandler(TxtDescripcionTarea_KeyPress);
            ObjAgr.TxtDescripcionTarea.KeyDown += new KeyEventHandler(TxtDescripcionTarea_KeyDown);

            // Deshabilitar el menú contextual para evitar pegar con clic derecho
            ObjAgr.TxtDescripcionTarea.ContextMenuStrip = new ContextMenuStrip();
            ObjAgr.TxtDescripcionTarea.ContextMenuStrip.Items.Clear(); // Limpiar cualquier ítem del menú contextual

            ObjAgr.pbsalir.Click += new EventHandler(salir);
        }
      

        private void TxtDescripcionTarea_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (char.IsDigit(e.KeyChar))
            {
                
                e.Handled = true;
                MessageBox.Show("No se permiten números en la descripción de la tarea.",
                                "Entrada no válida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
        private void TxtDescripcionTarea_KeyDown(object sender, KeyEventArgs e)
        {
            // Deshabilitar cortar, copiar y pegar
            if (e.Control && (e.KeyCode == Keys.X || e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                e.SuppressKeyPress = true; // Evita que la acción se ejecute
            }
        }

        private void salir(object sender, EventArgs e)
        {
            ObjAgr.Hide();
        }

        public ControllerAgregarTarea(AgregarTarea Vista, int p_accion, int id, string NombreTarea, string fecha)
        {
            ObjAgr = Vista;
            this.accion = p_accion;
            ObjAgr.Load += new EventHandler(AgregarTareaLoad);
            VerificarAccion();
            ChargeValues(id, NombreTarea, fecha);
            ObjAgr.BtnActualizar.Click += new EventHandler(ActualizarTarea);
            ObjAgr.TxtDescripcionTarea.KeyPress += new KeyPressEventHandler(TxtDescripcionTareaa_KeyPress);
            ObjAgr.pbsalir.Click += new EventHandler(salir);
        }

        private void TxtDescripcionTareaa_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si el carácter ingresado es un número
            if (char.IsDigit(e.KeyChar))
            {
                // Si es un número, cancela el evento KeyPress para que no se ingrese
                e.Handled = true;
                MessageBox.Show("No se permiten números en la descripción de la tarea.",
                                "Entrada no válida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
        private void AgregarTareaLoad(object sender, EventArgs e)
        {
            ObjAgr.TxtFechaTarea.Text = ControllerCalendario.static_month + "/" + UserControlDias.static_day + "/" + ControllerCalendario.static_year;
        }

        private void AgregarTarea(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(ObjAgr.TxtDescripcionTarea.Text.Trim()) ||
         string.IsNullOrEmpty(ObjAgr.TxtFechaTarea.Text.Trim())))
         { 
          ObjAgr.TxtFechaTarea.Enabled = false;

            DAOAgregarTarea DAOInsert = new DAOAgregarTarea();

            DAOInsert.Nombretarea = ObjAgr.TxtDescripcionTarea.Text;
            DAOInsert.Fechatarea = ObjAgr.TxtFechaTarea.Text;


            int valorRetornado = DAOInsert.AgregarTarea();

            if (valorRetornado == 1)
            {
                //SavePhoto();       
                MessageBox.Show("La Tarea ha sido registrada exitosamente",
                                "Proceso completado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("La Tarea no pudo ser registrada",
                                "Proceso interrumpido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
                 }
            else {

                MessageBox.Show("La Tarea no pudo ser registrada",
                                    "Proceso interrumpido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

            }
        }


        public void VerificarAccion()
        {
            if (accion == 1)
            {
                ObjAgr.TxtFechaTarea.Enabled = false;
                ObjAgr.BtnActualizar.Enabled = false;
                ObjAgr.BtnTarea.Enabled = true;
            } else if (accion == 2) 
            {
                ObjAgr.LabelTitulo.Text = "Editar Tarea";
                ObjAgr.TxtFechaTarea.Enabled = false;
                ObjAgr.BtnActualizar.Enabled = true;
                ObjAgr.BtnTarea.Enabled = false;
            }
        }


        public void ChargeValues(int id, string NombreTarea, string fecha)
        {
            try
            {

                ObjAgr.TxtId.Text = id.ToString();
                ObjAgr.TxtFechaTarea.Text = fecha;
                ObjAgr.TxtDescripcionTarea.Text = NombreTarea.ToString();
                


            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void ActualizarTarea(Object sender, EventArgs e)
        {
            DAOAgregarTarea daoUpdate = new DAOAgregarTarea();
            daoUpdate.IdTarea = int.Parse(ObjAgr.TxtId.Text);
            daoUpdate.Nombretarea = ObjAgr.TxtDescripcionTarea.Text;
            daoUpdate.Fechatarea = ObjAgr.TxtFechaTarea.Text;
            int valorRetornado = daoUpdate.ActualizarTarea();
            if (valorRetornado == 1)

            {
                MessageBox.Show("Los datos han sido actualizado exitosamente",
                                "Proceso completado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser actualizados debido a un error inesperado",
                                "Proceso interrumpido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
