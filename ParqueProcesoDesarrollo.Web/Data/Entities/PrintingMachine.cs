namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class PrintingMachine : IEntity
    {
        public int Id { get; set; }

        public Location Location { get; set; }
    }
}
