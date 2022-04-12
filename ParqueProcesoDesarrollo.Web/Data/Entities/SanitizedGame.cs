namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    
    public class SanitizedGame : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(200, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Observaciones")]
        public string Remarks { get; set; }

        public User User { get; set; }
        public Attraction Attraction { get; set; }
        public SanitizationProtocol SanitizationProtocol { get; set; }
    }
}
