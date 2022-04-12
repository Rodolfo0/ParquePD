namespace ParqueProcesoDesarrollo.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using ParqueProcesoDesarrollo.Web.Data.Entities;
    using System.Linq;

    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<ConsumableWarehouse> ConsumableWarehouses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProviderContact> ProviderContacts { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public DbSet<PurchaseHeader> PurchaseHeader { get; set; }
        public DbSet<SanitizationProtocol> SanitizationProtocols { get; set; }
        public DbSet<SanitizedGame> SanitizedGames { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<TypeOfMaintenance> TypeOfMaintenances { get; set; }
        public DbSet<TypeOfPayment> TypeOfPayments { get; set; }
        public override DbSet<User> Users { get; set; }

        //public DbSet<Entidad> Entidades
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //DataContext
            //Aquí van las entidades
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    var cascadeFKs = builder.Model
        //    .GetEntityTypes()
        //    .SelectMany(testc => t.GetForeignKeys())
        //    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
        //    foreach (var fk in cascadeFKs)
        //    {
        //         fk.DeleteBehavior = DeleteBehavior.Cascade;
        //    }
        //    base.OnModelCreating(builder);
        //}
    }
}