using Volo.Abp.Modularity;

namespace Mantenimiento;

[DependsOn(
    typeof(MantenimientoApplicationModule),
    typeof(MantenimientoDomainTestModule)
    )]
public class MantenimientoApplicationTestModule : AbpModule
{

}
