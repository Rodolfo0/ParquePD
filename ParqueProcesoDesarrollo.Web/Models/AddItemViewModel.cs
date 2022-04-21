using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParqueProcesoDesarrollo.Web.Models
{
    public class AddItemViewModel
    {
        //[Display(Name = "Collar")]
        //[Range(1, int.MaxValue, ErrorMessage = "Porfavor elija un collar")]
        //public int CollarId { get; set; }

        [Display(Name = "Pulsera")]
        [Range(1, int.MaxValue, ErrorMessage = "Porfavor elija una pulsera")]
        public int WristbandId { get; set; }

        [Range(0.0001, double.MaxValue, ErrorMessage = "Debe ser positivo")]
        public double Quantity { get; set; }

        public string NameOfPersonInCharge { get; set; }
        public IEnumerable<SelectListItem> TypeOfWristband { get; set; }
        //public IEnumerable<SelectListItem> CollarSize { get; set; }
    }
}
