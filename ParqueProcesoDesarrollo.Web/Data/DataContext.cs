namespace ParqueProcesoDesarrollo.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using ParqueProcesoDesarrollo.Web.Data.Entities;

    public class DataContext : IdentityDbContext<User>
    {
        //public DbSet<Entidad> Entidades 
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}