using ParqueProcesoDesarrollo.Web.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParqueProcesoDesarrollo.Web.Models
{
    public class SessionViewModel : Session
    {
        public int StatusId { get; set; }

        [Required(ErrorMessage = "Por favor, seleccione un visitante")]
        [Display(Name = "Visitantes")]
        public int VisitorId { get; set; }

        public IEnumerable<SelectListItem> Visitors { get; set; }
    }
}
