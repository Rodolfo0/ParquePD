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

        // PurchaseDetail
        [HttpGet]
        //public IActionResult CreateDetail()
        //{
        //    var model = new PurchaseDetailViewModel
        //    {
        //        Supplies = this.combosHelper.GetComboSupplies(),

        //        PurchaseHeaders = this.combosHelper.GetComboPurchaseHeaders()
        //    };
        //    return View(model);
        //}

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
                return RedirectToAction(nameof(CreateDetail));
            }
            return View(model);
        }

        // PurchaseDetail
        [HttpPost]
        public async Task<IActionResult> CreateDetail(PurchaseDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var purchaseDetail = new PurchaseDetail
                {
                    Quantity = model.Quantity,
                    UnitPrice = model.UnitPrice,
                    Supply = await this.dataContext.Supplies.FindAsync(model.SupplyId),
                    PurchaseHeader = await this.dataContext.PurchaseHeader.FindAsync(model.PurchaseHeaderId)
                };
                this.dataContext.Add(purchaseDetail);
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

        // PurchaseDetail
        [HttpGet]
        //public async Task<IActionResult> EditDetail(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var purchaseDetail = await this.dataContext.PurchaseDetails
        //        .Include(pd => pd.Supply)
        //        .Include(pd => pd.PurchaseHeader)
        //        .FirstOrDefaultAsync(ph => ph.Id == id);

        //    if (purchaseDetail == null)
        //    {
        //        return NotFound();
        //    }
        //    var model = new PurchaseDetailViewModel
        //    {
        //        Id = purchaseDetail.Id,
        //        Quantity = purchaseDetail.Quantity,
        //        UnitPrice = purchaseDetail.UnitPrice,
        //        Supply = purchaseDetail.Supply,
        //        SupplyId = purchaseDetail.Supply.Id,
        //        Supplies = this.combosHelper.GetComboSupplies(),
        //        PurchaseHeader = purchaseDetail.PurchaseHeader,
        //        PurchaseHeaderId = purchaseDetail.PurchaseHeader.Id,
        //        PurchaseHeaders = this.combosHelper.GetComboPurchaseHeaders(),
        //    };
        //    return View(model);
        //}

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

        // PurchaseDetail
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDetail(PurchaseDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var purchaseDetail = new PurchaseDetail
                {
                    Quantity = model.Quantity,
                    UnitPrice = model.UnitPrice,
                    Supply = await this.dataContext.Supplies.FindAsync(model.SupplyId),
                    PurchaseHeader = await this.dataContext.PurchaseHeader.FindAsync(model.PurchaseHeaderId)
                };
                this.dataContext.Add(purchaseDetail);
                await this.dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // PurchaseDetail
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetail = await dataContext.PurchaseDetails
                .Include(pd => pd.Supply)
                .Include(pd => pd.PurchaseHeader)
                .FirstOrDefaultAsync(pd => pd.PurchaseHeader.Id == id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }

            return View(purchaseDetail);
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

        // PurchaseDetail
        public async Task<IActionResult> DeleteDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetail = await this.dataContext.PurchaseDetails
                .FirstOrDefaultAsync(pd => pd.Id == id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }

            return View(purchaseDetail);
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

        // PurchaseDetail
        [HttpPost, ActionName("DeleteDetail")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedDetail(int id)
        {
            var purchaseDetail = await dataContext.PurchaseDetails.FindAsync(id);
            dataContext.PurchaseDetails.Remove(purchaseDetail);
            await dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseHeader(int id)
        {
            return dataContext.PurchaseHeader.Any(ph => ph.Id == id);
        }

        // PurchaseDetail
        private bool PurchaseDetail(int id)
        {
            return dataContext.PurchaseDetails.Any(ph => ph.Id == id);
        }
    }
}