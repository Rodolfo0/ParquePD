using ParqueProcesoDesarrollo.Web.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParqueProcesoDesarrollo.Web.Models
{
    public class MaintenanceViewModel : Maintenance
    {
        [Display(Name = "Responsable")]
        public int UserId { get; set; }

        public IEnumerable<SelectListItem> Users { get; set; }

        [Display(Name = "Tipo de Mantenimiento")]
        public int MaintenanceId { get; set; }

        public IEnumerable<SelectListItem> TPMaintenances { get; set; }

        [Display(Name = "Atraccion")]
        public int AtraccionId { get; set; }

        public IEnumerable<SelectListItem> Atractions { get; set; }
    }
}