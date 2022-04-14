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
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Hora de fin")]
        public DateTime FinishTime { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Hora de inicio")]
        public DateTime SessionDate { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Sesión interrumpida")]
        public bool SessionInterrupted { get; set; }

        public Status Status { get; set; }
        public ICollection <VisitorSession> VisitorSessions { get; set; }
    }
}
