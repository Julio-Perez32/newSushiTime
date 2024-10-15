using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi_Time_PTC_2024.Modelo.DTO
{
    internal class DTOCambiarContraseña : dbContext
    {
        private int idUsuario;
        private string nuevaContraseña;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string NuevaContraseña { get => nuevaContraseña; set => nuevaContraseña = value; }
    }
}

