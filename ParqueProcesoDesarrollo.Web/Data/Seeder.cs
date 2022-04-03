namespace ParqueProcesoDesarrollo.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using ParqueProcesoDesarrollo.Web.Data.Entities;
    using ParqueProcesoDesarrollo.Web.Helpers;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class Seeder
    {
        private readonly DataContext dataContext;
        private readonly IUserHelper userHelper;

        public Seeder(DataContext dataContext, IUserHelper userHelper)
        {
            this.dataContext = dataContext;
            this.userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();
            await userHelper.CheckRoleAsync("Gerente General");
            await userHelper.CheckRoleAsync("Gerente Administrativo");
            await userHelper.CheckRoleAsync("Gerente Compras");
            await userHelper.CheckRoleAsync("Cajero");
            await userHelper.CheckRoleAsync("Responsable Mantenimiento");
            await userHelper.CheckRoleAsync("Guardia");
            await userHelper.CheckRoleAsync("Encargado del juego");

            if(!this.dataContext.Employees.Any())
            {
                var user = await CheckUser("Axel", "Rodríguez", "Pérez", "153689", "FAB245", "peraxe@gmail.com", DateTime.Now, 4500, "12345");
                await CheckEmployee(user, "Gerente General");

                user = await CheckUser("Alex", "Roque", "Bautista", "153689", "FAB845", "roqueba@gmail.com", DateTime.Now, 4500, "12345");
                await CheckEmployee(user, "Gerente Administrativo");

                user = await CheckUser("Jesse", "Vélez", "Alatorre", "153689", "FAB245", "jesseve@gmail.com", DateTime.Now, 6500, "12345");
                await CheckEmployee(user, "Gerente Compras");

                user = await CheckUser("Yael", "Valadez", "Pérez", "153689", "FAB245", "yaelva@gmail.com", DateTime.Now, 4500, "12345");
                await CheckEmployee(user, "Cajero");

                user = await CheckUser("Dariel", "Ruiz", "Pérez", "153689", "FAB245", "ruizda@gmail.com", DateTime.Now, 4500, "12345");
                await CheckEmployee(user, "Responsable Mantenimiento");

                user = await CheckUser("Antonio", "Rodríguez", "Ruiz", "153689", "FAB245", "tonyr@gmail.com", DateTime.Now, 4500, "12345");
                await CheckEmployee(user, "Guardia");

                user = await CheckUser("Manuel", "Parra", "Pérez", "153689", "FAB245", "manupar@gmail.com", DateTime.Now, 4500, "12345");
                await CheckEmployee(user, "Encargado del juego");
            }

            if (!this.dataContext.Statuses.Any())
            {
                await CheckStatus("Activo");
                await CheckStatus("Inactivo");
                await CheckStatus("Perdido");
                await CheckStatus("Roto");
                await CheckStatus("En espera");
                await CheckStatus("En progreso");
                await CheckStatus("En mantenimiento");
                await CheckStatus("En reparación");
                await CheckStatus("Vacía");
                await CheckStatus("Llena");
                await CheckStatus("Emitida");
                await CheckStatus("Perdido");
                await CheckStatus("Impreso");
            }

            if (!this.dataContext.Providers.Any())
            {
                var status = dataContext.Statuses.FirstOrDefault(c => c.Id == 1);
                await CheckProvider("Prolimp S.A. de C.V.", "ANGQ59", "Camino Real, Puebla", "prolimp@gmail.com", "2756986", status);
            }

            if (!this.dataContext.ProviderContacts.Any())
            {
                var provider = dataContext.Providers.FirstOrDefault(c => c.Id == 1);
                await CheckProviderContact("Luis", "Ramírez", "Mendoza", "mendram@gmail.com", "2724683", provider, "Gerente de ventas", "Martes y jueves de 7-14 horas");
            }

            if (!this.dataContext.Supplies.Any())
            {
                await CheckSupplies(568892, 54.96, "Rollos de baño de 500 hojas dobles");
            }
        }

        public async Task<User> CheckUser(string firstName, string parentalSurname, string maternalSurname, string phone, string rfc, string email, DateTime dateOfHire, int salary, string password)
        {
            var user = await userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    ParentalSurname = parentalSurname,
                    MaternalSurname = maternalSurname,
                    PhoneNumber = phone,
                    RFC = rfc,
                    UserName = email,
                    Email = email,
                    DateOfHire = dateOfHire,
                    Salary = salary
                };
                var result = await userHelper.AddUserAsync(user, password);
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Error no se puede crear el usuario");
                }
            }
            return user;
        }

        public async Task CheckEmployee(User user, string rol)
        {
            this.dataContext.Employees.Add(new Employee
            {
                User = user
            });
            await this.dataContext.SaveChangesAsync();
            await userHelper.AddUserToRoleAsync(user, rol);
        }

        public async Task CheckStatus(string name)
        {
            this.dataContext.Statuses.Add(new Status { Name = name });
            await this.dataContext.SaveChangesAsync();
        }

        //64 minutos
        public async Task CheckSupplies(int barcode, double unitPrice, string description)
        {
            this.dataContext.Supplies.Add(new Supplies
            {
                Barcode = barcode,
                UnitPrice = unitPrice,
                Description = description
            });
            await this.dataContext.SaveChangesAsync();
        }

        public async Task CheckProvider(string socialReason, string rfc, string address, string email, string phone, Status status)
        {
            this.dataContext.Providers.Add(new Provider
            {
                SocialReason = socialReason,
                RFC = rfc,
                Address = address,
                Email = email,
                Phone = phone,
                Status = status
            });
            await this.dataContext.SaveChangesAsync();
        }

        public async Task CheckProviderContact(string name, string paternalSurname, string maternalSurname, string email, string phone, Provider provider, string post, string businessHours)
        {
            this.dataContext.ProviderContacts.Add(new ProviderContact
            {
                Name = name,
                PaternalSurname = paternalSurname,
                MaternalSurname = maternalSurname,
                Email = email,
                Phone = phone,
                Provider = provider,
                Post = post,
                BusinessHours = businessHours
            });
            await this.dataContext.SaveChangesAsync();
        }
    }
}
