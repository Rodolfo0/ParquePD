namespace ParqueProcesoDesarrollo.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using ParqueProcesoDesarrollo.Web.Data.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class addDogViewModel : SpaRegistration
    {
        [Display(Name = "Tamaño")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public int idSize { get; set; }

        public IEnumerable<SelectListItem> Sizes { get; set; }

        public int IdClient { get; set; }

        public IEnumerable<SelectListItem> Wristbands { get; set; }
    }
}
