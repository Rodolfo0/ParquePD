using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParqueProcesoDesarrollo.Web.Data;
using ParqueProcesoDesarrollo.Web.Data.Entities;
using ParqueProcesoDesarrollo.Web.Helpers;
using ParqueProcesoDesarrollo.Web.Models;


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
            return View(await dataContext.Users.ToListAsync());
        }

        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cUser = await dataContext.Users.Include(b => b.Role).FirstOrDefaultAsync(m => m.Id == id);
            if (cUser == null)
            {
                return NotFound();
            }

            return View(cUser);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await this.dataContext.Users
                .Include(p => p.Role)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            var model = new addUserViewModel
            {
                FirstName = user.FirstName,
                ParentalSurname = user.ParentalSurname,
                MaternalSurname = user.MaternalSurname,
                PhoneNumber = user.PhoneNumber,
                RFC = user.RFC,
                Email = user.Email,
                UserName = user.Email,
                HiringDate = user.HiringDate,
                Salary = user.Salary,
                ImageUrl = user.ImageUrl,
                idRole = user.Role.Id,
                Role = user.Role,
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
                var user = new User
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
                    
                    ImageUrl = (model.ImageFile != null ? await imageHelper.UploadImageAsync(
                    model.ImageFile, model.FirstName, "users") : model.ImageUrl),
                    Role = await this.dataContext.Roles.FindAsync(model.idRole)
                };
                var result = await userHelper.UpdateUserAsync(user);
                //var result = await UserManager.UpdateAsync(user);
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("No se ha podido añadir el usuario");
                }
                await userHelper.AddUserToRoleAsync(user, user.Role.Name);
                //await this.dataContext.SaveChangesAsync();
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
                if (user == null)
                {
                    user = new User
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
                        ImageUrl = (model.ImageFile != null ? await imageHelper.UploadImageAsync(
                        model.ImageFile, model.FirstName, "users") : string.Empty),
                        Role = await this.dataContext.Roles.FindAsync(model.idRole)
                    };
                }
                var result = await userHelper.AddUserAsync(user, model.Pass);
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("No se ha podido añadir el usuario");
                }
                await userHelper.AddUserToRoleAsync(user, user.Role.Name);
                /*
                var manager = new User
                {
                    Id = model.Id,
                    User = await dataContext.Users.FindAsync(user.Id)
                };
                dataContext.Add(manager);
                await dataContext.SaveChangesAsync();
                */
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
