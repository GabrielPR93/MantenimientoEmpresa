using System;
using System.Collections.Generic;

namespace Mantenimiento.Models;

public partial class OpenIddictToken
{
    public Guid Id { get; set; }

    public Guid? ApplicationId { get; set; }

    public Guid? AuthorizationId { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public string? Payload { get; set; }

    public string? Properties { get; set; }

    public DateTime? RedemptionDate { get; set; }

    public string? ReferenceId { get; set; }

    public string? Status { get; set; }

    public string? Subject { get; set; }

    public string? Type { get; set; }

    public string? ExtraProperties { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public DateTime CreationTime { get; set; }

    public Guid? CreatorId { get; set; }

    public DateTime? LastModificationTime { get; set; }

    public Guid? LastModifierId { get; set; }

    public bool? IsDeleted { get; set; }

    public Guid? DeleterId { get; set; }

    public DateTime? DeletionTime { get; set; }

    public virtual OpenIddictApplication? Application { get; set; }

    public virtual OpenIddictAuthorization? Authorization { get; set; }
}
