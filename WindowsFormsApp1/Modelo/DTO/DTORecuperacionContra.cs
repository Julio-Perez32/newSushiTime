using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sushi_Time_PTC_2024.Modelo;

namespace Sushi_Time_PTC_2024.Modelo.DTO
{
    internal class DTORecuperacionContra : dbContext
    {
        private string passsword;

        public string PasssWord { get => passsword; set => passsword = value; }
    }
}
