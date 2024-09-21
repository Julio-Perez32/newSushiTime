using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi_Time_PTC_2024.Modelo.DTO
{
    internal class DTOPrimerUso : dbContext
    {
        private int idNegocio;
        private string nombre;
        private string direccion;
        private string correoElectronico;
        private DateTime fechaCreacion;
        private string telefono;
        private string pbx;
        private byte[] logo;

        public int IdNegocio { get => idNegocio; set => idNegocio = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }
        public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Pbx { get => pbx; set => pbx = value; }
        public byte[] Logo { get => logo; set => logo = value; }
    }
}
