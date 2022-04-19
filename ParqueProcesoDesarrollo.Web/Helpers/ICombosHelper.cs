namespace ParqueProcesoDesarrollo.Web.Helpers
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public interface ICombosHelper
    {
        public IEnumerable<SelectListItem> GetComboRoles();
        public IEnumerable<SelectListItem> GetComboStatus();
        public IEnumerable<SelectListItem> GetComboProviders();
        public IEnumerable<SelectListItem> GetComboTypeOfPayments();
        public IEnumerable<SelectListItem> GetComboSupplies();
        public IEnumerable<SelectListItem> GetComboPurchaseHeaders();
        public IEnumerable<SelectListItem> GetComboWristband();
        public IEnumerable<SelectListItem> GetComboCollarSize();
        public IEnumerable<SelectListItem> GetTPMaintenaces();
        public IEnumerable<SelectListItem> GetAttractions();
        public IEnumerable<SelectListItem> GetUsers();
    }
}
