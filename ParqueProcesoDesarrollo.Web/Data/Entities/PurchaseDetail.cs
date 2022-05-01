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

        [Display(Name = "Consumible")]
        public Supply Supply { get; set; }
        [Display(Name = "Razón social del proveedor")]
        public PurchaseHeader PurchaseHeader { get; set; } 
    }
}
