using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParqueProcesoDesarrollo.Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollarSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollarSizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IvaTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterestRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IvaTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Place = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanitizationProtocols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanitizationProtocols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfMaintenances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfMaintenances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfWristbands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfWristbands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentalSurname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaternalSurname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    RFC = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    HiringDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrintingMachines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintingMachines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrintingMachines_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMachines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartCurrency5 = table.Column<int>(type: "int", nullable: false),
                    StartCurrency10 = table.Column<int>(type: "int", nullable: false),
                    StartBill50 = table.Column<int>(type: "int", nullable: false),
                    StartBill100 = table.Column<int>(type: "int", nullable: false),
                    CurrencyEntered5 = table.Column<int>(type: "int", nullable: false),
                    CurrencyEntered10 = table.Column<int>(type: "int", nullable: false),
                    BillEntered50 = table.Column<int>(type: "int", nullable: false),
                    BillEntered100 = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMachines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMachines_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentMachines_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialReason = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Providers_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionInterrupted = table.Column<bool>(type: "bit", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VrEquipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateOfPurchase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VrEquipments_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParkingTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfEntry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeOfEntry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeOfPayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    PrintingMachineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingTickets_PrintingMachines_PrintingMachineId",
                        column: x => x.PrintingMachineId,
                        principalTable: "PrintingMachines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParkingTickets_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MachineReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    PaymentMachineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineReports_PaymentMachines_PaymentMachineId",
                        column: x => x.PaymentMachineId,
                        principalTable: "PaymentMachines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProviderContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PaternalSurname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MaternalSurname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Post = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BusinessHours = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderContacts_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseHeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateofPayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: true),
                    TypeOfPaymentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseHeader_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseHeader_TypeOfPayments_TypeOfPaymentId",
                        column: x => x.TypeOfPaymentId,
                        principalTable: "TypeOfPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplies_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attractions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attractions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attractions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attractions_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashBoxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashBoxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashBoxes_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashBoxes_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParkingTicketPaymentMachines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMachineId = table.Column<int>(type: "int", nullable: true),
                    ParkingTicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingTicketPaymentMachines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingTicketPaymentMachines_ParkingTickets_ParkingTicketId",
                        column: x => x.ParkingTicketId,
                        principalTable: "ParkingTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParkingTicketPaymentMachines_PaymentMachines_PaymentMachineId",
                        column: x => x.PaymentMachineId,
                        principalTable: "PaymentMachines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReceivingMachines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    ParkingTicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingMachines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceivingMachines_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceivingMachines_ParkingTickets_ParkingTicketId",
                        column: x => x.ParkingTicketId,
                        principalTable: "ParkingTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsumableWarehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SupplyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumableWarehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumableWarehouses_Supplies_SupplyId",
                        column: x => x.SupplyId,
                        principalTable: "Supplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    SupplyId = table.Column<int>(type: "int", nullable: true),
                    PurchaseHeaderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseDetails_PurchaseHeader_PurchaseHeaderId",
                        column: x => x.PurchaseHeaderId,
                        principalTable: "PurchaseHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseDetails_Supplies_SupplyId",
                        column: x => x.SupplyId,
                        principalTable: "Supplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Maintenances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfLastOverhaul = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TypeOfMaintenanceId = table.Column<int>(type: "int", nullable: true),
                    AttractionId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenances_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Maintenances_Attractions_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Maintenances_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Maintenances_TypeOfMaintenances_TypeOfMaintenanceId",
                        column: x => x.TypeOfMaintenanceId,
                        principalTable: "TypeOfMaintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SanitizedGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Remarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AttractionId = table.Column<int>(type: "int", nullable: true),
                    SanitizationProtocolId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanitizedGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanitizedGames_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SanitizedGames_Attractions_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SanitizedGames_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SanitizedGames_SanitizationProtocols_SanitizationProtocolId",
                        column: x => x.SanitizationProtocolId,
                        principalTable: "SanitizationProtocols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketSales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Subtotal = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    CashBoxId = table.Column<int>(type: "int", nullable: true),
                    IvaTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketSales_CashBoxes_CashBoxId",
                        column: x => x.CashBoxId,
                        principalTable: "CashBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketSales_IvaTypes_IvaTypeId",
                        column: x => x.IvaTypeId,
                        principalTable: "IvaTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NecklaceSaleDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    FixedIpAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CollarSizeId = table.Column<int>(type: "int", nullable: true),
                    TicketSaleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NecklaceSaleDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NecklaceSaleDetails_CollarSizes_CollarSizeId",
                        column: x => x.CollarSizeId,
                        principalTable: "CollarSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NecklaceSaleDetails_TicketSales_TicketSaleId",
                        column: x => x.TicketSaleId,
                        principalTable: "TicketSales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WristbandsSaleDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    NameOfPersonInCharge = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeOfWristbandId = table.Column<int>(type: "int", nullable: true),
                    TicketSaleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WristbandsSaleDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WristbandsSaleDetail_TicketSales_TicketSaleId",
                        column: x => x.TicketSaleId,
                        principalTable: "TicketSales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WristbandsSaleDetail_TypeOfWristbands_TypeOfWristbandId",
                        column: x => x.TypeOfWristbandId,
                        principalTable: "TypeOfWristbands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpaRegistrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfCheckInTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfCheckOutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delivered = table.Column<bool>(type: "bit", nullable: false),
                    WristbandSaleDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaRegistrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpaRegistrations_WristbandsSaleDetail_WristbandSaleDetailId",
                        column: x => x.WristbandSaleDetailId,
                        principalTable: "WristbandsSaleDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VisitorSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WristbandSaleDetailId = table.Column<int>(type: "int", nullable: true),
                    VrEquipmentId = table.Column<int>(type: "int", nullable: true),
                    SessionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitorSessions_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VisitorSessions_VrEquipments_VrEquipmentId",
                        column: x => x.VrEquipmentId,
                        principalTable: "VrEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VisitorSessions_WristbandsSaleDetail_WristbandSaleDetailId",
                        column: x => x.WristbandSaleDetailId,
                        principalTable: "WristbandsSaleDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Attractions_EmployeeId",
                table: "Attractions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attractions_StatusId",
                table: "Attractions",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CashBoxes_EmployeeId",
                table: "CashBoxes",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CashBoxes_StatusId",
                table: "CashBoxes",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumableWarehouses_SupplyId",
                table: "ConsumableWarehouses",
                column: "SupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineReports_PaymentMachineId",
                table: "MachineReports",
                column: "PaymentMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_AttractionId",
                table: "Maintenances",
                column: "AttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_EmployeeId",
                table: "Maintenances",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_TypeOfMaintenanceId",
                table: "Maintenances",
                column: "TypeOfMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_UserId",
                table: "Maintenances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NecklaceSaleDetails_CollarSizeId",
                table: "NecklaceSaleDetails",
                column: "CollarSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_NecklaceSaleDetails_TicketSaleId",
                table: "NecklaceSaleDetails",
                column: "TicketSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingTicketPaymentMachines_ParkingTicketId",
                table: "ParkingTicketPaymentMachines",
                column: "ParkingTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingTicketPaymentMachines_PaymentMachineId",
                table: "ParkingTicketPaymentMachines",
                column: "PaymentMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingTickets_PrintingMachineId",
                table: "ParkingTickets",
                column: "PrintingMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingTickets_StatusId",
                table: "ParkingTickets",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMachines_LocationId",
                table: "PaymentMachines",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMachines_StatusId",
                table: "PaymentMachines",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PrintingMachines_LocationId",
                table: "PrintingMachines",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderContacts_ProviderId",
                table: "ProviderContacts",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_StatusId",
                table: "Providers",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_PurchaseHeaderId",
                table: "PurchaseDetails",
                column: "PurchaseHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_SupplyId",
                table: "PurchaseDetails",
                column: "SupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseHeader_ProviderId",
                table: "PurchaseHeader",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseHeader_TypeOfPaymentId",
                table: "PurchaseHeader",
                column: "TypeOfPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingMachines_LocationId",
                table: "ReceivingMachines",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingMachines_ParkingTicketId",
                table: "ReceivingMachines",
                column: "ParkingTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_SanitizedGames_AttractionId",
                table: "SanitizedGames",
                column: "AttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_SanitizedGames_EmployeeId",
                table: "SanitizedGames",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SanitizedGames_SanitizationProtocolId",
                table: "SanitizedGames",
                column: "SanitizationProtocolId");

            migrationBuilder.CreateIndex(
                name: "IX_SanitizedGames_UserId",
                table: "SanitizedGames",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_StatusId",
                table: "Sessions",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaRegistrations_WristbandSaleDetailId",
                table: "SpaRegistrations",
                column: "WristbandSaleDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_ProviderId",
                table: "Supplies",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketSales_CashBoxId",
                table: "TicketSales",
                column: "CashBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketSales_IvaTypeId",
                table: "TicketSales",
                column: "IvaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorSessions_SessionId",
                table: "VisitorSessions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorSessions_VrEquipmentId",
                table: "VisitorSessions",
                column: "VrEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorSessions_WristbandSaleDetailId",
                table: "VisitorSessions",
                column: "WristbandSaleDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_VrEquipments_StatusId",
                table: "VrEquipments",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WristbandsSaleDetail_TicketSaleId",
                table: "WristbandsSaleDetail",
                column: "TicketSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_WristbandsSaleDetail_TypeOfWristbandId",
                table: "WristbandsSaleDetail",
                column: "TypeOfWristbandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ConsumableWarehouses");

            migrationBuilder.DropTable(
                name: "MachineReports");

            migrationBuilder.DropTable(
                name: "Maintenances");

            migrationBuilder.DropTable(
                name: "NecklaceSaleDetails");

            migrationBuilder.DropTable(
                name: "ParkingTicketPaymentMachines");

            migrationBuilder.DropTable(
                name: "ProviderContacts");

            migrationBuilder.DropTable(
                name: "PurchaseDetails");

            migrationBuilder.DropTable(
                name: "ReceivingMachines");

            migrationBuilder.DropTable(
                name: "SanitizedGames");

            migrationBuilder.DropTable(
                name: "SpaRegistrations");

            migrationBuilder.DropTable(
                name: "VisitorSessions");

            migrationBuilder.DropTable(
                name: "TypeOfMaintenances");

            migrationBuilder.DropTable(
                name: "CollarSizes");

            migrationBuilder.DropTable(
                name: "PaymentMachines");

            migrationBuilder.DropTable(
                name: "PurchaseHeader");

            migrationBuilder.DropTable(
                name: "Supplies");

            migrationBuilder.DropTable(
                name: "ParkingTickets");

            migrationBuilder.DropTable(
                name: "Attractions");

            migrationBuilder.DropTable(
                name: "SanitizationProtocols");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "VrEquipments");

            migrationBuilder.DropTable(
                name: "WristbandsSaleDetail");

            migrationBuilder.DropTable(
                name: "TypeOfPayments");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "PrintingMachines");

            migrationBuilder.DropTable(
                name: "TicketSales");

            migrationBuilder.DropTable(
                name: "TypeOfWristbands");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "CashBoxes");

            migrationBuilder.DropTable(
                name: "IvaTypes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");
        }
    }
}
