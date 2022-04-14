
namespace ParqueProcesoDesarrollo.Web.Controllers
{
    using ParqueProcesoDesarrollo.Web.Data;
    using ParqueProcesoDesarrollo.Web.Data.Entities;
    using ParqueProcesoDesarrollo.Web.Helpers;
    using ParqueProcesoDesarrollo.Web.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
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

        //public async Task<IActionResult> Index(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var providerContacts = (await this._context.ProviderContacts.Include(p => p.Provider).Where(pc => pc.Id == id).ToListAsync());

        //    return View(providerContacts);
        //}

        public async Task<IActionResult> Index2()
        {
            return View(await _context.ProviderContacts
                .Include(p => p.Provider)
                .ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var providerContact = await _context.ProviderContacts
                .FirstOrDefaultAsync(m => m.Id == id);

            if (providerContact == null)
            {
                return NotFound();
            }

            return View(providerContact);
        }


        public IActionResult Create()
        {
            var model = new ProviderContactViewModel
            {
                Providerses = this.combosHelper.GetComboProviders()
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

                    Provider = await _context.Providers.FindAsync(model.ProviderId)
                    //ProviderContacts = model.ProviderContacts

                };

                _context.Add(providercontact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index2));
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
                ProviderId = providercontact.Provider.Id,
                Providerses = this.combosHelper.GetComboProviders(),
               
                

                //
                //ProviderContacts = provider2.ProviderContacts


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

                    Provider = await _context.Providers.FindAsync(model.ProviderId)


                };

                _context.Update(providercontact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index2));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var providerContact = await _context.ProviderContacts
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
            var providerContact = await _context.ProviderContacts.FindAsync(id);
            _context.ProviderContacts.Remove(providerContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index2));
        }

        private bool CBrandExists(int id)
        {
            return _context.ProviderContacts.Any(e => e.Id == id);
        }
    }
}
