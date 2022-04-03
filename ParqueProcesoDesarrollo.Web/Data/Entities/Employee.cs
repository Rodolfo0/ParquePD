namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    public class Employee : IEntity
    {
        public int Id { get; set; }

        public User User { get; set; }
    }
}
