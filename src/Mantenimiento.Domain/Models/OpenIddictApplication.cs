﻿using System;
using System.Collections.Generic;

namespace Mantenimiento.Models;

public partial class OpenIddictApplication
{
    public Guid Id { get; set; }

    public string? ClientId { get; set; }

    public string? ClientSecret { get; set; }

    public string? ConsentType { get; set; }

    public string? DisplayName { get; set; }

    public string? DisplayNames { get; set; }

    public string? Permissions { get; set; }

    public string? PostLogoutRedirectUris { get; set; }

    public string? Properties { get; set; }

    public string? RedirectUris { get; set; }

    public string? Requirements { get; set; }

    public string? Type { get; set; }

    public string? ClientUri { get; set; }

    public string? LogoUri { get; set; }

    public string? ExtraProperties { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public DateTime CreationTime { get; set; }

    public Guid? CreatorId { get; set; }

    public DateTime? LastModificationTime { get; set; }

    public Guid? LastModifierId { get; set; }

    public bool? IsDeleted { get; set; }

    public Guid? DeleterId { get; set; }

    public DateTime? DeletionTime { get; set; }

    public virtual ICollection<OpenIddictAuthorization> OpenIddictAuthorizations { get; set; } = new List<OpenIddictAuthorization>();

    public virtual ICollection<OpenIddictToken> OpenIddictTokens { get; set; } = new List<OpenIddictToken>();
}
