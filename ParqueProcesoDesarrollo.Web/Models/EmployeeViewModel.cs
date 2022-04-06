namespace ParqueProcesoDesarrollo.Web.Models
{
    using ParqueProcesoDesarrollo.Web.Data.Entities;
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel;

    public class EmployeeViewModel : Employee
    {
        [DisplayName("Foto del Usuario")]
        public IFormFile ImageFile { get; set; }
    }
}
