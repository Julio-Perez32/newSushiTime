using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi_Time_PTC_2024.Modelo.DTO
{
    internal class DTOAgregarTarea : dbContext
    {
        private int idTarea;
        private string fechatarea;
        private string nombretarea;

        public int IdTarea { get => idTarea; set => idTarea = value; }
        public string Fechatarea { get => fechatarea; set => fechatarea = value; }
        public string Nombretarea { get => nombretarea; set => nombretarea = value; }
    }
}
