using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sushi_Time_PTC_2024.Controlador;

namespace Sushi_Time_PTC_2024.Modelo.DTO
{
    internal class DTOTarea : dbContext
    {
        private int idTareaEmpleado;
        private int idTarea;
        private int idEmpleado;
        private string nombreTarea;
        private string descripcion;
        private DateTime fechaLimite;



        public int IdTareaEmpleado { get => idTareaEmpleado; set => idTareaEmpleado = value; }
        public int IdTarea { get => idTarea; set => idTarea = value; }
        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime FechaLimite { get => fechaLimite; set => fechaLimite = value; }
        public string NombreTarea { get => nombreTarea; set => nombreTarea = value; }
    }
}
