using Sushi_Time_PTC_2024.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Modelo.DTO
{
    internal class DTOUsuarios : dbContext
    {
        private string nombreUsuario;

        public string NombreUsuario
        {
            get => nombreUsuario;
            set => nombreUsuario = value;
        }
        public static class SessionInfo
        {
            public static int IdUsuarioActual { get; set; }
        }

    }
}

        
    



