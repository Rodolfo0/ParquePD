namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Supply : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Código de barras")]
        public int Barcode { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Precio unitario")]
        public double UnitPrice { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        public Provider Provider { get; set; }
        public ICollection <PurchaseDetail> PurchasDetails { get; set; }
    }
}
