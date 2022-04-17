namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class MachineReport : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Fecha de creación")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Monto")]
        public int Amount { get; set; }

        public PaymentMachine PaymentMachine { get; set; }
    }
}
