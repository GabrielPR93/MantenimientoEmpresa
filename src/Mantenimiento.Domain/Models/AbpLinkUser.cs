using System;
using System.Collections.Generic;

namespace Mantenimiento.Models;

public partial class AbpLinkUser
{
    public Guid Id { get; set; }

    public Guid SourceUserId { get; set; }

    public Guid? SourceTenantId { get; set; }

    public Guid TargetUserId { get; set; }

    public Guid? TargetTenantId { get; set; }
}
