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
    public class SessionsController : Controller
    {
        private readonly DataContext dataContext;
        private readonly ICombosHelper combosHelper;
        private int VisitorList;
        private int WaitingList;

        public SessionsController(DataContext context, ICombosHelper combosHelper)
        {
            this.dataContext = context;
            this.combosHelper = combosHelper;
            this.VisitorList = 0;
            this.WaitingList = 0;
        }

        //Cambiar directamente a listas de visitantes y de espera (PA-09-01)
        public async Task<IActionResult> Index()
        {
            return View(await dataContext.Sessions
                .Include(s => s.Status)
                .Include(vs => vs.VisitorSession)
                .Include(vns => vns.VisitorNextSession)
                .FirstOrDefaultAsync(s => s.Id == 1));
        }

        public IActionResult AddVisitor()
        {
            var model = new SessionViewModel
            {
                Visitors = this.combosHelper.GetVisitors()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddVisitor(SessionViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.VisitorSession.Count >= 10)
                {
                    var visitorSession = new VisitorSession
                    {
                        Session = await this.dataContext.Sessions.FirstOrDefaultAsync(s => s.Id == 1),
                        VrEquipment = await this.dataContext.VrEquipments.FirstOrDefaultAsync(s => s.Id == VisitorList + 1),
                        WristbandSaleDetail = await this.dataContext.WristbandsSaleDetail.FindAsync(model.Visitors)
                    };
                    this.dataContext.Add(visitorSession);
                    await this.dataContext.SaveChangesAsync();

                    this.VisitorList++;
                }
                else
                {
                    if (model.VisitorNextSession.Count >= 10)
                    {
                        var visitorNextSession = new VisitorNextSession
                        {
                            Session = await this.dataContext.Sessions.FirstOrDefaultAsync(s => s.Id == 1),
                            WristbandSaleDetail = await this.dataContext.WristbandsSaleDetail.FindAsync(model.Visitors)
                        };
                        this.dataContext.Add(visitorNextSession);
                        await this.dataContext.SaveChangesAsync();

                        this.WaitingList++;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        //Se van a ir agregando nuevos regitros en VisitorSession y VisitorNextSession
        //El atributo de sesion sera siempre el mismo, el que ya esta en Seeder

        //Cuando se inicie la sesion, se agrega la fecha de sesion y la hora de inicio
        //Se calcula la hora de termino y cuando este llegue se "reinician" los valores

        //Si se termina la sesion antes de tiempo, se "reinician" automaticamente

        //La agregación de usuarios a cualquier lista se hara en otra pantalla (vista) (PA-09-02)

        //La validacion de inicio y termino se hara con ventanas emergentes (PA-09-03 y PA-09-04) (verificar ejemplo de Toño)
    }
}
