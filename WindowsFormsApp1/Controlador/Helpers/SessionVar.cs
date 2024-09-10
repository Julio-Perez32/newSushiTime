using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi_Time_PTC_2024.Controlador.Helpers
{
    internal class SessionVar
    {
        private static string username = string.Empty;
        private static string password = string.Empty;

        public static string Username { get => username; set => username = value; }
        public static string Password { get => password; set => password = value; }
    }
}
