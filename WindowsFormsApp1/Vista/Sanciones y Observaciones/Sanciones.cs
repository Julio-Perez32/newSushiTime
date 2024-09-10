using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sushi_Time_PTC_2024.Modelo.DAO;
using Sushi_Time_PTC_2024.Controlador.ControladorSanciones;
using System.Windows.Forms;

namespace Sushi_Time_PTC_2024.Vista.Sanciones_y_Observaciones
{
    public partial class Sanciones : Form
    {
        private readonly EmailController _emailController;
        public Sanciones()
        {
            InitializeComponent();
            // Inicializa el controlador con el DAO
            var emailDao = new EmailDAO("observacionsushitime@gmail.com", "esbgovtsyuptagdc", "SushiTime");
            _emailController = new EmailController(emailDao);
        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            var to = txtPara.Text.Trim();
            var subject = txtTipoSancion.Text.Trim();
            var body = txtObservacionS.Text.Trim();

            _emailController.SendEmail(to, subject, body);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
