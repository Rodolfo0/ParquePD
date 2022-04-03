using System.ComponentModel.DataAnnotations;

namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    public class Supplies : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(2, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Código de barras")]
        public int Barcode { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(4, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Apellido Paterno")]
        public double UnitPrice { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }
    }
}
