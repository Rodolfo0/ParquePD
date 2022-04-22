

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

        public IActionResult CreateWristband()
        {
            var model = this._context.WristbandSaleDetailTemps
                .Include(o => o.TypeOfWristband);
                

            return View(model);
        }

        public IActionResult addWristband()
        {
            var model = new AddItemViewModel
            {
                Quantity = 1,
                TypeOfWristband = this.combosHelper.GetComboWristband(),
                NameOfPersonInCharge = ""
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> addWristband(AddItemViewModel model)
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
                    WristbandSaleDetailTemp = new Data.Entities.WristbandSaleDetailTemp
                    {
                        TypeOfWristband = wristband,
                        Quantity = model.Quantity,
                        UnitPrice = wristband.Price,
                        NameOfPersonInCharge = model.NameOfPersonInCharge
                    };
                    this._context.WristbandSaleDetailTemps.Add(WristbandSaleDetailTemp);

                }
                else
                {
                    WristbandSaleDetailTemp.Quantity += model.Quantity;
                    this._context.WristbandSaleDetailTemps.Update(WristbandSaleDetailTemp);
                }

                await this._context.SaveChangesAsync();

                return this.RedirectToAction("CreateWristband");

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
            return this.RedirectToAction("CreateWristband");
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
            return this.RedirectToAction("CreateWristband");
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
            return this.RedirectToAction("CreateWristband");
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

            var details = wristbandDetailTemp.Select(odt => new WristbandSaleDetail
            {
                UnitPrice = odt.UnitPrice,
                TypeOfWristband = odt.TypeOfWristband,
                Quantity = odt.Quantity,
                NameOfPersonInCharge = odt.NameOfPersonInCharge

            }).ToList();

            var order = new TicketSale
            {
                DateOfIssue = DateTime.UtcNow,
                WristbandSaleDetails = details
            };

            this._context.TicketSales.Add(order);
            this._context.WristbandSaleDetailTemps.RemoveRange(wristbandDetailTemp);
            await this._context.SaveChangesAsync();
            return this.RedirectToAction("Index");

        }
    }
}

//    return View(model);
//}

//[Authorize(Roles = "Admin")]
//public async Task<IActionResult> Delete(int? id)
//{
//    var user = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
//    if (user == null)
//    {
//        return NotFound();
//    }

//    if (id == null)
//    {
//        return NotFound();
//    }

//    var order = await datacontext.Orders.Where(u => u.User == user)

//        .FirstOrDefaultAsync(m => m.Id == id);
//    if (order == null)
//    {
//        return NotFound();
//    }

//    return View(order);
//}

//[HttpPost, ActionName("Delete")]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> DeleteConfirmed(int id)
//{
//    var order = await datacontext.Orders.FindAsync(id);
//    datacontext.Orders.Remove(order);
//    await datacontext.SaveChangesAsync();
//    return RedirectToAction(nameof(Index));
//}
//private bool OrderExists(int id)
//{
//    return datacontext.Orders.Any(e => e.Id == id);
//}
