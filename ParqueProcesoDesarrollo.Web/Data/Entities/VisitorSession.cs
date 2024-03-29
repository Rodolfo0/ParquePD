﻿using System.ComponentModel.DataAnnotations;

namespace ParqueProcesoDesarrollo.Web.Data.Entities
{

    public class VisitorSession : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Visitante")]
        public WristbandSaleDetail WristbandSaleDetail { get; set; }

        [Display(Name = "Equipo VR")]
        public VrEquipment VrEquipment { get; set; }

        [Display(Name = "Sesión")]
        public Session Session { get; set; }
    }
}
