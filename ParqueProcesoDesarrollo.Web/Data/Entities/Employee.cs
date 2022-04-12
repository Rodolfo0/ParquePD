using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    public class Employee : IEntity
    {
        [Display(Name = "Número de Empleado")]
        public int Id { get; set; }

        public User User { get; set; }
        public ICollection <Attraction> Attractions { get; set; }
        public ICollection <SanitizedGame> SanitizedGames { get; set; }
        public ICollection <Maintenance> Maintenances { get; set; }
        public ICollection <CashBox> CashBoxes { get; set; }
    }
}
