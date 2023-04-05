using Mantenimiento.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Mantenimiento;

[DependsOn(
    typeof(MantenimientoEntityFrameworkCoreTestModule)
    )]
public class MantenimientoDomainTestModule : AbpModule
{

}
