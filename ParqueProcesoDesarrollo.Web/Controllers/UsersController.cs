using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParqueProcesoDesarrollo.Web.Data;
using ParqueProcesoDesarrollo.Web.Data.Entities;
using ParqueProcesoDesarrollo.Web.Helpers;
using ParqueProcesoDesarrollo.Web.Models;
using System;
using System.Threading.Tasks;


namespace ParqueProcesoDesarrollo.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly DataContext dataContext;
        private readonly IUserHelper userHelper;
        private readonly ICombosHelper combosHelper;
        private readonly IImageHelper imageHelper;

        public UsersController(DataContext context, IUserHelper userHelper, ICombosHelper combosHelper, IImageHelper imageHelper)
        {
            this.userHelper = userHelper;
            this.combosHelper = combosHelper;
            dataContext = context;
            this.imageHelper = imageHelper;

        }

        public async Task<IActionResult> Index()
        {
            return View(await dataContext.Users.Include(u => u.Role).ToListAsync());
        }

        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cUser = await dataContext.Users.Include(u => u.Role).FirstOrDefaultAsync(m => m.Id == id);
            if (cUser == null)
            {
                return NotFound();
            }

            return View(cUser);
        }


        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cUser = await dataContext.Users.Include(u => u.Role).FirstOrDefaultAsync(m => m.Id == id);
            if (cUser == null)
            {
                return NotFound();
            }
            var model = new updateUserViewModel
            {
                FirstName = cUser.FirstName,
                ParentalSurname = cUser.ParentalSurname,
                MaternalSurname = cUser.MaternalSurname,
                PhoneNumber = cUser.PhoneNumber,
                RFC = cUser.RFC,
                Email = cUser.Email,
                UserName = cUser.Email,
                HiringDate = cUser.HiringDate,
                Salary = cUser.Salary,
                ImageUrl = cUser.ImageUrl,
                idRole = cUser.Role.Id,
                Role = cUser.Role,
                roles = this.combosHelper.GetComboRoles()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(updateUserViewModel model)
        {
            if (ModelState.IsValid)
            {

                var cUser = await dataContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == model.Id);

                cUser.FirstName = model.FirstName;
                cUser.ParentalSurname = model.ParentalSurname;
                cUser.MaternalSurname = model.MaternalSurname;
                cUser.PhoneNumber = model.PhoneNumber;
                cUser.RFC = model.RFC;
                cUser.Email = model.Email;
                cUser.UserName = model.Email;
                cUser.HiringDate = model.HiringDate;
                cUser.Salary = model.Salary;
                cUser.ImageUrl = (model.ImageFile != null ? await imageHelper.UploadImageAsync(model.ImageFile, model.FirstName, "users") : model.ImageUrl);
                cUser.Role = await this.dataContext.Roles.FindAsync(model.idRole);

                var result = await userHelper.UpdateUserAsync(cUser);
                //var result = await UserManager.UpdateAsync(user);
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("No se ha podido añadir el usuario");
                }
                //await this.dataContext.SaveChangesAsync();
                await userHelper.AddUserToRoleAsync(cUser, cUser.Role.Name);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new addUserViewModel
            {
                roles = this.combosHelper.GetComboRoles()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(addUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userHelper.GetUserByIdAsync(model.Id);
                user ??= new User
                {
                    FirstName = model.FirstName,
                    ParentalSurname = model.ParentalSurname,
                    MaternalSurname = model.MaternalSurname,
                    PhoneNumber = model.PhoneNumber,
                    RFC = model.RFC,
                    Email = model.Email,
                    UserName = model.Email,
                    HiringDate = model.HiringDate,
                    Salary = model.Salary,
                    ImageUrl = model.ImageFile != null ? await imageHelper.UploadImageAsync(
                        model.ImageFile, model.FirstName, "users") : string.Empty,
                    Role = await this.dataContext.Roles.FindAsync(model.idRole)
                };
                var result = await userHelper.AddUserAsync(user, model.Pass);
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("No se ha podido añadir el usuario");
                }
                await userHelper.AddUserToRoleAsync(user, user.Role.Name);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cUser = await dataContext.Users
                .Include(b => b.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
            if (cUser == null)
            {
                return NotFound();
            }

            return View(cUser);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cUser = await this.dataContext.Users.FindAsync(id);
            dataContext.Users.Remove(cUser);
            await dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
