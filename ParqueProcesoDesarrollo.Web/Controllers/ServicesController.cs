﻿using Microsoft.AspNetCore.Mvc;
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
    public class ServicesController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper combosHelper;

        public ServicesController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            this.combosHelper = combosHelper;
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

        public async Task<IActionResult> IndexSpa()
        {
            return View(await _context.SpaRegistrations.ToListAsync());
        }

        public async Task<IActionResult> DetailsSpa(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regist = await _context.SpaRegistrations.Include(b => b.Size).FirstOrDefaultAsync(m => m.Id == id);
            if (regist == null)
            {
                return NotFound();
            }

            return View(regist);
        }

        //[HttpGet]
        //public async Task<IActionResult> EditSpa(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var regist = await _context.SpaRegistrations
        //        .Include(p => p.Size)
        //        .FirstOrDefaultAsync(p => p.Id == id);
        //    if (regist == null)
        //    {
        //        return NotFound();
        //    }
        //    var model = new addDogViewModel
        //    {
        //        Id = regist.Id,
        //        WristbandSaleDetail = regist.WristbandSaleDetail,
        //        DateOfCheckInTime = regist.DateOfCheckInTime,
        //        DateOfCheckOutTime = regist.DateOfCheckOutTime,
        //        idSize = regist.Size.Id,
        //        Size = regist.Size,
        //        sizes = combosHelper.GetSizes(),
        //        Delivered = regist.Delivered
        //    };
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditSpa(SpaRegistration model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new User
        //        {

        //        };
        //        var result = await userHelper.UpdateUserAsync(user);
        //        //var result = await UserManager.UpdateAsync(user);
        //        if (result != IdentityResult.Success)
        //        {
        //            throw new InvalidOperationException("No se ha podido añadir el usuario");
        //        }
        //        await userHelper.AddUserToRoleAsync(user, user.Role.Name);
        //        //await this.dataContext.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(model);
        //}

        public IActionResult CreateSpa()
        {
            var model = new addDogViewModel
            {
                Sizes = combosHelper.GetSizes(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(addDogViewModel model)
        {
            if (ModelState.IsValid)
            {
                var regist = await _context.SpaRegistrations.Include(b => b.Size).SingleOrDefaultAsync();
                    regist = new SpaRegistration
                {
                    Id = regist.Id,
                    WristbandSaleDetail = regist.WristbandSaleDetail,
                    DateOfCheckInTime = regist.DateOfCheckInTime,
                    DateOfCheckOutTime = regist.DateOfCheckOutTime,
                    Owner = regist.Owner,
                    Size = await _context.Sizes.FindAsync(model.idSize),
                    Delivered = regist.Delivered
                };
                return RedirectToAction(nameof(CreateSpa));
            }
            return View(model);
        }
    }
}
