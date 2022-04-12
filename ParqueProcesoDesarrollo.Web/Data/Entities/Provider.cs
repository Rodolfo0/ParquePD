namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Provider : IEntity
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(25, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Razón social")]
        public string SocialReason { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "RFC")]
        public string RFC{ get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Correo")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(25, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }
        
        public Status Status { get; set; }
        public ICollection <Supply> Supplies { get; set; }
        public ICollection <ProviderContact> ProviderContacts { get; set; }
        public ICollection <PurchaseHeader> PurchaseHeaders { get; set; }  
    }
}
