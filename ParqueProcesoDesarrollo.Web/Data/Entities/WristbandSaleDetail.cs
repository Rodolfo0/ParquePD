namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class WristbandSaleDetail : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Cantidad")]
        public double Quantity { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Nombre del responsable")]
        public string NameOfPersonInCharge { get; set; }

        public TypeOfWristband TypeOfWristband { get; set; }
        public TicketSale TicketSale { get; set; } 
        public ICollection <SpaRegistration> SpaRegistrations { get; set; }

        public double UnitPrice { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:N2}")]

        public double Amount { get { return this.UnitPrice * this.Quantity; } }
    }
}
