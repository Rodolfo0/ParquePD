namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PurchaseHeader : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Fecha de emisión")]
        public DateTime IssueDate { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Fecha de pago")]
        public DateTime DateofPayment { get; set; }

        public Provider Provider { get; set; }
        [Display(Name = "Tipo de pago")]
        public TypeOfPayment TypeOfPayment { get; set; }
        public ICollection <PurchaseDetail> PurchaseDetails { get; set; } 
    }
}
