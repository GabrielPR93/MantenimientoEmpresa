using System;
using System.Collections.Generic;

namespace Mantenimiento.Models;

public partial class AbpPermissionGroup
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public string? ExtraProperties { get; set; }
}
