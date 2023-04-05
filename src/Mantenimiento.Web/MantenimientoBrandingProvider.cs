using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Mantenimiento.Web;

[Dependency(ReplaceServices = true)]
public class MantenimientoBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Mantenimiento";
}
