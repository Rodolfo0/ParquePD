namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class TypeOfWristband : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Color")]
        public string Colour { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Precio")]
        public double Price{ get; set; }

        public ICollection <WristbandSaleDetail> WristbandSaleDetails { get; set; }
    }
}
