﻿using System;
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

        public SessionsController(DataContext context, ICombosHelper combosHelper)
        {
            this.dataContext = context;
            this.combosHelper = combosHelper;
        }

        //Cambiar directamente a listas de visitantes y de espera (PA-09-01)
        public async Task<IActionResult> Index()
        {
            var session = await dataContext.Sessions
                .Include(s => s.Status)
                .Include(vs => vs.VisitorSession)
                .Include(vns => vns.VisitorNextSession)
                .FirstOrDefaultAsync(s => s.Id == 1);

            session = await GetVisitorLists(session);

            return View(session);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVisitor(SessionViewModel model)
        {
            if (ModelState.IsValid)
            {
                model = (SessionViewModel)await GetVisitorLists(model);

                if(model.VisitorSession.Count < 2)
                {
                    var lastVisitor = await this.dataContext.VisitorSessions.OrderBy(vs => vs.Id).LastOrDefaultAsync();

                    var visitorSession = new VisitorSession
                    {
                        Session = await this.dataContext.Sessions.FirstOrDefaultAsync(s => s.Id == 1),
                        VrEquipment = lastVisitor != default ? 
                            await this.dataContext.VrEquipments.FirstOrDefaultAsync(vr => vr.Id == lastVisitor.VrEquipment.Id + 1) :
                            await this.dataContext.VrEquipments.FirstOrDefaultAsync(vr => vr.Id == 1),
                        WristbandSaleDetail = await this.dataContext.WristbandsSaleDetail.FindAsync(model.VisitorId)
                    };
                    this.dataContext.Add(visitorSession);
                    await this.dataContext.SaveChangesAsync();
                }
                else
                {
                    if (model.VisitorNextSession.Count < 10)
                    {
                        var visitorNextSession = new VisitorNextSession
                        {
                            Session = await this.dataContext.Sessions.FirstOrDefaultAsync(s => s.Id == 1),
                            WristbandSaleDetail = await this.dataContext.WristbandsSaleDetail.FindAsync(model.VisitorId)
                        };
                        this.dataContext.Add(visitorNextSession);
                        await this.dataContext.SaveChangesAsync();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> StartSession()
        {
            var session = await dataContext.Sessions
                .Include(s => s.Status)
                .Include(vs => vs.VisitorSession)
                .Include(vns => vns.VisitorNextSession)
                .FirstOrDefaultAsync(s => s.Id == 1);

            if (session.Status.Id == 5)
            {
                session.StartTime = DateTime.Now;
                session.FinishTime = DateTime.Now.AddMinutes(20);
                session.Status = await this.dataContext.Statuses.FirstOrDefaultAsync(s => s.Id == 6);

                //Ver funcionalidad de un Countdown Timer y detener automaticamente la sesion terminados los 20 min

                await this.dataContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> InterruptSession()
        {
            var session = await dataContext.Sessions
                .Include(s => s.Status)
                .Include(vs => vs.VisitorSession)
                .Include(vns => vns.VisitorNextSession)
                .FirstOrDefaultAsync(s => s.Id == 1);

            if(session.Status.Id == 6)
            {
                session.StartTime = DateTime.MinValue;
                session.FinishTime = DateTime.MinValue;
                session.Status = await this.dataContext.Statuses.FirstOrDefaultAsync(s => s.Id == 5);

                var visitorsSession = await this.dataContext.VisitorSessions.ToListAsync();
                var visitorsNextSession = await this.dataContext.VisitorNextSessions.ToListAsync();

                foreach (var vs in visitorsSession)
                    this.dataContext.VisitorSessions.Remove(vs);
                foreach (var vns in visitorsNextSession)
                {
                    var lastVisitor = await this.dataContext.VisitorSessions.OrderBy(vs => vs.Id).LastOrDefaultAsync();
                    var visitorSession = new VisitorSession
                    {
                        //Crea migraciones antes que nada
                        //Aqui sale un error, falta debuggear
                        Session = await this.dataContext.Sessions.FirstOrDefaultAsync(s => s.Id == 1),
                        VrEquipment = lastVisitor != default ?
                            await this.dataContext.VrEquipments.FirstOrDefaultAsync(vr => vr.Id == lastVisitor.VrEquipment.Id + 1) :
                            await this.dataContext.VrEquipments.FirstOrDefaultAsync(vr => vr.Id == 1),
                        WristbandSaleDetail = await this.dataContext.WristbandsSaleDetail.FindAsync(vns.WristbandSaleDetail)
                    };
                    this.dataContext.Add(visitorSession);
                    this.dataContext.VisitorNextSessions.Remove(vns);
                }

                await this.dataContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        private async Task<Session> GetVisitorLists(Session session)
        {
            session.VisitorSession = await dataContext.VisitorSessions
                .Include(vr => vr.VrEquipment)
                .Include(wsd => wsd.WristbandSaleDetail)
                .Where(vs => vs.Session.Id == session.Id)
                .ToListAsync();
            session.VisitorNextSession = await dataContext.VisitorNextSessions
                .Include(wsd => wsd.WristbandSaleDetail)
                .Where(vs => vs.Session.Id == session.Id)
                .ToListAsync();

            return session;
        }

        private async Task<Session> GetVisitorLists(SessionViewModel session)
        {
            session.VisitorSession = await dataContext.VisitorSessions
                .Include(vr => vr.VrEquipment)
                .Include(wsd => wsd.WristbandSaleDetail)
                .Where(vs => vs.Session.Id == 1)
                .ToListAsync();
            session.VisitorNextSession = await dataContext.VisitorNextSessions
                .Include(wsd => wsd.WristbandSaleDetail)
                .Where(vs => vs.Session.Id == 1)
                .ToListAsync();

            return session;
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
