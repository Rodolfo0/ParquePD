namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Attraction : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Nombre")]
        public string Name{ get; set; }

        public Status Status { get; set; } 
        public Employee Employee { get; set; }
        public ICollection <Maintenance> Maintenances { get; set; }
        public ICollection <SanitizedGame> SanitizedGames { get; set; }
    }
}
