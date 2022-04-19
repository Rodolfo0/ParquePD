namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Kit : IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Fecha de venta")]
        public DateTime DateOfSale { get; set; }

        [Required(ErrorMessage = "{0} Campo obligatorio")]
        [Display(Name = "Cantidad")]
        [Range(1, 30, ErrorMessage = "Cantidad de kits no válida")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Precio Unitario")]
        public float UnitPrice { get; set; }
    }
}
