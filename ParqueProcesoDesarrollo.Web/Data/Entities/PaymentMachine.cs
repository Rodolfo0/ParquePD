namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class PaymentMachine : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Monedas de inicio de 5")]
        public int StartCurrency5 { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Monedas de inicio de 10")]
        public int StartCurrency10 { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Billetes de inicio de 50")]
        public int StartBill50 { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Billetes de inicio de 100")]
        public int StartBill100 { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Monedas ingresadas de 5")]
        public int CurrencyEntered5 { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Monedas ingresadas de 10")]
        public int CurrencyEntered10 { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Billetes ingresados de 50")]
        public int BillEntered50 { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Billetes ingresados de 100")]
        public int BillEntered100 { get; set; }

        public Status Status { get; set; }
        public Location Location { get; set; }
        public ICollection <ParkingTicketPaymentMachine> ParkingTicketPaymentMachines { get; set; }
        public ICollection<MachineReport> MachineReports { get; set; }

    }
}
