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