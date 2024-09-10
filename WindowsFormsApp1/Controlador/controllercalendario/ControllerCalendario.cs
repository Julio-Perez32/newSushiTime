using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sushi_Time_PTC_2024.Vista.Calendario;

namespace Sushi_Time_PTC_2024.Controlador.controllercalendario
{
    internal class ControllerCalendario
    {
        int month, year;
        public static int static_month, static_year;
        calendario1 ObjCalendario;
        UserControlDias ObjControlDias;



        public ControllerCalendario(calendario1 Vista)
        {
            ObjCalendario = Vista;
            ObjCalendario.Load += new EventHandler(Inspecciones_Load);
            ObjCalendario.btnAntes.Click += new EventHandler(PreviousCalendar);
            ObjCalendario.btnDespues.Click += new EventHandler(NextCalendar);
            ObjCalendario.BtnTablaTareas.Click += new EventHandler(AbrirTabla);
           
        }

        public ControllerCalendario(UserControlDias Vista)
        {
            ObjControlDias = Vista;
            ObjControlDias.Load += new EventHandler(UserControlDays_Load);
        }

        private void AbrirAgregarInspeccion(object sender, EventArgs e)
        {
            
        }

        private void Inspecciones_Load(object sender, EventArgs e)
        {
            displaDays();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }

        private void displaDays()
        {
            DateTime Now = DateTime.Now;
            month = Now.Month;
            year = Now.Year;

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            ObjCalendario.LBDATE.Text = (monthname + " " + year).ToUpper(); // Convierte el texto a mayúsculas

            static_month = month;
            static_year = year;

            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                ObjCalendario.daycontainer.Controls.Add(ucblank);
            }

            for (int i = 1; i <= days; i++)
            {
                UserControlDias ucdays = new UserControlDias();
                ucdays.days(i);
                ObjCalendario.daycontainer.Controls.Add(ucdays);
            }
        }

        private void NextCalendar(object sender, EventArgs e)
        {
            ObjCalendario.daycontainer.Controls.Clear();

            month++;
            static_month = month;
            static_year = year;
            if (month > 12)
            {
                month = 1;
                year++;
            }

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            ObjCalendario.LBDATE.Text = (monthname + " " + year).ToUpper(); // Convierte el texto a mayúsculas

            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                ObjCalendario.daycontainer.Controls.Add(ucblank);
            }

            for (int i = 1; i <= days; i++)
            {
                UserControlDias ucdays = new UserControlDias();
                ucdays.days(i);
                ObjCalendario.daycontainer.Controls.Add(ucdays);
            }
        }

        private void PreviousCalendar(object sender, EventArgs e)
        {
            ObjCalendario.daycontainer.Controls.Clear();

            month--;
            static_month = month;
            static_year = year;
            if (month < 1)
            {
                month = 12;
                year--;
            }

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            ObjCalendario.LBDATE.Text = (monthname + " " + year).ToUpper(); // Convierte el texto a mayúsculas

            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                ObjCalendario.daycontainer.Controls.Add(ucblank);
            }

            for (int i = 1; i <= days; i++)
            {
                UserControlDias ucdays = new UserControlDias();
                ucdays.days(i);
                ObjCalendario.daycontainer.Controls.Add(ucdays);
            }
        }


        private void AbrirTabla(Object sender, EventArgs e)
        {
            TablaTareas tablaTareas = new TablaTareas();
            tablaTareas.ShowDialog();
        }

    }
}
