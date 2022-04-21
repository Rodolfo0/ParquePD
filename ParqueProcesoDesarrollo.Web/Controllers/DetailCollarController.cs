using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParqueProcesoDesarrollo.Web.Data;
using ParqueProcesoDesarrollo.Web.Helpers;
using System.Threading.Tasks;

namespace ParqueProcesoDesarrollo.Web.Controllers
{
    public class DetailCollarController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper combosHelper;

        public DetailCollarController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            this.combosHelper = combosHelper;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.NecklaceSaleDetails
                .Include(p => p.CollarSize)
                .ThenInclude(o => o.Price)
                //.Include(w => w.)
                //.ThenInclude(q => q.CollarSize)
                //.Include(e => e.IvaType)
                .ToListAsync());
        }


    }
}
