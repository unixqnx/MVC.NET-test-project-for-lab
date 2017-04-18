using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ValidationTest.Models;

namespace ValidationTest.Infrastructure
{
    public class NoVasyaOnMondaysAttribute : ValidationAttribute
    {

        public NoVasyaOnMondaysAttribute()
        {
            ErrorMessage = "Васи в понедельник отдыхают!";
        }


        public override bool IsValid(object value)
        {
            Appointment app = value as Appointment;

            if (app == null || string.IsNullOrEmpty(app.ClientName) || app.Date == null)
            {
                return true;
            }
            else
            {

                return !(app.ClientName == "Вася" && app.Date.DayOfWeek == DayOfWeek.Monday);
            }
        }
    }
}