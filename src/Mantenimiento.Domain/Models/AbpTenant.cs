using System;
using System.Collections.Generic;

namespace Mantenimiento.Models;

public partial class AbpTenant
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int EntityVersion { get; set; }

    public string? ExtraProperties { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public DateTime CreationTime { get; set; }

    public Guid? CreatorId { get; set; }

    public DateTime? LastModificationTime { get; set; }

    public Guid? LastModifierId { get; set; }

    public bool? IsDeleted { get; set; }

    public Guid? DeleterId { get; set; }

    public DateTime? DeletionTime { get; set; }

    public virtual ICollection<AbpTenantConnectionString> AbpTenantConnectionStrings { get; set; } = new List<AbpTenantConnectionString>();
}
