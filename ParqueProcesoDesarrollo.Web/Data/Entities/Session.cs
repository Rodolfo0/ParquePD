namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Session : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Hora de inicio")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime SessionDate { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:hh:mm:ss tt}")]
        [Display(Name = "Hora de inicio")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:hh:mm:ss tt}")]
        [Display(Name = "Hora de fin")]
        public DateTime FinishTime { get; set; }

        public Status Status { get; set; }

        public ICollection<VisitorSession> VisitorSession { get; set; }

        public ICollection<VisitorNextSession> VisitorNextSession { get; set; }
    }
}
