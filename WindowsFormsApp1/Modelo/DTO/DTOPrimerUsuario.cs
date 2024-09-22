using Sushi_Time_PTC_2024.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Modelo.DTO
{
    internal class DTOPrimerUsuario : dbContext
    {
        private int idUsuario;
        private int intentos = 0;
        private string correo;
        private string contraseña;
        private string usuario;
        private string userStatus = "Activo";
        private string rol;
        private DateTime fechaCreacion;
        private string nombre;
        private string apellido;
        private string dui;
        private string direccion;
        private string telefono;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public int Intentos { get => intentos; set => intentos = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string UserStatus { get => userStatus; set => userStatus = value; }
        public string Rol { get => rol; set => rol = value; }
        public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Dui { get => dui; set => dui = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
