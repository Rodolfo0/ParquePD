namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    
    public class VisitorSession : IEntity
    {
        public int Id { get; set; }

        public WristbandSaleDetail WristbandSaleDetail { get; set; }
        public VrEquipment VrEquipment { get; set; }
        public Session Session { get; set; }
    }
}
