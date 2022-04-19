namespace ParqueProcesoDesarrollo.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using ParqueProcesoDesarrollo.Web.Data.Entities;
    using System.Linq;

    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<CashBox> CashBoxes { get; set; }
        public DbSet<CollarSize> CollarSizes { get; set; }
        public DbSet<ConsumableWarehouse> ConsumableWarehouses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<IvaType> IvaTypes { get; set; }
        public DbSet<Kit> Kits { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<MachineReport> MachineReports { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<NecklaceSaleDetail> NecklaceSaleDetails { get; set; }
        public DbSet<ParkingTicket> ParkingTickets { get; set; }
        public DbSet<ParkingTicketPaymentMachine> ParkingTicketPaymentMachines { get; set; }    
        public DbSet<PaymentMachine> PaymentMachines { get; set; }
        public DbSet<PrintingMachine> PrintingMachines { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProviderContact> ProviderContacts { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public DbSet<PurchaseHeader> PurchaseHeader { get; set; }
        public DbSet<ReceivingMachine> ReceivingMachines { get; set; }
        public DbSet<SanitizationProtocol> SanitizationProtocols { get; set; }
        public DbSet<SanitizedGame> SanitizedGames { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<SpaRegistration> SpaRegistrations { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<TicketSale> TicketSales { get; set; }
        public DbSet<TypeOfMaintenance> TypeOfMaintenances { get; set; }
        public DbSet<TypeOfPayment> TypeOfPayments { get; set; }
        public DbSet<TypeOfWristband> TypeOfWristbands { get; set; }
        public override DbSet<User> Users { get; set; }
        public DbSet<VisitorSession> VisitorSessions { get; set; }
        public DbSet<VrEquipment> VrEquipments { get; set; }
        public DbSet<WristbandSaleDetail> WristbandsSaleDetail { get; set; }

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