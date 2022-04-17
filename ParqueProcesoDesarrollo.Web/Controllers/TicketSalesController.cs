namespace ParqueProcesoDesarrollo.Web.Controllers
{
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
                .Include(e => e.IvaType)
                .ToListAsync());
        }

        public IActionResult Create()
        {
            var model = new TicketSalesViewModel
            {
                //TypeOfWristband = this.combosHelper.GetComboWristband(),
                //TypeOfCollars = this.combosHelper.GetComboCollarSize()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TicketSalesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ticketSale = new TicketSale
                {
                    //Ticket = await _context.TicketSales.FindAsync(model.StatusId),

                    //SocialReason = model.SocialReason,
                    //RFC = model.RFC,
                    //Address = model.Address,
                    //Email = model.Email,
                    //Phone = model.Phone,
                    //Status = await _context.Statuses.FindAsync(model.StatusId)
                    //ProviderContacts = model.ProviderContacts

                };

                _context.Add(ticketSale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var provider = await _context.Providers
        //        .Include(p => p.Status)

        //        .FirstOrDefaultAsync(p => p.Id == id);

        //    if (provider == null)
        //    {
        //        return NotFound();
        //    }

        //    var model = new ProviderViewModel
        //    {
        //        SocialReason = provider.SocialReason,
        //        RFC = provider.RFC,
        //        Address = provider.Address,
        //        Email = provider.Email,
        //        Phone = provider.Phone,
        //        Status = provider.Status,
        //        StatusId = provider.Status.Id,
        //        Statuses = this.combosHelper.GetComboStatus(),

        //        //
        //        //ProviderContacts = provider2.ProviderContacts


        //    };
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(ProviderViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var provider = new Provider
        //        {
        //            Id = model.Id,
        //            SocialReason = model.SocialReason,
        //            RFC = model.RFC,
        //            Address = model.Address,
        //            Email = model.Email,
        //            Phone = model.Phone,
        //            Status = await _context.Statuses.FindAsync(model.StatusId)


        //        };

        //        _context.Update(provider);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(model);
        //}

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var provider = await _context.Providers
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (provider == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(provider);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var provider = await _context.Providers.FindAsync(id);
        //    _context.Providers.Remove(provider);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ProviderExists(int id)
        //{
        //    return _context.Providers.Any(e => e.Id == id);
        //}
    }
}