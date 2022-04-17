namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ParkingTicket : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Fecha de entrada")]
        public DateTime DateOfEntry { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Hora de entrada")]
        public DateTime TimeOfEntry { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Hora de pago")]
        public DateTime TimeOfPayment { get; set; }

        public Status Status { get; set; }
        public PrintingMachine PrintingMachine { get; set; }
        public ICollection <ReceivingMachine> ReceivingMachines { get; set; }   
        public ICollection <ParkingTicketPaymentMachine> ParkingTicketPaymentMachines { get; set; } 
    }
}
