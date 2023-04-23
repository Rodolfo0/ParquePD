using Microsoft.AspNetCore.Mvc;
using ParqueProcesoDesarrollo.Web.Helpers;
using ParqueProcesoDesarrollo.Web.Models;
using System.Threading.Tasks;

namespace ParqueProcesoDesarrollo.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHelper userHelper;
        public AccountController(IUserHelper userHelper)
        {
            this.userHelper = userHelper;
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
                return this.RedirectToAction("Index", "Home");
                //TODO En cuanto se tenga el detalles de Empleado, redireccionar a esa el Login.
                //return this.RedirectToAction("Details", "Employee");
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await this.userHelper.LoginAsync
                    (model.Email, model.Password, model.RememberMe);
                if (result.Succeeded)
                {
                    return this.RedirectToAction("Index", "Home");
                }

                this.ModelState.TryAddModelError(string.Empty, "Falló el LogIn");
                return this.View(model);
            }

            this.ModelState.TryAddModelError(string.Empty, "Falló el LogIn");
            return this.View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await this.userHelper.LogoutAsync();
            return this.RedirectToAction("Index", "Home");
        }
    }
}
