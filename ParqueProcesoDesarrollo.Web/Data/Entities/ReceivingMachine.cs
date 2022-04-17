namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    public class ReceivingMachine : IEntity
    {
        public int Id { get; set; }

        public Location Location { get; set; }
        public ParkingTicket ParkingTicket { get; set; }
    }
}
