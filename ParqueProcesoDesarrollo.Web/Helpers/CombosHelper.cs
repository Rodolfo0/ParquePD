namespace ParqueProcesoDesarrollo.Web.Helpers
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using ParqueProcesoDesarrollo.Web.Data;
    using System.Collections.Generic;
    using System.Linq;

    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext dataContext;

        public CombosHelper(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IEnumerable<SelectListItem> GetComboRoles()
        {
            var list = this.dataContext.Roles.Select(b => new SelectListItem
            {
                Text = b.Name,
                Value = $"{b.Id}"
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Selecciona un rol",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboStatus()
        {
            var list = this.dataContext.Statuses.Select(b => new SelectListItem
            {
                Text = b.Name,
                Value = $"{b.Id}"
            }).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "Selecciona un Estado",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboProviders()
        {
            var list = this.dataContext.Providers.Select(b => new SelectListItem
            {
                Text = b.SocialReason,
                Value = $"{b.Id}"
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Selecciona un proveedor",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboTypeOfPayments()
        {
            var list = this.dataContext.TypeOfPayments.Select(tp => new SelectListItem
            {
                Text = tp.Description,
                Value = $"{tp.Id}"
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Selecciona un método de pago",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboSupplies()
        {
            var list = this.dataContext.Supplies.Select(s => new SelectListItem
            {
                Text = s.Description,
                Value = $"{s.Id}"
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Selecciona un consumible",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboPurchaseHeaders()
        {
            var list = this.dataContext.PurchaseHeader.Select(ph => new SelectListItem
            {
                Text = ph.Provider.SocialReason,
                Value = $"{ph.Id}"
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Selecciona una orden de compra de un proveedor",
                Value = "0"
            });

            return list;
        }
    }
}
