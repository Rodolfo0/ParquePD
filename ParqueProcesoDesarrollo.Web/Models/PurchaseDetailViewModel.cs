namespace ParqueProcesoDesarrollo.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using ParqueProcesoDesarrollo.Web.Data.Entities;
    using System.Collections.Generic;

    public class PurchaseDetailViewModel : PurchaseDetail
    {
        public int SupplyId { get; set; }
        public IEnumerable<SelectListItem> Supplies { get; set; }

        public int PurchaseHeaderId { get; set; }
        public IEnumerable<SelectListItem> PurchaseHeaders { get; set; }
    }
}