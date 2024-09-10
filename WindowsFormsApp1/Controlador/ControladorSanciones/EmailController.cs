using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sushi_Time_PTC_2024.Modelo.DAO;
using Sushi_Time_PTC_2024.Modelo.DTO;
using System.Windows.Forms;

namespace Sushi_Time_PTC_2024.Controlador.ControladorSanciones
{
    public class EmailController
    {
        private readonly EmailDAO _emailDao;

        public EmailController(EmailDAO emailDao)
        {
            _emailDao = emailDao;
        }

        public void SendEmail(string to, string subject, string body)
        {
            var emailDto = new EmailDTO
            {
                To = to,
                Subject = subject,
                Body = body
            };
            try
            {
                _emailDao.SendEmail(emailDto);
                MessageBox.Show("Enviado");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
