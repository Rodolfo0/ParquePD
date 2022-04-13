namespace ParqueProcesoDesarrollo.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using ParqueProcesoDesarrollo.Web.Data.Entities;
    using System.Collections.Generic;

    public class PurchaseHeaderViewModel : PurchaseHeader
    {
        public int ProviderId { get; set; }
        public IEnumerable<SelectListItem> Providers { get; set; }

        public int TypeOfPaymentId { get; set; }
        public IEnumerable<SelectListItem> TypeOfPayments { get; set; }
    }
}
