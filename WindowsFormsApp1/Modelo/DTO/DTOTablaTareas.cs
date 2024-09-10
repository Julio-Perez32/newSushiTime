using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi_Time_PTC_2024.Modelo.DTO
{
    internal class DTOTablaTareas : dbContext
    {
        private int idTarea;
        private string nameTarea;
        private string fechatarea;

        public int IdTarea { get => idTarea; set => idTarea = value; }
        public string NameTarea { get => nameTarea; set => nameTarea = value; }
        public string Fechatarea { get => fechatarea; set => fechatarea = value; }
    }
}
