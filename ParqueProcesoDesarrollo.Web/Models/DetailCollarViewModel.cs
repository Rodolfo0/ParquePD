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
    public class DetailCollarViewModel
    {

        public IEnumerable<SelectListItem> TypeOfCollars { get; set; }

        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        [Display(Name = "Tamaño de la correa")]
        public IEnumerable<SelectListItem> Sizes { get; set; }

        public int IdVenta { get; set; }
    }
}
