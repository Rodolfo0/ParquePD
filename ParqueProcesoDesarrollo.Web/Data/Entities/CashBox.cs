namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class CashBox : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "IP")]
        public string Ip { get; set; }

        public Employee Employee { get; set; }
        public Status Status { get; set; }
        public ICollection <TicketSale> TicketSales { get; set; }
    }
}
