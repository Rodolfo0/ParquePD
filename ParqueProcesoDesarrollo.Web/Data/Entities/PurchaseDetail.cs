namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class PurchaseDetail : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Precio unitario")]
        public double UnitPrice { get; set; }

        public Supply Supply { get; set; } 
        public PurchaseHeader PurchaseHeader { get; set; } 
    }
}
