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

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Fecha de hora de salida")]
        public DateTime DateOfCheckOutTime { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Entregado")]
        public bool Delivered { get; set; }

        public WristbandSaleDetail WristbandSaleDetail { get; set; }
    }
}
