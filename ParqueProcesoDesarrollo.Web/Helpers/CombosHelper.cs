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
        public IEnumerable<SelectListItem> GetComboWristband()
        {
            var list = this.dataContext.TypeOfWristbands.Select(ph => new SelectListItem
            {
                Text = ph.Description,
                Value = $"{ph.Id}"
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Selecciona una Pulsera ",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboCollarSize()
        {
            var list = this.dataContext.CollarSizes.Select(ph => new SelectListItem
            {
                Text = ph.Size,
                Value = $"{ph.Id}"
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Selecciona un collar para tu mascota ",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetAttractions()
        {
            var list = this.dataContext.Attractions.Select(ato => new SelectListItem
            {
                Text = ato.Name,
                Value = $"{ato.Id}"
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "¿Que Atraccion es?",
                Value = "0"
            });

            return list;
        }
        public IEnumerable<SelectListItem> GetTPMaintenaces()
        {
            var list = this.dataContext.TypeOfMaintenances.Select(tm => new SelectListItem
            {
                Text = tm.Description,
                Value = $"{tm.Id}"
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "¿Tipo de M?",
                Value = "0"
            });

            return list;
        }
        public IEnumerable<SelectListItem> GetUsers()
        {
            var list = this.dataContext.Users.Select(us => new SelectListItem
            {
                Text = us.FirstName,
                Value = $"{us.Id}"
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "¿Quien es?",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetSizes()
        {
            var list = dataContext.Sizes.Select(sz => new SelectListItem
            {
                Text = sz.Name,
                Value = $"{sz.Id}"
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Seleccione el tamaño del perro ",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetVisitors()
        {
            var list = dataContext.WristbandsSaleDetail.Select(wsd => new SelectListItem
            {
                Text = wsd.NameOfPersonInCharge,
                Value = $"{wsd.Id}"
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Seleccione un visitante",
                Value = "0"
            });

            return list;
        }
    }
}
