﻿namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Status : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre de estado obligatorio")]
        [Display(Name = "Estado")]
        [MaxLength(50)] 
        public string Name { get; set; }

        public ICollection <Provider> Providers { get; set; }
        public ICollection <ParkingTicket> ParkingTickets { get; set; }
        public ICollection <CashBox> CashBoxes { get; set; }
        public ICollection <VrEquipment> VrEquipments { get; set; }
        public ICollection <Session> Sessions { get; set; }
        public ICollection <Attraction> Attractions { get; set; }
        public ICollection <PaymentMachine> PaymentMachines { get; set; }
        public ICollection <User> Users { get; set; }
        public ICollection <Maintenance> Maintenances { get; set; }
    }
}
