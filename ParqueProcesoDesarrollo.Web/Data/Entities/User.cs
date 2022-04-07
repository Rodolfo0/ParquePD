namespace ParqueProcesoDesarrollo.Web.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        [Required(ErrorMessage = "{0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Display(Name = "Apellido Paterno")]
        public string ParentalSurname { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Display(Name = "Apellido Materno")]
        public string MaternalSurname { get; set; }

        [MaxLength(15, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Display(Name = "Teléfono")]
        public override string PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [MaxLength(14, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Display(Name = "RFC")]
        public string RFC { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Display(Name = "Email")]
        public override string Email { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [Display(Name = "Fecha de contratación")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime HiringDate { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio.")]
        [Display(Name = "Salario ")]
        public int Salary { get; set; }

        [Display(Name = "Foto del Usuario")]
        public string ImageUrl { get; set; }
        [Display(Name = "Rol ")]
        public IdentityRole Role { get; set; }

        [Display(Name = "Nombre")]
        public string FullName => $"{ParentalSurname} {MaternalSurname} {FirstName}";
    }
}