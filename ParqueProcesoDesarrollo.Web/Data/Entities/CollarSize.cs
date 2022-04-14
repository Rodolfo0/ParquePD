namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class CollarSize : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(15, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Cantidad")]
        public string Size { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Precio")]
        public double Price { get; set; }

        public ICollection <NecklaceSaleDetail> NecklaceSaleDetails { get; set; }
    }
}
