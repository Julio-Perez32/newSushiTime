using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sushi_Time_PTC_2024.Controlador.Dashcarpet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Sushi_Time_PTC_2024.Vista
{
    public partial class Dashboard : Form
    {
        public Dashboard(string username)
        {
            InitializeComponent();
            ControlD objdashboard = new ControlD(this, username);
        }

        private async void btndescarga_Click(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = "https://drive.google.com/uc?id=13AIuxbOI2oq_ZNNnLhtKPLzawDUrUkzK\r\n";

                    // Usar un SaveFileDialog para elegir la ubicación y el nombre del archivo
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "PDF files (.pdf)|.pdf";
                        saveFileDialog.Title = "Guardar archivo PDF";
                        saveFileDialog.FileName = "Manual de Uso de Sistema SushiTime.pdf"; // Nombre predeterminado

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string rutaArchivo = saveFileDialog.FileName;

                            // Descargar el archivo
                            var response = await httpClient.GetAsync(url);
                            response.EnsureSuccessStatusCode(); // Lanza excepción si no es exitoso

                            // Guardar el archivo
                            using (var fileStream = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                await response.Content.CopyToAsync(fileStream);
                            }

                            MessageBox.Show("El archivo PDF ha sido descargado con éxito en: " + rutaArchivo);
                            Process.Start(rutaArchivo);
                        }
                    }
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("Error en la solicitud HTTP: " + httpEx.Message);
            }
            catch (UnauthorizedAccessException authEx)
            {
                MessageBox.Show("Error de permisos: " + authEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void btnManualT_Click(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = "https://drive.google.com/uc?id=1wr_yE_VSD3UIfFDcAHcQ2Mw3_hM0KWL0\r\n";

                    // Usar un SaveFileDialog para elegir la ubicación y el nombre del archivo
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "PDF files (.pdf)|.pdf";
                        saveFileDialog.Title = "Guardar archivo PDF";
                        saveFileDialog.FileName = "Manueal Tecnico de Sistema SushiTime.pdf"; // Nombre predeterminado

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string rutaArchivo = saveFileDialog.FileName;

                            // Descargar el archivo
                            var response = await httpClient.GetAsync(url);
                            response.EnsureSuccessStatusCode(); // Lanza excepción si no es exitoso

                            // Guardar el archivo
                            using (var fileStream = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                await response.Content.CopyToAsync(fileStream);
                            }

                            MessageBox.Show("El archivo PDF ha sido descargado con éxito en: " + rutaArchivo);
                            Process.Start(rutaArchivo);
                        }
                    }
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("Error en la solicitud HTTP: " + httpEx.Message);
            }
            catch (UnauthorizedAccessException authEx)
            {
                MessageBox.Show("Error de permisos: " + authEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}
