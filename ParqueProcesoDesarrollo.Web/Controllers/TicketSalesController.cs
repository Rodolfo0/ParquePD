namespace ParqueProcesoDesarrollo.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ParqueProcesoDesarrollo.Web.Data;
    using ParqueProcesoDesarrollo.Web.Data.Entities;
    using ParqueProcesoDesarrollo.Web.Helpers;
    using ParqueProcesoDesarrollo.Web.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class TicketSalesController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper combosHelper;


        public TicketSalesController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            this.combosHelper = combosHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TicketSales
                .Include(p => p.WristbandSaleDetails)
                .ThenInclude(o => o.TypeOfWristband)
                .Include(w => w.NecklaceSaleDetails)
                .ThenInclude(q => q.CollarSize)
                .Include(e => e.IvaTypes)
                .ToListAsync());
        }

        public async Task<IActionResult> CreateSale()
        {
            var model = new TicketSaleViewModel
            {
                NecklaceSaleDetailTemp = await this._context.NecklaceSaleDetailTemps.Include(nsd => nsd.CollarSize).ToListAsync(),
                WristbandSaleDetailTemp = await this._context.WristbandSaleDetailTemps.Include(wsb => wsb.TypeOfWristband).ToListAsync()
            };

            return View(model);
        }

        public IActionResult AddWristband()
        {
            var model = new TicketSaleViewModel
            {
                WristBandsQuantity = 1,
                Wristbands = this.combosHelper.GetComboWristband(),
                NameOfPersonInCharge = ""
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddWristband(TicketSaleViewModel model)
        {
            if (this.ModelState.IsValid)
            {

                var wristband = await this._context.TypeOfWristbands.FindAsync(model.WristbandId);

                if (wristband == null)
                {
                    return NotFound();
                }

                var WristbandSaleDetailTemp = await this._context.WristbandSaleDetailTemps.Where(odt =>
                 odt.TypeOfWristband == wristband).FirstOrDefaultAsync();

                if (WristbandSaleDetailTemp == null)
                {
                    WristbandSaleDetailTemp = new WristbandSaleDetailTemp
                    {
                        TypeOfWristband = wristband,
                        Quantity = model.WristBandsQuantity,
                        UnitPrice = wristband.Price,
                        NameOfPersonInCharge = model.NameOfPersonInCharge
                    };

                    this._context.WristbandSaleDetailTemps.Add(WristbandSaleDetailTemp);

                }
                else
                {
                    WristbandSaleDetailTemp.Quantity += model.WristBandsQuantity;
                    this._context.WristbandSaleDetailTemps.Update(WristbandSaleDetailTemp);
                }

                await this._context.SaveChangesAsync();

                return this.RedirectToAction("CreateSale");

            }
            return this.View(model);
        }

        public async Task<IActionResult> DeleteWristband(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wristbandSaleDetailTemp = await this._context.WristbandSaleDetailTemps.FindAsync(id);

            if (wristbandSaleDetailTemp == null)
            {
                return NotFound();
            }

            this._context.WristbandSaleDetailTemps.Remove(wristbandSaleDetailTemp);
            await this._context.SaveChangesAsync();
            return this.RedirectToAction("CreateSale");
        }

        public async Task<IActionResult> IncreaseWristband(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wristbandSaleDetailTemp = await this._context.WristbandSaleDetailTemps.FindAsync(id);

            if (wristbandSaleDetailTemp == null)
            {
                return NotFound();
            }
            wristbandSaleDetailTemp.Quantity += 1;
            this._context.WristbandSaleDetailTemps.Update(wristbandSaleDetailTemp);
            await this._context.SaveChangesAsync();
            return this.RedirectToAction("CreateSale");
        }

        public async Task<IActionResult> DecreaseWristband(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wristbandSaleDetailTemp = await this._context.WristbandSaleDetailTemps.FindAsync(id);

            if (wristbandSaleDetailTemp == null)
            {
                return NotFound();
            }
            wristbandSaleDetailTemp.Quantity -= 1;
            if (wristbandSaleDetailTemp.Quantity > 0)
            {
                this._context.WristbandSaleDetailTemps.Update(wristbandSaleDetailTemp);
                await this._context.SaveChangesAsync();
            }

            if (wristbandSaleDetailTemp.Quantity == 0)
            {
                this._context.WristbandSaleDetailTemps.Remove(wristbandSaleDetailTemp);
                await this._context.SaveChangesAsync();
            }
            return this.RedirectToAction("CreateSale");
        }

        public IActionResult AddNecklace()
        {
            var model = new TicketSaleViewModel
            {
                CollarQuantity = 1,
                CollarSizes = this.combosHelper.GetComboCollarSize()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNecklace(TicketSaleViewModel model)
        {
            if (this.ModelState.IsValid)
            {

                var collar = await this._context.CollarSizes.FindAsync(model.CollarSizeId);

                if (collar == null)
                {
                    return NotFound();
                }

                var collarSaleDetailTemp = await this._context.NecklaceSaleDetailTemps.Where(odt =>
                 odt.CollarSize == collar).FirstOrDefaultAsync();

                if (collarSaleDetailTemp == null)
                {
                    collarSaleDetailTemp = new NecklaceSaleDetailTemp
                    {
                        CollarSize = collar,
                        Quantity = model.CollarQuantity,
                        UnitPrice = collar.Price,
                        FixedIpAddress = "192.168.1.9"
                    };

                    this._context.NecklaceSaleDetailTemps.Add(collarSaleDetailTemp);

                }
                else
                {
                    collarSaleDetailTemp.Quantity += model.CollarQuantity;
                    this._context.NecklaceSaleDetailTemps.Update(collarSaleDetailTemp);
                }

                await this._context.SaveChangesAsync();

                return this.RedirectToAction("CreateSale");

            }
            return this.View(model);
        }

        public async Task<IActionResult> DeleteNecklace(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var necklaceSaleDetailTemp = await this._context.NecklaceSaleDetailTemps.FindAsync(id);

            if (necklaceSaleDetailTemp == null)
            {
                return NotFound();
            }

            this._context.NecklaceSaleDetailTemps.Remove(necklaceSaleDetailTemp);
            await this._context.SaveChangesAsync();
            return this.RedirectToAction("CreateSale");
        }

        public async Task<IActionResult> IncreaseNecklace(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var necklaceSaleDetailTemp = await this._context.NecklaceSaleDetailTemps.FindAsync(id);

            if (necklaceSaleDetailTemp == null)
            {
                return NotFound();
            }
            necklaceSaleDetailTemp.Quantity += 1;
            this._context.NecklaceSaleDetailTemps.Update(necklaceSaleDetailTemp);
            await this._context.SaveChangesAsync();
            return this.RedirectToAction("CreateSale");
        }

        public async Task<IActionResult> DecreaseNecklace(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var necklaceSaleDetailTemp = await this._context.NecklaceSaleDetailTemps.FindAsync(id);

            if (necklaceSaleDetailTemp == null)
            {
                return NotFound();
            }
            necklaceSaleDetailTemp.Quantity -= 1;
            if (necklaceSaleDetailTemp.Quantity > 0)
            {
                this._context.NecklaceSaleDetailTemps.Update(necklaceSaleDetailTemp);
                await this._context.SaveChangesAsync();
            }

            if (necklaceSaleDetailTemp.Quantity == 0)
            {
                this._context.NecklaceSaleDetailTemps.Remove(necklaceSaleDetailTemp);
                await this._context.SaveChangesAsync();
            }
            return this.RedirectToAction("CreateSale");
        }

        public async Task<IActionResult> ConfirmOrder()
        {
            var wristbandDetailTemp = await this._context.WristbandSaleDetailTemps
                .Include(odt => odt.TypeOfWristband)
                .ToListAsync();

            if (wristbandDetailTemp == null || wristbandDetailTemp.Count == 0)
            {
                return NotFound();
            }

            var wristBandsDetails = wristbandDetailTemp.Select(odt => new WristbandSaleDetail
            {
                UnitPrice = odt.UnitPrice,
                TypeOfWristband = odt.TypeOfWristband,
                Quantity = odt.Quantity,
                NameOfPersonInCharge = odt.NameOfPersonInCharge

            }).ToList();

            if (wristBandsDetails.FirstOrDefault(wbd => wbd.TypeOfWristband.Description == "Adulto") == null)
            {
                if (wristBandsDetails.FirstOrDefault(wbd => wbd.TypeOfWristband.Description == "Adulto VIP") == null)
                {
                    //Add Error Message
                    return this.RedirectToAction("CreateSale");
                }
            }

            var necklaceDetailTemp = await this._context.NecklaceSaleDetailTemps
                .Include(ndt => ndt.CollarSize)
                .ToListAsync();

            var ivaType = await this._context.IvaTypes.FirstOrDefaultAsync(it => it.InterestRate == 0.16);

            if (necklaceDetailTemp == null || necklaceDetailTemp.Count == 0)
            {
                var order = new TicketSale
                {

                    DateOfIssue = DateTime.UtcNow,
                    WristbandSaleDetails = wristBandsDetails,
                    IvaTypes = ivaType,
                    Status = await this._context.Statuses.FirstOrDefaultAsync(it => it.Name == "Emitida"),
                    CashBox = await this._context.CashBoxes.FirstOrDefaultAsync(it => it.Id == 1)

                };

                order.Total = order.Subtotal * ivaType.InterestRate + order.Subtotal;

                this._context.TicketSales.Add(order);
                this._context.WristbandSaleDetailTemps.RemoveRange(wristbandDetailTemp);
                await this._context.SaveChangesAsync();
                return this.RedirectToAction("Index");
            }
            else
            {

                var necklacesDetails = necklaceDetailTemp.Select(odt => new NecklaceSaleDetail
                {
                    UnitPrice = odt.UnitPrice,
                    CollarSize = odt.CollarSize,
                    Quantity = odt.Quantity,
                    FixedIpAddress = "192.168.1.2"

                }).ToList();

                var order = new TicketSale
                {

                    DateOfIssue = DateTime.UtcNow,
                    WristbandSaleDetails = wristBandsDetails,
                    NecklaceSaleDetails = necklacesDetails,
                    IvaTypes = await this._context.IvaTypes.FirstOrDefaultAsync(it => it.InterestRate == 0.16),
                    Status = await this._context.Statuses.FirstOrDefaultAsync(it => it.Name == "Emitida"),
                    CashBox = await this._context.CashBoxes.FirstOrDefaultAsync(it => it.Id == 1),

                };

                order.Total = order.Subtotal * ivaType.InterestRate + order.Subtotal;


                this._context.TicketSales.Add(order);
                this._context.WristbandSaleDetailTemps.RemoveRange(wristbandDetailTemp);
                this._context.NecklaceSaleDetailTemps.RemoveRange(necklaceDetailTemp);
                await this._context.SaveChangesAsync();
                return this.RedirectToAction("Index");

            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await this._context.TicketSales
                .Include(ts => ts.CashBox)
                .Include(ts => ts.IvaTypes)
                .Include(ts => ts.NecklaceSaleDetails)
                .ThenInclude(nsd => nsd.CollarSize)
                .Include(ts => ts.WristbandSaleDetails)
                .ThenInclude(nsd => nsd.TypeOfWristband)
                .FirstOrDefaultAsync(ts => ts.Id == id);

            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }
    }
}

