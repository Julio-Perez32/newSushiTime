using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Modelo.DAO;
using WindowsFormsApp1.Modelo.DTO;

namespace WindowsFormsApp1
{
    internal class RecuperarContraseñaService
    {
        private UsuarioDAO usuarioDAO = new UsuarioDAO();
        private string correoElectronicoSoporte = "camu.ma178@gmail.com";
        private string contraseñaApp = "edsa idfc znvc mhlc";

        public void RecuperarContraseña(string nombreUsuario)
        {
            UsuarioDTO usuario = usuarioDAO.GetUsuarioByNombreUsuario(nombreUsuario);
            if (usuario != null)
            {
                string nuevaContraseña = GenerarContraseñaAleatoria();
                usuarioDAO.UpdateContraseña(usuario.Id_Usuario, EncriptarContraseña(nuevaContraseña));
                EnviarCorreoElectronico(usuario.CorreoElectronico, nuevaContraseña);
            }
        }

        private string GenerarContraseñaAleatoria()
        {
            Random random = new Random();
            string contraseña = "";
            for (int i = 0; i < 7; i++)
            {
                contraseña += random.Next(0, 9).ToString();
            }
            return contraseña;
        }

        private string EncriptarContraseña(string contraseña)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        private void EnviarCorreoElectronico(string correoElectronico, string nuevaContraseña)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(correoElectronicoSoporte);
                mail.To.Add(correoElectronico);
                mail.Subject = "Recuperación de contraseña";
                mail.Body = $"Su contraseña ha sido cambiada. La nueva contraseña es: {nuevaContraseña}";
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(correoElectronicoSoporte, contraseñaApp);
                    smtp.Send(mail);
                }
            }
        }
    }
}
