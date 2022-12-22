

namespace ParqueProcesoDesarrollo.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ParqueProcesoDesarrollo.Web.Data;
    using ParqueProcesoDesarrollo.Web.Data.Entities;
    using ParqueProcesoDesarrollo.Web.Helpers;
    using ParqueProcesoDesarrollo.Web.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProvidersController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper combosHelper;


        public ProvidersController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            this.combosHelper = combosHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Providers
                .Include(p => p.Status)
                .ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provider = await _context.Providers
                .Include(p => p.ProviderContacts)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (provider == null)
            {
                return NotFound();
            }

            return View(provider);
        }

        public IActionResult Create()
        {
            var model = new ProviderViewModel
            {
                Statuses = this.combosHelper.GetComboStatus()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProviderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var provider = new Provider
                {
                    SocialReason = model.SocialReason,
                    RFC = model.RFC,
                    Address = model.Address,
                    Email = model.Email,
                    Phone = model.Phone,
                    Status = await _context.Statuses.FindAsync(model.StatusId)
                    //ProviderContacts = model.ProviderContacts

                };

                _context.Add(provider);
                await _context.SaveChangesAsync();
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

            var provider = await _context.Providers
                .Include(p => p.Status)

                .FirstOrDefaultAsync(p => p.Id == id);

            if (provider == null)
            {
                return NotFound();
            }

            var model = new ProviderViewModel
            {
                SocialReason = provider.SocialReason,
                RFC = provider.RFC,
                Address = provider.Address,
                Email = provider.Email,
                Phone = provider.Phone,
                Status = provider.Status,
                StatusId = provider.Status.Id,
                Statuses = this.combosHelper.GetComboStatus(),

                //
                //ProviderContacts = provider2.ProviderContacts


            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProviderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var provider = new Provider
                {
                    Id = model.Id,
                    SocialReason = model.SocialReason,
                    RFC = model.RFC,
                    Address = model.Address,
                    Email = model.Email,
                    Phone = model.Phone,
                    Status = await _context.Statuses.FindAsync(model.StatusId)


                };

                _context.Update(provider);
                await _context.SaveChangesAsync();
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

            var provider = await _context.Providers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provider == null)
            {
                return NotFound();
            }

            return View(provider);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var provider = await _context.Providers.FindAsync(id);
            _context.Providers.Remove(provider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProviderExists(int id)
        {
            return _context.Providers.Any(e => e.Id == id);
        }
    }
}
