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
    public class TicketSaleViewModel : Provider
    {
        [Display(Name = "Estado")]
        public int StatusId { get; set; }

        public IEnumerable<SelectListItem> Statuses { get; set; }

        [Display(Name = "Pulsera")]
        public int WristbandId { get; set; }
        public IEnumerable<SelectListItem> Wristbands { get; set; }

        [Display(Name = "Collar")]
        public int CollarSizeId { get; set; }
        public IEnumerable<SelectListItem> CollarSizes { get; set; }

        [Display(Name = "Cantidad")]
        public double Quantity { get; set; }

    }
}
