namespace ParqueProcesoDesarrollo.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using ParqueProcesoDesarrollo.Web.Data;
    using ParqueProcesoDesarrollo.Web.Data.Entities;
    using ParqueProcesoDesarrollo.Web.Helpers;
    using ParqueProcesoDesarrollo.Web.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public class PurchaseHeadersController : Controller
    {
        private readonly DataContext dataContext;
        private readonly ICombosHelper combosHelper;

        public PurchaseHeadersController(DataContext dataContext, ICombosHelper combosHelper)
        {
            this.dataContext = dataContext;
            this.combosHelper = combosHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.dataContext.PurchaseHeader
                .Include(ph => ph.Provider)
                .Include(ph => ph.TypeOfPayment)
                .ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new PurchaseHeaderViewModel
            {
                Providers = this.combosHelper.GetComboProviders(),

                TypeOfPayments = this.combosHelper.GetComboTypeOfPayments()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PurchaseHeaderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var purchaseHeader = new PurchaseHeader
                {
                    IssueDate = model.IssueDate,
                    DateofPayment = model.DateofPayment,
                    Provider = await this.dataContext.Providers.FindAsync(model.ProviderId),
                    TypeOfPayment = await this.dataContext.TypeOfPayments.FindAsync(model.TypeOfPaymentId)
                };
                this.dataContext.Add(purchaseHeader);
                await this.dataContext.SaveChangesAsync();
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

            var purchaseHeader = await this.dataContext.PurchaseHeader
                .Include(ph => ph.Provider)
                .Include(ph => ph.TypeOfPayment)
                .FirstOrDefaultAsync(ph => ph.Id == id);

            if (purchaseHeader == null)
            {
                return NotFound();
            }
            var model = new PurchaseHeaderViewModel
            {
                Id = purchaseHeader.Id,
                IssueDate = purchaseHeader.IssueDate,
                DateofPayment = purchaseHeader.DateofPayment,
                Provider = purchaseHeader.Provider,
                ProviderId = purchaseHeader.Provider.Id,
                Providers = this.combosHelper.GetComboProviders(),
                TypeOfPayment = purchaseHeader.TypeOfPayment,
                TypeOfPaymentId = purchaseHeader.TypeOfPayment.Id,
                TypeOfPayments = this.combosHelper.GetComboTypeOfPayments(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PurchaseHeaderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var purchaseHeader = new PurchaseHeader
                {
                    Id = model.Id,
                    IssueDate = model.IssueDate,
                    DateofPayment = model.DateofPayment,
                    Provider = await this.dataContext.Providers.FindAsync(model.ProviderId),
                    TypeOfPayment = await this.dataContext.TypeOfPayments.FindAsync(model.TypeOfPaymentId)
                };
                this.dataContext.Update(purchaseHeader);
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

            var purchaseHeader = await this.dataContext.PurchaseHeader
                .FirstOrDefaultAsync(ph => ph.Id == id);
            if (purchaseHeader == null)
            {
                return NotFound();
            }

            return View(purchaseHeader);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseHeader = await dataContext.PurchaseHeader.FindAsync(id);
            dataContext.PurchaseHeader.Remove(purchaseHeader);
            await dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProviderExists(int id)
        {
            return dataContext.PurchaseHeader.Any(ph => ph.Id == id);
        }
    }
}
