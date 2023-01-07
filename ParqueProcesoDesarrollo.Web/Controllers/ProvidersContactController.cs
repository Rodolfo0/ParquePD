
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

    public class ProvidersContactController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper combosHelper;


        public ProvidersContactController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            this.combosHelper = combosHelper;
        }

        public IActionResult Index()
        {
            return View(this._context.ProviderContacts
                .Include(pc => pc.Provider)
                .Include(pc => pc.Status)
                .ToList());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var providerContact = await _context.ProviderContacts
                .Include(pc=>pc.Status)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (providerContact == null)
            {
                return NotFound();
            }

            return View(providerContact);
        }


        public IActionResult Create(int? providerId)
        {
            if (providerId == null)
            {
                return NotFound();
            }

            var model = new ProviderContactViewModel
            {
                ProviderId = providerId.Value,
                Statuses = this.combosHelper.GetComboUserStatus()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProviderContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var providercontact = new ProviderContact
                {
                    Name = model.Name,
                    PaternalSurname = model.PaternalSurname,
                    MaternalSurname = model.MaternalSurname,
                    Email = model.Email,
                    Phone = model.Phone,
                    Post = model.Post,
                    BusinessHours = model.BusinessHours,
                    Status = await _context.Statuses.FirstOrDefaultAsync(s => s.Name == "Activo"),
                    Provider = await _context.Providers.FindAsync(model.ProviderId)

                };

                _context.Add(providercontact);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Providers", new { id = model.ProviderId });
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

            var providercontact = await _context.ProviderContacts
                .Include(p => p.Provider)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (providercontact == null)
            {
                return NotFound();
            }

            var model = new ProviderContactViewModel
            {
                Name = providercontact.Name,
                PaternalSurname = providercontact.PaternalSurname,
                MaternalSurname = providercontact.MaternalSurname,
                Email = providercontact.Email,
                Phone = providercontact.Phone,
                Post = providercontact.Post,
                BusinessHours = providercontact.BusinessHours,
                Provider = await this._context.Providers.FindAsync(providercontact.Provider.Id),
                Status = await this._context.Statuses.FindAsync(providercontact.Status.Id),
                ProviderId = providercontact.Provider.Id,
                StatusId = providercontact.Status.Id,
                Statuses = this.combosHelper.GetComboUserStatus()

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProviderContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var providercontact = new ProviderContact
                {
                    Id = model.Id,
                    Name = model.Name,
                    PaternalSurname = model.PaternalSurname,
                    MaternalSurname = model.MaternalSurname,
                    Email = model.Email,
                    Phone = model.Phone,
                    Post = model.Post,
                    BusinessHours = model.BusinessHours,
                    Status = await _context.Statuses.FindAsync(model.StatusId),
                    Provider = await _context.Providers.FindAsync(model.ProviderId)
                };

                _context.Update(providercontact);
                await _context.SaveChangesAsync();
                
                return RedirectToAction("Details", "Providers", new { id = model.ProviderId });
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var providerContact = await _context
                .ProviderContacts
                .Include(pc => pc.Provider)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (providerContact == null)
            {
                return NotFound();
            }

            return View(providerContact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var providerContact = await _context.ProviderContacts.Include(pc=>pc.Provider).FirstOrDefaultAsync(pc=>pc.Id==id);
            var status = await this._context.Statuses.FirstOrDefaultAsync(s => s.Name == "Inactivo");
            providerContact.Status = status;
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Providers", new { id = providerContact.Provider.Id });
        }
    }
}
