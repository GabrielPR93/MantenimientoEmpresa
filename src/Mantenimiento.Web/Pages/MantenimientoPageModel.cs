using Mantenimiento.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Mantenimiento.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class MantenimientoPageModel : AbpPageModel
{
    protected MantenimientoPageModel()
    {
        LocalizationResourceType = typeof(MantenimientoResource);
    }
}
