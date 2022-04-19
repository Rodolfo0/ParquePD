using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParqueProcesoDesarrollo.Web.Data;
using ParqueProcesoDesarrollo.Web.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace ParqueProcesoDesarrollo.Web.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DataContext _context;

        public ServicesController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Kits antipandemia ------------------------------------------
        public async Task<IActionResult> IndexKits()
        {
            return View(await _context.Kits.ToListAsync());
        }

        // GET: Kits/Details/5
        public async Task<IActionResult> DetailsKits(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kit = await _context.Kits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kit == null)
            {
                return NotFound();
            }

            return View(kit);
        }

        // GET: Kits/Create
        public IActionResult CreateKits()
        {
            var model = new Kit
            {
                UnitPrice = 30,
                DateOfSale = DateTime.Now,
            };
            return View(model);
        }

        //Create Kits
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateKits([Bind("Id,DateOfSale,Quantity,UnitPrice")] Kit kit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CreateKits));
            }
            return View(kit);
        }

        public async Task<IActionResult> DeleteKits(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kit = await _context.Kits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kit == null)
            {
                return NotFound();
            }

            return View(kit);
        }

        // POST: Kits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedKits(int id)
        {
            var kit = await _context.Kits.FindAsync(id);
            _context.Kits.Remove(kit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexKits));
        }

        private bool KitExists(int id)
        {
            return _context.Kits.Any(e => e.Id == id);
        }
        //------------------------------------------------------------
        //Registros Spa
    }
}
