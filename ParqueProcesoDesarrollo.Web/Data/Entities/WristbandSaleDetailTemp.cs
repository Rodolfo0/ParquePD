using System.ComponentModel.DataAnnotations;

namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    public class WristbandSaleDetailTemp : IEntity
    {
        public int Id { get; set; }

        

        [Required]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double UnitPrice { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Quantity { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}")]

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Nombre del responsable")]
        public string NameOfPersonInCharge { get; set; }

        public double Amount { get { return this.UnitPrice * this.Quantity; } }

        public TypeOfWristband TypeOfWristband { get; set; }

    }
}
