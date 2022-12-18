namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    
    public class NecklaceSaleDetail : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double UnitPrice { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:C2}")]

        public double Amount { get { return this.UnitPrice * this.Quantity; } }
        public string FixedIpAddress { get; set; }

        public CollarSize CollarSize { get; set; }
        public TicketSale TicketSale { get; set; }
    }
}
