using System.ComponentModel.DataAnnotations;

namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    public class Employee : IEntity
    {
        [Display(Name = "Número de Empleado")]
        public int Id { get; set; }

        public User User { get; set; }
    }
}
