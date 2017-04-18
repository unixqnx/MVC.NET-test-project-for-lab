using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidationTest.Infrastructure;

namespace ValidationTest.Models
{
    //public class Appointment
    //{
    //    public string ClientName { get; set; }

    //    [DataType(DataType.Date)]
    //    public DateTime Date { get; set; }

    //    public bool TermsAccepted { get; set; }
    //}

    //[NoVasyaOnMondays]
    //public class Appointment
    //{
    //    [Required(ErrorMessage = "Введите своё имя")]
    //    public string ClientName { get; set; }

    //    [DataType(DataType.Date)]
    //    //[Required(ErrorMessage = "Введите дату")]
    //    [FutureDate (ErrorMessage = "Введите правильную дату")]
    //    public DateTime Date { get; set; }

    //    //[Range(typeof(bool), "true", "true", ErrorMessage ="Вы должны принять условия")]
    //    [MustBeTrue(ErrorMessage = "Вы должны принят условия")]
    //    public bool TermsAccepted { get; set; }
    //}




    //public class Appointment : IValidatableObject
    //{
    //    public string ClientName { get; set; }

    //    [DataType(DataType.Date)]
    //    public DateTime Date { get; set; }

    //    public bool TermsAccepted { get; set; }

    //    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    //    {

    //        List<ValidationResult> errors = new List<ValidationResult>();

    //        if (string.IsNullOrEmpty(ClientName))
    //            errors.Add(new ValidationResult("Введите своё имя"));

    //        if (DateTime.Now > Date)
    //            errors.Add(new ValidationResult("Введите дату относящуюся к будущему"));

    //        if (errors.Count == 0 && ClientName == "Вася" && Date.DayOfWeek == DayOfWeek.Monday)
    //            errors.Add(new ValidationResult("Васи по понедельникам отдыхают!"));

    //        if (!TermsAccepted)
    //            errors.Add(new ValidationResult("Вы должны принять условия"));

    //        return errors;
    //    }
    //}



    public class Appointment
    {
        [Required(ErrorMessage = "Введите своё имя")]
        [StringLength(10, MinimumLength =3)]
        public string ClientName { get; set; }

        [Remote("ValidateDate", "Home")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public bool TermsAccepted { get; set; }
    }

}