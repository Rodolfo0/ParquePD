namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class VrEquipment : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Modelo")]
        public string Model { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Marca")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Fecha de adquisición")]
        public DateTime DateOfPurchase { get; set; }

        public Status Status { get; set; }
        public ICollection <VisitorSession> VisitorSessions { get; set; }
    }
}
