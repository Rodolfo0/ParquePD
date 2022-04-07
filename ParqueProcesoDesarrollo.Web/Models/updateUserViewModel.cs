using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParqueProcesoDesarrollo.Web.Data.Entities;

namespace ParqueProcesoDesarrollo.Web.Models
{
    public class updateUserViewModel: User
    {
        [Display(Name = "Rol")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public string idRole { get; set; }

        [Display(Name = "Imágen")]
        public IFormFile ImageFile { get; set; }
        public IEnumerable<SelectListItem> roles { get; set; }
    }
}
