using Microsoft.AspNetCore.Mvc.Rendering;
using ParqueProcesoDesarrollo.Web.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParqueProcesoDesarrollo.Web.Models
{
    public class SupplyViewModel:Supply
    {

        [Display(Name = "Proveedor")]
        public int ProviderId { get; set; }
        public IEnumerable<SelectListItem> Providers { get; set; }
    }
}
