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
    public class TicketSaleViewModel : TicketSale
    {
        public int SaleId { get; set; }

        [Display(Name = "Estado")]
        public int StatusId { get; set; }

        public IEnumerable<SelectListItem> Statuses { get; set; }

        [Display(Name = "Tipo de Pulsera")]
        public int WristbandId { get; set; }
        public IEnumerable<SelectListItem> Wristbands { get; set; }

        [Display(Name = "Nombre de la persona a cargo")]
        public string NameOfPersonInCharge  { get; set; }

        [Display(Name = "Tipo de Collar Collar")]
        public int CollarSizeId { get; set; }
        public IEnumerable<SelectListItem> CollarSizes { get; set; }

        [Display(Name = "Cantidad de Pulseras")]
        public int WristBandsQuantity { get; set; }

        [Display(Name = "Cantidad de Collares")]
        public int CollarQuantity { get; set; }

        public ICollection<WristbandSaleDetailTemp> WristbandSaleDetailTemp { get; set; }
        public ICollection<NecklaceSaleDetailTemp> NecklaceSaleDetailTemp { get; set; }

    }
}
