namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Location : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(15, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Ubicación")]
        public string Place { get; set; }

        public ICollection <PrintingMachine> PrintingMachines { get; set; }
        public ICollection <ReceivingMachine> ReceivingMachines { get; set; }   
        public ICollection <PaymentMachine> PaymentMachines { get; set; }
    }
}
