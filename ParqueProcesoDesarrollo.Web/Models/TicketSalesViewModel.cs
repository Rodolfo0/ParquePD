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
    public class TicketSalesViewModel : TicketSale
    {
        public WristbandSaleDetail WristbandSaleDetail { get; set; }

        public CollarSize CollarSize { get; set; }  

    }
}
