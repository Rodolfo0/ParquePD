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

    }
}
