using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi_Time_PTC_2024.Modelo.DTO
{
    internal class DTOlogin : dbContext
    {
        private string username;
        private string password;
        private string passsWord;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string PasssWord { get => PasssWord; set => PasssWord = value; }
    }
}
