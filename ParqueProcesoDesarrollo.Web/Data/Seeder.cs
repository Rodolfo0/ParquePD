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

            if (!this.dataContext.Employees.Any())
            {
                var status = dataContext.Statuses.FirstOrDefault(c => c.Id == 1);
                var user = await CheckUser("Axel", "Rodríguez", "Pérez", "153689", "FAB245", "peraxe@gmail.com"
                    , DateTime.Now, 4500, null, "12345", status);
                await CheckEmployee(user, "Gerente General");

                user = await CheckUser("Alex", "Roque", "Bautista", "153689", "FAB845", "roqueba@gmail.com"
                    , DateTime.Now, 4500, null, "12345", status);
                await CheckEmployee(user, "Gerente Administrativo");

                user = await CheckUser("Jesse", "Vélez", "Alatorre", "153689", "FAB245", "jesseve@gmail.com"
                    , DateTime.Now, 6500, null, "12345", status);
                await CheckEmployee(user, "Gerente Compras");

                user = await CheckUser("Yael", "Valadez", "Pérez", "153689", "FAB245", "yaelva@gmail.com"
                    , DateTime.Now, 4500, null, "12345", status);
                await CheckEmployee(user, "Cajero");

                user = await CheckUser("Dariel", "Ruiz", "Pérez", "153689", "FAB245", "ruizda@gmail.com"
                    , DateTime.Now, 4500, null, "12345", status);
                await CheckEmployee(user, "Responsable Mantenimiento");

                user = await CheckUser("Antonio", "Rodríguez", "Ruiz", "153689", "FAB245", "tonyr@gmail.com"
                    , DateTime.Now, 4500, null, "12345", status);
                await CheckEmployee(user, "Guardia");

                user = await CheckUser("Manuel", "Parra", "Pérez", "153689", "FAB245", "manupar@gmail.com"
                    , DateTime.Now, 4500, null, "12345", status);
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
                await CheckStatus("Pagado");
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
                var provider = dataContext.Providers.FirstOrDefault(c => c.Id == 1);
                await CheckSupply(568892, 54.96, "Rollos de baño de 500 hojas dobles", provider);
            }

            if (!this.dataContext.TypeOfMaintenances.Any())
            {
                await CheckTypeOfMaintenance("Preventivo");
                await CheckTypeOfMaintenance("Correctivo");
            }

            if (!this.dataContext.SanitizationProtocols.Any())
            {
                await CheckSanitizationProtocol("Bomba de pulverización");
                await CheckSanitizationProtocol("Limpieza con microfibra y atomizador");
            }

            if (!this.dataContext.Attractions.Any())
            {
                var status = dataContext.Statuses.FirstOrDefault(c => c.Id == 1);
                var employee = dataContext.Employees.FirstOrDefault(c => c.Id == 7);
                await CheckAttraction("Carrucel", status, employee);

                await CheckAttraction("Devora Tormentas", status, employee);

                await CheckAttraction("Kamikase", status, employee);

                await CheckAttraction("Krakatoa", status, employee);

                await CheckAttraction("Kilawea", status, employee);
            }

            //Tamaños de perros
            if (!this.dataContext.Sizes.Any())
            {
                await CheckSize("Pequeño", 260);

                await CheckSize("Mediano", 310);

                await CheckSize("Grande", 450);
            }

            if (!this.dataContext.TypeOfPayments.Any())
            {
                await CheckTypeOfPayment("Efectivo");
                await CheckTypeOfPayment("Tarjeta VISA");
                await CheckTypeOfPayment("Tarjeta Mastercard");
            }

            if (!this.dataContext.IvaTypes.Any())
            {
                await CheckIvaType("Impuesto Valor Agregado", 0.16);
            }

            if (!this.dataContext.TypeOfWristbands.Any())
            {
                await CheckTypeOfWristband("Adulto", "Rojo", 500);
                await CheckTypeOfWristband("Niño", "Verde", 400);
                await CheckTypeOfWristband("Adulto Mayor", "Azul", 300);
                await CheckTypeOfWristband("Adulto VIP", "Rojo con Amarillo", 600);
                await CheckTypeOfWristband("Niño VIP", "Verde con Amarillo", 500);
                await CheckTypeOfWristband("Adulto Mayor VIP", "Azul con Amarillo", 400);
            }

            if (!this.dataContext.CollarSizes.Any())
            {
                await CheckCollarSize("Pequeña", 100);
                await CheckCollarSize("Mediana", 150);
                await CheckCollarSize("Grande", 200);
            }

            if (!this.dataContext.CashBoxes.Any())
            {
                var status = dataContext.Statuses.FirstOrDefault(c => c.Id == 1);
                var employee = dataContext.Employees.FirstOrDefault(c => c.Id == 4);
                await CheckCashBox("192.168.586.544", employee, status);
            }

            if (!this.dataContext.Locations.Any())
            {
                await CheckLocation("Entrada 1");
                await CheckLocation("Entrada 2");
                await CheckLocation("Entrada 3");
                await CheckLocation("Entrada 4");
                await CheckLocation("Salida 1");
                await CheckLocation("Salida 2");
                await CheckLocation("Salida 3");
                await CheckLocation("Salida 4");
            }

            if (!this.dataContext.PaymentMachines.Any())
            {
                var location = this.dataContext.Locations.FirstOrDefault(l => l.Place == "Salida 1");
                var status = this.dataContext.Statuses.FirstOrDefault(s => s.Name == "Inactivo");
                await CheckPaymentMachines(location, status);

                location = this.dataContext.Locations.FirstOrDefault(l => l.Place == "Salida 2");
                await CheckPaymentMachines(location, status);

                location = this.dataContext.Locations.FirstOrDefault(l => l.Place == "Salida 3");
                await CheckPaymentMachines(location, status);

                location = this.dataContext.Locations.FirstOrDefault(l => l.Place == "Salida 4");
                await CheckPaymentMachines(location, status);
            }

            if (!this.dataContext.PrintingMachines.Any())
            {
                var location = this.dataContext.Locations.FirstOrDefault(l => l.Place == "Entrada 1");
                await CheckPrintingMachines(location);

                location = this.dataContext.Locations.FirstOrDefault(l => l.Place == "Entrada 2");
                await CheckPrintingMachines(location);

                location = this.dataContext.Locations.FirstOrDefault(l => l.Place == "Entrada 3");
                await CheckPrintingMachines(location);

                location = this.dataContext.Locations.FirstOrDefault(l => l.Place == "Entrada 4");
                await CheckPrintingMachines(location);
            }

            if (!this.dataContext.ReceivingMachines.Any())
            {
                var location = this.dataContext.Locations.FirstOrDefault(l => l.Place == "Salida 1");
                await CheckReceivingMachines(location);

                location = this.dataContext.Locations.FirstOrDefault(l => l.Place == "Salida 2");
                await CheckReceivingMachines(location);

                location = this.dataContext.Locations.FirstOrDefault(l => l.Place == "Salida 3");
                await CheckReceivingMachines(location);

                location = this.dataContext.Locations.FirstOrDefault(l => l.Place == "Salida 4");
                await CheckReceivingMachines(location);
            }

            if (!this.dataContext.Sessions.Any())
            {
                var status = this.dataContext.Statuses.FirstOrDefault(s => s.Name == "En espera");
                await CheckSession(DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, status);
            }

            if (!this.dataContext.VrEquipments.Any())
            {
                var status = this.dataContext.Statuses.FirstOrDefault(s => s.Name == "Activo");

                await CheckVrEquipment("Quest 2", "Oculus", DateTime.Today, status);
                await CheckVrEquipment("Quest 2", "Oculus", DateTime.Today, status);
                await CheckVrEquipment("Quest 2", "Oculus", DateTime.Today, status);
                await CheckVrEquipment("Quest 2", "Oculus", DateTime.Today, status);
                await CheckVrEquipment("Quest 2", "Oculus", DateTime.Today, status);
                await CheckVrEquipment("Quest 2", "Oculus", DateTime.Today, status);
                await CheckVrEquipment("Quest 2", "Oculus", DateTime.Today, status);
                await CheckVrEquipment("Vive", "HTC", DateTime.Today, status);
                await CheckVrEquipment("Vive", "HTC", DateTime.Today, status);
                await CheckVrEquipment("Vive", "HTC", DateTime.Today, status);
            }

            //if (!this.dataContext.TicketSales.Any())
            //{
            //    var cashBox = this.dataContext.CashBoxes.FirstOrDefault(cb => cb.Id == 1);
            //    var iva = this.dataContext.IvaTypes.FirstOrDefault(i => i.Id == 1);
            //    var status = this.dataContext.Statuses.FirstOrDefault(s => s.Name == "Emitida");
            //    await CheckTicketSale(cashBox, DateTime.MinValue, iva, status);
            //    await CheckTicketSale(cashBox, DateTime.Today, iva, status);
            //    await CheckTicketSale(cashBox, new DateTime(2001, 01, 15), iva, status);
            //}

            //if (!this.dataContext.WristbandsSaleDetail.Any())
            //{
            //    var type = this.dataContext.TypeOfWristbands.FirstOrDefault(t => t.Id == 4);
            //    var sale = this.dataContext.TicketSales.FirstOrDefault(t => t.Id == 1);
            //    await CheckWrisbandSaleDetail(1.0, "Pepe Pecas", type, sale, 600.0);

            //    type = this.dataContext.TypeOfWristbands.FirstOrDefault(t => t.Id == 3);
            //    sale = this.dataContext.TicketSales.FirstOrDefault(t => t.Id == 2);
            //    await CheckWrisbandSaleDetail(1.0, "Rosa Sanchez", type, sale, 300.0);

            //    type = this.dataContext.TypeOfWristbands.FirstOrDefault(t => t.Id == 4);
            //    sale = this.dataContext.TicketSales.FirstOrDefault(t => t.Id == 3);
            //    await CheckWrisbandSaleDetail(1.0, "Jose Manuel", type, sale, 600.0);
            //}
        }

        public async Task<User> CheckUser(string firstName, string parentalSurname, string maternalSurname, 
            string phone, string rfc, string email, DateTime hiringDate, int salary, string imageUrl,
            string password, Status status)
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
                    HiringDate = hiringDate,
                    Salary = salary,
                    ImageUrl = imageUrl == null ? $"~/images/_default.jpeg" : imageUrl,
                    Status = status
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
        public async Task CheckSupply(int barcode, double unitPrice, string description, Provider provider)
        {
            this.dataContext.Supplies.Add(new Supply
            {
                Barcode = barcode,
                UnitPrice = unitPrice,
                Description = description,
                Provider = provider
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

        public async Task CheckTypeOfMaintenance(string description)
        {
            this.dataContext.TypeOfMaintenances.Add(new TypeOfMaintenance
            {
                Description = description
            });
            await this.dataContext.SaveChangesAsync();
        }

        public async Task CheckAttraction(string name, Status status, Employee employee)
        {
            this.dataContext.Attractions.Add(new Attraction
            {
                Name = name,
                Status = status,
                Employee = employee
            });
            await this.dataContext.SaveChangesAsync();
        }
        //Check tamaños perros
        public async Task CheckSize(string name, double price)
        {
            dataContext.Sizes.Add(new Size
            {
                Name = name,
                Price = price
            });
            await dataContext.SaveChangesAsync();
        }

        public async Task CheckSanitizationProtocol(string description)
        {
            this.dataContext.SanitizationProtocols.Add(new SanitizationProtocol
            {
                Description = description
            });
            await this.dataContext.SaveChangesAsync();
        }

        public async Task CheckTypeOfPayment(string description)
        {
            this.dataContext.TypeOfPayments.Add(new TypeOfPayment
            {
                Description = description
            });
            await this.dataContext.SaveChangesAsync();
        }

        public async Task CheckIvaType(string description, double interestRate)
        {
            this.dataContext.IvaTypes.Add(new IvaType
            {
                Description = description,
                InterestRate = interestRate
            });
            await this.dataContext.SaveChangesAsync();
        }
        ///
        public async Task CheckTypeOfWristband(string description, string colour, double price)
        {
            this.dataContext.TypeOfWristbands.Add(new TypeOfWristband
            {
                Description = description,
                Colour = colour,
                Price = price
            });
            await this.dataContext.SaveChangesAsync();
        }
        
        public async Task CheckCollarSize(string size, double price)
        {
            this.dataContext.CollarSizes.Add(new CollarSize
            {
                Size = size,
                Price = price
            });
            await this.dataContext.SaveChangesAsync();
        }

        public async Task CheckCashBox(string ip, Employee employee, Status status)
        {
            this.dataContext.CashBoxes.Add(new CashBox
            {
                Ip = ip,
                Employee = employee,
                Status = status
            });
            await this.dataContext.SaveChangesAsync();
        }
        
        public async Task CheckLocation(string place)
        {
            this.dataContext.Locations.Add(new Location
            {
                Place = place
            });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckReceivingMachines(Location location)
        {
            this.dataContext.ReceivingMachines.Add(new ReceivingMachine
            {
                Location = location
            });

            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckPrintingMachines(Location location)
        {
            this.dataContext.PrintingMachines.Add(new PrintingMachine
            {
                Location = location
            });

            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckPaymentMachines(Location location, Status status)
        {
            this.dataContext.PaymentMachines.Add(new PaymentMachine
            {
                Location = location,
                Status = status
            });

            await this.dataContext.SaveChangesAsync();
        }

        public async Task CheckSession(DateTime sessionDate, DateTime startTime, DateTime finishTime, Status status)
        {
            dataContext.Sessions.Add(new Session
            {
                SessionDate = sessionDate,
                StartTime = startTime,
                FinishTime = finishTime,
                Status = status
            });
            await dataContext.SaveChangesAsync();
        }

        public async Task CheckVrEquipment(string model, string brand, DateTime dateOfPurchase, Status status)
        {
            dataContext.VrEquipments.Add(new VrEquipment
            {
                Model = model, 
                Brand = brand,
                DateOfPurchase = dateOfPurchase,
                Status = status
            });
            await dataContext.SaveChangesAsync();
        }

        public async Task CheckTicketSale(CashBox cashBox, DateTime date, IvaType iva, Status status)
        {
            dataContext.TicketSales.Add(new TicketSale
            {
                CashBox = cashBox,
                DateOfIssue = date,
                IvaTypes = iva,
                Status = status
            });
            await dataContext.SaveChangesAsync();
        }

        public async Task CheckWrisbandSaleDetail(double quantity, string name, TypeOfWristband type, TicketSale sale, double unitPrice)
        {
            dataContext.WristbandsSaleDetail.Add(new WristbandSaleDetail
            {
                Quantity = quantity,
                NameOfPersonInCharge = name,
                TypeOfWristband = type,
                TicketSale = sale,
                UnitPrice = unitPrice
            });
            await dataContext.SaveChangesAsync();
        }
    }
}
