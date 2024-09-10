using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi_Time_PTC_2024.Modelo.DTO
{
    internal class DTOPrimerUso : dbContext
    {
        private string idUsuario;
        private string usuario;
        private string Correo;
        private string Contraseña;
        
        public string IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string correo { get => Correo; set => Correo = value; }
        public string contraseña { get => Contraseña; set => Contraseña = value; }
    }
}
