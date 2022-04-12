namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class TicketSale : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Fecha de emisión")]
        public DateTime DateOfIssue { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Subtotal")]
        public double Subtotal { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Total")]
        public double Total { get; set; }

        public CashBox CashBox { get; set; }
        public IvaType IvaType { get; set; }
        public ICollection <WristbandSaleDetail> WristbandSaleDetails { get; set; }
        public ICollection <NecklaceSaleDetail> NecklaceSaleDetails { get; set; }
    }
}
