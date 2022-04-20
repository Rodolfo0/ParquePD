namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class SpaRegistration : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Fecha de hora de entrada")]
        public DateTime DateOfCheckInTime { get; set; }

        [Display(Name = "Fecha de hora de salida")]
        public DateTime DateOfCheckOutTime { get; set; }

        [Display(Name = "Entregado")]
        public bool Delivered { get; set; }

        [Display(Name = "Dueño")]
        [MaxLength(100)]
        public string Owner { get; set; }
        public WristbandSaleDetail WristbandSaleDetail { get; set; }

        [Display(Name = "Tamaño")]
        public Size Size { get; set; }

    }
}
