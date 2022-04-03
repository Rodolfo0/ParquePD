namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Status : IEntity
    {
        public int Id { get; set; }

        [MaxLength(50)] 
        public string Name { get; set; }

        public ICollection<Provider> Providers { get; set; }
    }
}
