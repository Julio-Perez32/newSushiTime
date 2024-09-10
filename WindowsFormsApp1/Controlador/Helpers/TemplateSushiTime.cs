using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnviarMail;
using Sushi_Time_PTC_2024.Controlador.Helpers;

namespace Sushi_Time_PTC_2024.Controlador.Helpers
{
    internal class TemplateSushiTime
    {
        static void EnviarEmpleados(string correoElectronico, bool Observaciones = false)
        {
            logic objLogic = new logic();
            string bodyAsignarTarea = @"<style>
                            h1{color:dodgerblue;}
                            h2{color:darkorange;}
                            </style>
                            <h1>Este es el body del correo</h1></br>
                            <h2>Este es el segundo párrafo</h2>";
            if (!Observaciones)
            {
                objLogic.sendMail("julioperez.7582462@gmail.com", "Este correo fue enviado via C-sharp", bodyAsignarTarea);
            }
            else
            {
                string bodyAsignarObservaciones = @"<style>
                            h1{color:dodgerblue;}
                            h2{color:darkorange;}
                            </style>
                            <h1>Este es el body del correo</h1></br>
                            <h2>Este es el segundo párrafo</h2>";
                objLogic.sendMail("julioperez.7582462@gmail.com", "Este correo fue enviado via C-sharp", bodyAsignarObservaciones);

            }


        }


    }
}
