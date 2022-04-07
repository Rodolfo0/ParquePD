namespace ParqueProcesoDesarrollo.Web.Helpers
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public interface ICombosHelper
    {
        public IEnumerable<SelectListItem> GetComboRoles();
    }
}
