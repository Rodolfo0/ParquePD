using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParqueProcesoDesarrollo.Web.Data;
using ParqueProcesoDesarrollo.Web.Data.Entities;
using ParqueProcesoDesarrollo.Web.Helpers;
using ParqueProcesoDesarrollo.Web.Models;

namespace ParqueProcesoDesarrollo.Web.Controllers
{
    public class MaintenancesController : Controller
    {
        private readonly DataContext datacontext;
        private readonly ICombosHelper combosHelper;

        public MaintenancesController(DataContext context, ICombosHelper combosHelper)
        {
            this.datacontext = context;
            this.combosHelper = combosHelper;
        }

        // GET: Maintenances
        public async Task<IActionResult> Index()
        {
            return View(await datacontext.Maintenances
                .Include(p => p.User)
                .Include(x => x.TypeOfMaintenance)
                .Include(y => y.Attraction)
                .ToListAsync());
        }

        // GET: Maintenances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenance = await datacontext.Maintenances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maintenance == null)
            {
                return NotFound();
            }

            return View(maintenance);
        }

        // GET: Maintenances/Create
        public IActionResult Create()
        {
            var model = new MaintenanceViewModel
            {
                Users = this.combosHelper.GetUsers(),
                TPMaintenances = this.combosHelper.GetTPMaintenaces(),
                Atractions = this.combosHelper.GetAttractions()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MaintenanceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var maintenance = new Maintenance
                {
                    MaintenanceDate = model.MaintenanceDate,
                    DateOfLastOverhaul = model.DateOfLastOverhaul,
                    Remarks = model.Remarks,
                    User = await this.datacontext.Users.FindAsync(model.UserId),
                    TypeOfMaintenance = await this.datacontext.TypeOfMaintenances.FindAsync(model.MaintenanceId),
                    Attraction = await this.datacontext.Attractions.FindAsync(model.AtraccionId)
                };

                datacontext.Add(maintenance);
                await datacontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenance = await datacontext.Maintenances
                .Include(p => p.User)
                .Include(p => p.TypeOfMaintenance)
                .Include(p => p.Attraction)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (maintenance == null)
            {
                return NotFound();
            }
            var model = new MaintenanceViewModel
            {
                MaintenanceDate = maintenance.MaintenanceDate,
                DateOfLastOverhaul = maintenance.DateOfLastOverhaul,
                Remarks = maintenance.Remarks,
                User = maintenance.User,
                //UserId=maintenance.User.Id,
                Users = this.combosHelper.GetComboRoles(),
                TypeOfMaintenance = maintenance.TypeOfMaintenance,
                //MaintenanceId=maintenance.TypeOfMaintenance.Id,
                TPMaintenances = this.combosHelper.GetTPMaintenaces(),
                Attraction = maintenance.Attraction,
                AtraccionId = maintenance.Attraction.Id,
                Atractions = this.combosHelper.GetAttractions()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MaintenanceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var maintenance = new Maintenance
                {
                    Id = model.Id,
                    MaintenanceDate = model.MaintenanceDate,
                    DateOfLastOverhaul = model.DateOfLastOverhaul,
                    Remarks = model.Remarks,
                    User = await datacontext.Users.FindAsync(model.UserId),
                    TypeOfMaintenance = await datacontext.TypeOfMaintenances.FindAsync(model.MaintenanceId),
                    Attraction = await datacontext.Attractions.FindAsync(model.AtraccionId)
                };
                datacontext.Update(maintenance);
                await datacontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Maintenances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenance = await datacontext.Maintenances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maintenance == null)
            {
                return NotFound();
            }

            return View(maintenance);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maintenance = await datacontext.Maintenances.FindAsync(id);
            datacontext.Maintenances.Remove(maintenance);
            await datacontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaintenanceExists(int id)
        {
            return datacontext.Maintenances.Any(e => e.Id == id);
        }
    }
}