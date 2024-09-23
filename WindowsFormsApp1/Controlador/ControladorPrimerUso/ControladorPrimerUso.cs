using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sushi_Time_PTC_2024.Modelo.DAO;
using Sushi_Time_PTC_2024.Vista;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Sushi_Time_PTC_2024.Modelo.DTO;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using WindowsFormsApp1.Vista.Primer_Uso;

namespace Sushi_Time_PTC_2024.Controlador.ControladorPrimerUso
{
    internal class ControladorPrimerUso
    {
        PrimerUso_ ObjVista;
        bool realizarAccion;
         public ControladorPrimerUso(PrimerUso_ Vista)
         {
            ObjVista = Vista;
            Vista.btnGuardar.Click += new EventHandler(GuardarInformacion);
            Vista.btnAttach.Click += new EventHandler(ColocarImagen);
            ObjVista.pbSalir.Click += new EventHandler(QuitApplication);
         }

        void GuardarInformacion(object sender, EventArgs e)
        {
            try
            {
                //Validación para verificar que todos los campos esten llenos
                if (!(string.IsNullOrEmpty(ObjVista.txtEmpresa.Text.Trim()) ||
                    string.IsNullOrEmpty(ObjVista.txtDireccionEmpresa.Text.Trim()) ||
                    string.IsNullOrEmpty(ObjVista.txtCorreoEmpresa.Text.Trim()) ||
                    string.IsNullOrEmpty(ObjVista.txtTelefonoEmpresa.Text.Trim()) ||
                    string.IsNullOrEmpty(ObjVista.txtPBX.Text.Trim()) ||
                    ObjVista.picEmpresa.Image == null))
                {
                    DAOPrimerUso DAOGuardar = new DAOPrimerUso();
                    DAOGuardar.Nombre = ObjVista.txtEmpresa.Text.Trim();
                    DAOGuardar.Direccion = ObjVista.txtDireccionEmpresa.Text.Trim();
                    DAOGuardar.CorreoElectronico = ObjVista.txtCorreoEmpresa.Text.Trim();
                    DAOGuardar.FechaCreacion = ObjVista.dtCreacion.Value.Date;
                    DAOGuardar.Telefono = ObjVista.txtTelefonoEmpresa.Text.Trim();
                    DAOGuardar.Pbx = ObjVista.txtPBX.Text.Trim();

                    //Guardar imagen
                    Image imagen = ObjVista.picEmpresa.Image;
                    byte[] imageBytes;
                    if (imagen == null)
                    {
                        imageBytes = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream();
                        imagen.Save(ms, ImageFormat.Jpeg);
                        imageBytes = ms.ToArray();
                    }
                    realizarAccion = ValidarCorreo();
                    if (realizarAccion == true)
                    {
                        DAOGuardar.Logo = imageBytes;
                        bool respuesta = DAOGuardar.RegistrarNegocio();
                        if (respuesta != false)
                        {
                            MessageBox.Show($"Tu neogicio ha sido registrado exitosamente.", "Paso 1 completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CrearPrimerUsuario nextForm = new CrearPrimerUsuario(1);
                            nextForm.Show();
                            ObjVista.Hide();
                        }
                        else
                        {
                            MessageBox.Show($"Oops, algo salio mal, revisemos los datos e intentemos nuevamente.", "Paso 1 interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Todos los campos son requeridos.", "Datos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error al procesar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ColocarImagen(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png| Todos los archivos(*.*)| *.* ";
            ofd.Title = "Seleccionar imagen";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string rutaImagen = ofd.FileName;
                ObjVista.picEmpresa.Image = Image.FromFile(rutaImagen);
            }
        }

        bool ValidarCorreo()
        {
            string email = ObjVista.txtCorreoEmpresa.Text.Trim();
            if (!(email.Contains("@")))
            {
                MessageBox.Show("Formato de correo invalido, verifica que contiene @.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string[] dominiosPermitidos = { "gmail.com", "ricaldone.edu.sv" };
            string extension = email.Substring(email.LastIndexOf('@') + 1);
            if (!dominiosPermitidos.Contains(extension))
            {
                MessageBox.Show("Dominio del correo es invalido, el sistema unicamente admite dominios 'gmail.com' y 'correo institucional'.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void QuitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
