namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Size : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Tamaño")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Precio")]
        [Range(1, 1000, ErrorMessage = "Precio no aceptado")]
        public double Price { get; set; }
    }
}
