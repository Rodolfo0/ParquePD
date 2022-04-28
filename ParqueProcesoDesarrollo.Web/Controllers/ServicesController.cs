using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParqueProcesoDesarrollo.Web.Data;
using ParqueProcesoDesarrollo.Web.Data.Entities;
using ParqueProcesoDesarrollo.Web.Helpers;
using ParqueProcesoDesarrollo.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace ParqueProcesoDesarrollo.Web.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper combosHelper;

        public ServicesController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            this.combosHelper = combosHelper;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Kits antipandemia ------------------------------------------
        public async Task<IActionResult> IndexKits()
        {
            return View(await _context.Kits.ToListAsync());
        }

        // GET: Kits/Details/5
        public async Task<IActionResult> DetailsKits(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kit = await _context.Kits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kit == null)
            {
                return NotFound();
            }

            return View(kit);
        }

        // GET: Kits/Create
        public IActionResult CreateKits()
        {
            var model = new Kit
            {
                UnitPrice = 30,
                DateOfSale = DateTime.Now,
            };
            return View(model);
        }

        //Create Kits
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateKits([Bind("Id,DateOfSale,Quantity,UnitPrice")] Kit kit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CreateKits));
            }
            return View(kit);
        }

        public async Task<IActionResult> DeleteKits(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kit = await _context.Kits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kit == null)
            {
                return NotFound();
            }

            return View(kit);
        }

        // POST: Kits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedKits(int id)
        {
            var kit = await _context.Kits.FindAsync(id);
            _context.Kits.Remove(kit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexKits));
        }

        private bool KitExists(int id)
        {
            return _context.Kits.Any(e => e.Id == id);
        }
        //------------------------------------------------------------
        //Registros Spa

        public async Task<IActionResult> IndexSpa()
        {
            return View(await _context.SpaRegistrations
                .Include(w => w.WristbandSaleDetail)
                .Include(s => s.Size)
                .ToListAsync());
        }

        public async Task<IActionResult> DetailsSpa(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regist = await _context.SpaRegistrations
                .Include(s => s.Size)
                .Include(w => w.WristbandSaleDetail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regist == null)
            {
                return NotFound();
            }

            return View(regist);
        }

        [HttpGet]
        public async Task<IActionResult> DeliveredSpa(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regist = await _context.SpaRegistrations
                .FirstOrDefaultAsync(p => p.Id == id);

            if (regist == null)
            {
                return NotFound();
            }
            var spa = new SpaRegistration
            {
                Id = regist.Id,
                DateOfCheckInTime = regist.DateOfCheckInTime,
                DateOfCheckOutTime = regist.DateOfCheckOutTime,
                Delivered = regist.Delivered,
                Size = regist.Size,
                Owner = regist.Owner,
                WristbandSaleDetail = regist.WristbandSaleDetail
            };
            return View(spa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeliveredSpa(SpaRegistration regist)
        {
            if (ModelState.IsValid)
            {
                var spa = new SpaRegistration
                {
                    Id = regist.Id,
                    DateOfCheckInTime = regist.DateOfCheckInTime,
                    DateOfCheckOutTime = DateTime.Now,
                    Delivered = regist.Delivered,
                    Size = regist.Size,
                    Owner = regist.Owner,
                    WristbandSaleDetail = regist.WristbandSaleDetail
                };


                _context.Update(spa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexSpa));
            }
            return View(regist);
        }

        public IActionResult CreateSpa()
        {
            var model = new addDogViewModel
            {
                Sizes = combosHelper.GetSizes(),
                Wristbands = combosHelper.GetVisitors(),
                DateOfCheckInTime = DateTime.Now,
                DateOfCheckOutTime = DateTime.MinValue,
                Delivered = false,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSpa(addDogViewModel model)
        {

            if (ModelState.IsValid)
            {
                var spa = new SpaRegistration
                {
                    Id = model.Id,
                    WristbandSaleDetail = await _context.WristbandsSaleDetail.FindAsync(model.IdClient),
                    DateOfCheckInTime = model.DateOfCheckInTime,
                    DateOfCheckOutTime = model.DateOfCheckOutTime,
                    Delivered = model.Delivered,
                    Owner = model.Owner,
                    Size = await _context.Sizes.FindAsync(model.idSize),
                };
                _context.Add(spa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CreateSpa));
            }
            return View(model);
        }
    }
}
