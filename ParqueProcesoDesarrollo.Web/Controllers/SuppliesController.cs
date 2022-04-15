using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ParqueProcesoDesarrollo.Web.Data;
using ParqueProcesoDesarrollo.Web.Data.Entities;
using ParqueProcesoDesarrollo.Web.Helpers;
using ParqueProcesoDesarrollo.Web.Models;


namespace ParqueProcesoDesarrollo.Web.Controllers
{
    public class SuppliesController : Controller
    {
        private readonly DataContext dataContext;
        private readonly ICombosHelper combosHelper;

        public SuppliesController(DataContext context, ICombosHelper combosHelper)
        {
            this.combosHelper = combosHelper;
            dataContext = context;

        }
        public async Task<IActionResult> Index()
        {
            return View(await dataContext.Supplies.ToListAsync());
        }

        public IActionResult Create()
        {
            var model = new SupplyViewModel
            {
                Providers = this.combosHelper.GetComboProviders(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupplyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var supply = new Supply
                {
                    Barcode = model.Barcode,
                    UnitPrice = model.UnitPrice,
                    Description = model.Description,
                    Provider = await this.dataContext.Providers.FindAsync(model.ProviderId)
                };
                this.dataContext.Add(supply);
                await this.dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cSupply = await dataContext.Supplies.Include(p => p.Provider).FirstOrDefaultAsync(m => m.Id == id);
            if (cSupply == null)
            {
                return NotFound();
            }

            return View(cSupply);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supply = await this.dataContext.Supplies
                .Include(p=>p.Provider)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (supply == null)
            {
                return NotFound();
            }
            var model = new SupplyViewModel
            {
                Barcode=supply.Barcode,
                UnitPrice=supply.UnitPrice,
                Description=supply.Description,
                Provider=supply.Provider,
                ProviderId=supply.Provider.Id,
                Providers=this.combosHelper.GetComboProviders()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SupplyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var supply = new Supply
                {
                    Id=model.Id,
                    Barcode = model.Barcode,
                    UnitPrice = model.UnitPrice,
                    Description = model.Description,
                    Provider= await dataContext.Providers.FindAsync(model.ProviderId)
                };
                this.dataContext.Update(supply);
                await this.dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await dataContext.Supplies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            var model = new Supply
            {
                Id = product.Id,
                Barcode = product.Barcode,
                UnitPrice = product.UnitPrice,
                Description = product.Description
            };

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await this.dataContext.Supplies.FindAsync(id);
            dataContext.Supplies.Remove(product);
            await dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
