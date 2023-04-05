﻿using Mantenimiento.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Mantenimiento.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MantenimientoController : AbpControllerBase
{
    protected MantenimientoController()
    {
        LocalizationResource = typeof(MantenimientoResource);
    }
}
