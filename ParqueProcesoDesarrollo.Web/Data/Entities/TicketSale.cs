namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class TicketSale : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Fecha de emisión")]
        public DateTime DateOfIssue { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        [Display(Name = "Subtotal")]
        public double Subtotal { get { return this.WristbandSaleDetails == null ? 0 : this.NecklaceSaleDetails == null ? this.WristbandSaleDetails.Sum(i => i.Amount) : this.WristbandSaleDetails.Sum(i => i.Amount) + this.NecklaceSaleDetails.Sum(p => p.Amount); }  }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Total")]
        public double Total { get { return Subtotal * .16 + Subtotal; } }

        public Status Status { get; set; }
        public CashBox CashBox { get; set; }

        public IvaType IvaTypes { get; set; }
        public ICollection <WristbandSaleDetail> WristbandSaleDetails { get; set; }
        public ICollection <NecklaceSaleDetail> NecklaceSaleDetails { get; set; }
    }
}
