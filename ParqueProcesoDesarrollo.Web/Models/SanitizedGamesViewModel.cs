using Microsoft.AspNetCore.Mvc.Rendering;
using ParqueProcesoDesarrollo.Web.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParqueProcesoDesarrollo.Web.Models
{
    public class SanitizedGamesViewModel : SanitizedGame
    {
        [Display(Name = "Responsable")]
        public string UserId { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }

        [Display(Name = "Tipo de Protocolo de Sanitiación")]
        public int SanitizacionProtocolId { get; set; }
        public IEnumerable<SelectListItem> SanitizationProtocols { get; set; }

        [Display(Name = "Atracción")]
        public int AtraccionId { get; set; }
        public IEnumerable<SelectListItem> Atractions { get; set; }
    }
}