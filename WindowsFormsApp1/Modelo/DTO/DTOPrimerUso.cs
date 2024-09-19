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
        private int idUsuario;
        private string usuario;
        private string correo;
        private string contraseña;
        private string userStatus;


        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string UserStatus { get => userStatus; set => userStatus = value; }

        // Constructor opcional para inicializar valores predeterminados
        public DTOPrimerUso()
        {
            userStatus = "activo";
        }

        public SqlConnection getConnection(string server, string database, string userId, string password)
        {

            string connectionString = $"Server={server};DataBase={database};User Id={userId};Password={password};";
            return new SqlConnection(connectionString);
        }
    }
}
