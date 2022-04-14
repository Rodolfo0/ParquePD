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
    public class ProviderContactViewModel:ProviderContact
    {
        [Display(Name = "Proveedor")]
        public int ProviderId { get; set; }

        public IEnumerable<SelectListItem> Providerses { get; set; }
    }
}
