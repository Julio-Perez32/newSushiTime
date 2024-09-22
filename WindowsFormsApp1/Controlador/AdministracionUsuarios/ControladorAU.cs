using Sushi_Time_PTC_2024.Controlador.Helpers;
using Sushi_Time_PTC_2024.Vista;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Modelo.DAO;
using WindowsFormsApp1.Vista.Primer_Uso;
using WindowsFormsApp1.Vista.Usuarios;
using static TheArtOfDev.HtmlRenderer.Adapters.RGraphicsPath;

namespace WindowsFormsApp1.Controlador.AdministracionUsuarios
{
    internal class ControladorAU
    {
        CrearPrimerUsuario objagg;
        private int accion;
        private string rol;
        editarUsuarios objed;
        public ControladorAU(CrearPrimerUsuario vista)
        {
            objagg.Load += new EventHandler(InitialCharge);
            objagg.btnGuardar.Click += new EventHandler(NewRegister);
        }



        void NewRegister(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(objagg.txtNombre.Text.Trim()) ||
                string.IsNullOrEmpty(objagg.txtApellido.Text.Trim()) ||
                string.IsNullOrEmpty(objagg.mskDocumento.Text) ||
                string.IsNullOrEmpty(objagg.txtDireccion.Text.Trim()) ||
                string.IsNullOrEmpty(objagg.txtEmail.Text.Trim()) ||
                string.IsNullOrEmpty(objagg.txtTelefono.Text.Trim()) ||
                string.IsNullOrEmpty(objagg.txtUsuario.Text.Trim())))
            {
                DAOPrimerUsuario DAOInsert = new DAOPrimerUsuario();
                Encriptado encriptado = new Encriptado();
                DAOInsert.Nombre = objagg.txtNombre.Text.Trim();
                DAOInsert.Apellido = objagg.txtApellido.Text.Trim();
                DAOInsert.FechaCreacion = objagg.dtFecha.Value.Date;
                DAOInsert.Dui = objagg.mskDocumento.Text;
                DAOInsert.Direccion = objagg.txtDireccion.Text.Trim();
                DAOInsert.Correo = objagg.txtEmail.Text.Trim();
                DAOInsert.Telefono = objagg.txtTelefono.Text.Trim();
                DAOInsert.Usuario = objagg.txtUsuario.Text.Trim();
                DAOInsert.Contraseña = encriptado.ComputeSha256Hash(objagg.txtUsuario.Text.Trim() + "SushiTime24");
                DAOInsert.UserStatus = "Activo";
                DAOInsert.Intentos = 0;
                DAOInsert.Rol = objagg.comboRol.SelectedValue.ToString();
                int valorRetornado = DAOInsert.RegistrarUsuario();
                if (valorRetornado == 1)
                {
                    MessageBox.Show("Los datos han sido registrados exitosamente",
                                    "Proceso completado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    MessageBox.Show($"Usuario administrador: {objagg.txtUsuario.Text.Trim()}\nContraseña de usuario: {objagg.txtUsuario.Text.Trim()}SushiTime24",
                                    "Credenciales de acceso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    objagg.Hide();
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
        public void InitialCharge(object sender, EventArgs e)
        {
            //Objeto de la clase DAOAdminUsuarios
            DAOPrimerUsuario objAdmin = new DAOPrimerUsuario();
            //Declarando nuevo DataSet para que obtenga los datos del metodo LlenarCombo
            DataSet ds = objAdmin.LlenarCombo();
            //Llenar combobox tbRole
            objagg.comboRol.DataSource = ds.Tables["tbRol"];
            objagg.comboRol.ValueMember = "idRol";
            objagg.comboRol.DisplayMember = "nombreRol";
            //La condición sirve para que al actualizar un registro, el valor del registro aparezca seleccionado.
            if (accion == 2)
            {
                objagg.comboRol.Text = rol;
            }
        }
        public void minimizar(object sender, EventArgs e)
        { 
            objagg.Hide();
        }
    }
}
