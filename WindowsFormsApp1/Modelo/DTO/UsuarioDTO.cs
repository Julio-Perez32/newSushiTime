using Sushi_Time_PTC_2024.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Modelo.DTO
{
    internal class UsuarioDTO : dbContext
    {
        public int Id_Usuario { get; set; }
        public string NombreUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contraseña { get; set; }
    }
}
