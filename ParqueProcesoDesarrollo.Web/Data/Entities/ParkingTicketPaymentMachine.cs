namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    
    public class ParkingTicketPaymentMachine : IEntity
    {
        public int Id { get; set; }

        public PaymentMachine PaymentMachine { get; set; }
        public ParkingTicket ParkingTicket { get; set; }
    }
}
