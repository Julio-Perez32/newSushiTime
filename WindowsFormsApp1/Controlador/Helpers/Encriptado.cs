using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sushi_Time_PTC_2024.Controlador.Helpers
{
    public class Encriptado
    {
        public string ComputeSha256Hash(string rawData)//metodo
        {
            using (SHA256 sha256Hash = SHA256.Create())//objeto
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));//x2 es una cadena de texto de 2 caracteres
                }
                return builder.ToString();
            }
        }
    }
}
