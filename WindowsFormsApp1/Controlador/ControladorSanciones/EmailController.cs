using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sushi_Time_PTC_2024.Modelo.DAO;
using Sushi_Time_PTC_2024.Modelo.DTO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
            if (string.IsNullOrWhiteSpace(to))
            {
                MessageBox.Show("Por favor especifique al menos un destinatario.");
                return;
            }
            if (!to.Contains("@"))
            {
                MessageBox.Show("Ingrese un correo valido '@'.");
                return;
            }

            if (string.IsNullOrWhiteSpace(subject))
            {
                MessageBox.Show("Ingrese el Tipo de Sanción.");
                return;
            }
            if (subject.Length > 50)
            {
                MessageBox.Show("El texto no puede exceder el limite de 50 caracteres.");
                return;
            }
            if (!Regex.IsMatch(subject, @"^[a-zA-Z0-9\s]+$"))
            {
                MessageBox.Show("Este campo solo puede contener letras y números.");
                return;
            }

            if (string.IsNullOrWhiteSpace(body))
            {
                MessageBox.Show("Por favor ingrese una Observación.");
                return;
            }
            if (body.Length > 1000)
            {
                MessageBox.Show("La observación no puede exceder el maximo de 1000 caracteres.");
                return;
            }
            if (!Regex.IsMatch(body, @"^[a-zA-Z0-9\s]+$"))
            {
                MessageBox.Show("Este campo solo puede contener letras y números.");
                return;
            }

            var emailDto = new EmailDTO
            {
                To = to,
                Subject = subject,
                Body = body
            };

            try
            {
                _emailDao.SendEmail(emailDto);
                MessageBox.Show("Correo enviado exitosamente.");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error al enviar el correo: {e.Message}");
            }
        }
    }
}
