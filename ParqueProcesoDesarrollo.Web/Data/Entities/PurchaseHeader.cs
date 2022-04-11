namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PurchaseHeader : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Fecha de emisión")]
        public DateTime IssueDate { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Fecha de pago")]
        public DateTime DateofPayment { get; set; }

        public Provider Provider { get; set; }
        public TypeOfPayment TypeOfPayment { get; set; }
        public ICollection <PurchaseDetail> PurchaseDetails { get; set; } 
    }
}
