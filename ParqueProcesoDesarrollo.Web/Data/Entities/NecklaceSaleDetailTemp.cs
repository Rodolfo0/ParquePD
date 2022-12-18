using System.ComponentModel.DataAnnotations;

namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    public class NecklaceSaleDetailTemp : IEntity
    {
        public int Id { get; set; }

        public CollarSize CollarSize { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Cantidad")]
        public string FixedIpAddress { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double UnitPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]

        public double Amount { get { return this.UnitPrice * this.Quantity; } }
    }
}
