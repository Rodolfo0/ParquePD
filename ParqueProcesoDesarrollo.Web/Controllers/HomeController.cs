using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ParqueProcesoDesarrollo.Web.Data;
using ParqueProcesoDesarrollo.Web.Data.Entities;
using ParqueProcesoDesarrollo.Web.Helpers;
using ParqueProcesoDesarrollo.Web.Models;
using System.Diagnostics;
using System.Linq;

namespace ParqueProcesoDesarrollo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext dataContext;
        private readonly IImageHelper imageHelper;

        public HomeController(ILogger<HomeController> logger, DataContext dataContext, IImageHelper imageHelper)
        {
            _logger = logger;
            this.dataContext = dataContext;
            this.imageHelper = imageHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string GetPicture ()
        {
            var user = this.dataContext.Users.FirstOrDefault(u => u.Email == this.User.Identity.Name);
            if (user != null)
            {
                string path = user.ImageUrl;
                string newPath = imageHelper.GetProfilePath(path);
                return newPath;
            }

            return "/images/_default.jpeg";
        }
    }
}
