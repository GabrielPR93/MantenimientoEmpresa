using System;
using System.Collections.Generic;
using System.Text;
using Mantenimiento.Localization;
using Volo.Abp.Application.Services;

namespace Mantenimiento;

/* Inherit your application services from this class.
 */
public abstract class MantenimientoAppService : ApplicationService
{
    protected MantenimientoAppService()
    {
        LocalizationResource = typeof(MantenimientoResource);
    }
}
