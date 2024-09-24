using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sushi_Time_PTC_2024.Modelo;

namespace Sushi_Time_PTC_2024.Modelo.DTO
{
    internal class DTOadminU : dbContext
    {
        private int idEmpleado;
        private int iDCargo;
        private int idUsuario;
        private string Nombre;
        private string Apellido;
        private string NumTelefono;
        private string NumCuenta;
        private string DUI;
        private DateTime FechaNacimiento;
        private string Direccion;
        private string Hijos;
        private DateTime FechaInicio;
        private decimal Salario;
        private DateTime FechaFin;
        private string Correo;
        Dictionary<string, int> cargos = new Dictionary<string, int>()
{
    { "Gerente", 2 },
    { "Empleado", 1 }
};
        private string Usuario;
        private string Contraseña;

        public string Usuario1 { get => Usuario; set => Usuario = value; }
        public string Contraseña1 { get => Contraseña; set => Contraseña = value; }

        public int IDempleado { get => idEmpleado; set => idEmpleado = value; }
        public int idCargo { get => iDCargo; set => iDCargo = value; }
        public int IDusuario { get => idUsuario; set => idUsuario = value; }
        public string nombre { get => Nombre; set => Nombre = value; }
        public string apellido { get => Apellido; set => Apellido = value; }
        public string numtelefono { get => NumTelefono; set => NumTelefono = value; }
        public string numcuenta { get => NumCuenta; set => NumCuenta = value; }
        public string dui { get => DUI; set => DUI = value; }
        public DateTime fechanacimiento { get => FechaNacimiento; set => FechaNacimiento = value; }
        public string direccion { get => Direccion; set => Direccion = value; }
        public string hijos { get => Hijos; set => Hijos = value; }
        public DateTime fechainicio { get => FechaInicio; set => FechaInicio = value; }
        public decimal salario { get => Salario; set => Salario = value; }
        public DateTime fechafin { get => FechaFin; set => FechaFin = value; }
        public string correo { get => Correo; set => Correo = value; }

    }
}
