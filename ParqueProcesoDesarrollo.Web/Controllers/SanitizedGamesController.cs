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
    public class SanitizedGamesController : Controller
    {
        private readonly DataContext datacontext;
        private readonly ICombosHelper combosHelper;

        public SanitizedGamesController(DataContext context, ICombosHelper combosHelper)
        {
            this.datacontext = context;
            this.combosHelper = combosHelper;
        }

        // GET: SanitizedGames
        public async Task<IActionResult> Index()
        {
            return View(await datacontext.SanitizedGames
                .Include(p => p.User)
                .Include(x => x.SanitizationProtocol)
                .Include(y => y.Attraction)
                .ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanitizedGame = await datacontext.SanitizedGames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanitizedGame == null)
            {
                return NotFound();
            }

            return View(sanitizedGame);
        }

        //Get 
        public IActionResult Create()
        {
            var model = new SanitizedGamesViewModel
            {
                SanitizationDate = DateTime.Now,
                Users = this.combosHelper.GetUsers(),
                SanitizationProtocols = this.combosHelper.GetSanitizationProtocols(),
                Atractions = this.combosHelper.GetAttractions(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SanitizedGamesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var sanitizedGame = new SanitizedGame
                {
                    SanitizationDate = model.SanitizationDate,
                    Remarks = model.Remarks,
                    User = await this.datacontext.Users.FindAsync(model.UserId),
                    SanitizationProtocol = await this.datacontext.SanitizationProtocols.FindAsync(model.SanitizacionProtocolId),
                    Attraction = await this.datacontext.Attractions.FindAsync(model.AtraccionId)
                };

                datacontext.Add(sanitizedGame);
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

            var sanitizedGame = await datacontext.SanitizedGames
                .Include(u => u.User)
                .Include(t => t.SanitizationProtocol)
                .Include(a => a.Attraction)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (sanitizedGame == null)
            {
                return NotFound();
            }
            var model = new SanitizedGamesViewModel
            {
                SanitizationDate = sanitizedGame.SanitizationDate,
                Remarks = sanitizedGame.Remarks,

                User = sanitizedGame.User,
                UserId = sanitizedGame.User.Id,
                Users = this.combosHelper.GetUsers(),

                SanitizationProtocol = sanitizedGame.SanitizationProtocol,
                SanitizacionProtocolId = sanitizedGame.SanitizationProtocol.Id,
                SanitizationProtocols = this.combosHelper.GetSanitizationProtocols(),

                Attraction = sanitizedGame.Attraction,
                AtraccionId = sanitizedGame.Attraction.Id,
                Atractions = this.combosHelper.GetAttractions()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SanitizedGamesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var sanitizedGame = new SanitizedGame
                {
                    Id = model.Id,
                    SanitizationDate = model.SanitizationDate,
                    Remarks = model.Remarks,
                    User = await datacontext.Users.FindAsync(model.UserId),
                    SanitizationProtocol = await datacontext.SanitizationProtocols.FindAsync(model.SanitizacionProtocolId),
                    Attraction = await datacontext.Attractions.FindAsync(model.AtraccionId)
                };
                datacontext.Update(sanitizedGame);
                await datacontext.SaveChangesAsync();
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

            var sanitizedGame = await datacontext.SanitizedGames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanitizedGame == null)
            {
                return NotFound();
            }

            return View(sanitizedGame);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanitizedGame = await datacontext.SanitizedGames.FindAsync(id);
            datacontext.SanitizedGames.Remove(sanitizedGame);
            await datacontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanitizedGameExists(int id)
        {
            return datacontext.SanitizedGames.Any(e => e.Id == id);
        }
    }
}