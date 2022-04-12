namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    public class Maintenance : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Fecha de mantenimiento")]
        public DateTime MaintenanceDate { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Fecha de última revisión")]
        public DateTime DateOfLastOverhaul { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(200, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Observaciones")]
        public string Remarks { get; set; }

        public User User { get; set; }
        public TypeOfMaintenance TypeOfMaintenance { get; set; }
        public Attraction Attraction { get; set; }
    }
}
