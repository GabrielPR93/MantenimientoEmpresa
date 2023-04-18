using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mantenimiento.Models;

public partial class BdMantenimientoContext : DbContext
{
    public BdMantenimientoContext()
    {
    }

    public BdMantenimientoContext(DbContextOptions<BdMantenimientoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AbpAuditLog> AbpAuditLogs { get; set; }

    public virtual DbSet<AbpAuditLogAction> AbpAuditLogActions { get; set; }

    public virtual DbSet<AbpBackgroundJob> AbpBackgroundJobs { get; set; }

    public virtual DbSet<AbpClaimType> AbpClaimTypes { get; set; }

    public virtual DbSet<AbpEntityChange> AbpEntityChanges { get; set; }

    public virtual DbSet<AbpEntityPropertyChange> AbpEntityPropertyChanges { get; set; }

    public virtual DbSet<AbpFeature> AbpFeatures { get; set; }

    public virtual DbSet<AbpFeatureGroup> AbpFeatureGroups { get; set; }

    public virtual DbSet<AbpFeatureValue> AbpFeatureValues { get; set; }

    public virtual DbSet<AbpLinkUser> AbpLinkUsers { get; set; }

    public virtual DbSet<AbpOrganizationUnit> AbpOrganizationUnits { get; set; }

    public virtual DbSet<AbpOrganizationUnitRole> AbpOrganizationUnitRoles { get; set; }

    public virtual DbSet<AbpPermission> AbpPermissions { get; set; }

    public virtual DbSet<AbpPermissionGrant> AbpPermissionGrants { get; set; }

    public virtual DbSet<AbpPermissionGroup> AbpPermissionGroups { get; set; }

    public virtual DbSet<AbpRole> AbpRoles { get; set; }

    public virtual DbSet<AbpRoleClaim> AbpRoleClaims { get; set; }

    public virtual DbSet<AbpSecurityLog> AbpSecurityLogs { get; set; }

    public virtual DbSet<AbpSetting> AbpSettings { get; set; }

    public virtual DbSet<AbpTenant> AbpTenants { get; set; }

    public virtual DbSet<AbpTenantConnectionString> AbpTenantConnectionStrings { get; set; }

    public virtual DbSet<AbpUser> AbpUsers { get; set; }

    public virtual DbSet<AbpUserClaim> AbpUserClaims { get; set; }

    public virtual DbSet<AbpUserLogin> AbpUserLogins { get; set; }

    public virtual DbSet<AbpUserOrganizationUnit> AbpUserOrganizationUnits { get; set; }

    public virtual DbSet<AbpUserRole> AbpUserRoles { get; set; }

    public virtual DbSet<AbpUserToken> AbpUserTokens { get; set; }

    public virtual DbSet<Acreditacione> Acreditaciones { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<Materiale> Materiales { get; set; }

    public virtual DbSet<OpenIddictApplication> OpenIddictApplications { get; set; }

    public virtual DbSet<OpenIddictAuthorization> OpenIddictAuthorizations { get; set; }

    public virtual DbSet<OpenIddictScope> OpenIddictScopes { get; set; }

    public virtual DbSet<OpenIddictToken> OpenIddictTokens { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-AQQ60I2;Database=BD_MANTENIMIENTO;User Id=admin;Password=admin;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AbpAuditLog>(entity =>
        {
            entity.HasIndex(e => new { e.TenantId, e.ExecutionTime }, "IX_AbpAuditLogs_TenantId_ExecutionTime");

            entity.HasIndex(e => new { e.TenantId, e.UserId, e.ExecutionTime }, "IX_AbpAuditLogs_TenantId_UserId_ExecutionTime");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ApplicationName).HasMaxLength(96);
            entity.Property(e => e.BrowserInfo).HasMaxLength(512);
            entity.Property(e => e.ClientId).HasMaxLength(64);
            entity.Property(e => e.ClientIpAddress).HasMaxLength(64);
            entity.Property(e => e.ClientName).HasMaxLength(128);
            entity.Property(e => e.Comments).HasMaxLength(256);
            entity.Property(e => e.ConcurrencyStamp).HasMaxLength(40);
            entity.Property(e => e.CorrelationId).HasMaxLength(64);
            entity.Property(e => e.HttpMethod).HasMaxLength(16);
            entity.Property(e => e.ImpersonatorTenantName).HasMaxLength(64);
            entity.Property(e => e.ImpersonatorUserName).HasMaxLength(256);
            entity.Property(e => e.TenantName).HasMaxLength(64);
            entity.Property(e => e.Url).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<AbpAuditLogAction>(entity =>
        {
            entity.HasIndex(e => e.AuditLogId, "IX_AbpAuditLogActions_AuditLogId");

            entity.HasIndex(e => new { e.TenantId, e.ServiceName, e.MethodName, e.ExecutionTime }, "IX_AbpAuditLogActions_TenantId_ServiceName_MethodName_ExecutionTime");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.MethodName).HasMaxLength(128);
            entity.Property(e => e.Parameters).HasMaxLength(2000);
            entity.Property(e => e.ServiceName).HasMaxLength(256);

            entity.HasOne(d => d.AuditLog).WithMany(p => p.AbpAuditLogActions).HasForeignKey(d => d.AuditLogId);
        });

        modelBuilder.Entity<AbpBackgroundJob>(entity =>
        {
            entity.HasIndex(e => new { e.IsAbandoned, e.NextTryTime }, "IX_AbpBackgroundJobs_IsAbandoned_NextTryTime");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ConcurrencyStamp).HasMaxLength(40);
            entity.Property(e => e.IsAbandoned)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.JobName).HasMaxLength(128);
            entity.Property(e => e.Priority).HasDefaultValueSql("(CONVERT([tinyint],(15)))");
            entity.Property(e => e.TryCount).HasDefaultValueSql("(CONVERT([smallint],(0)))");
        });

        modelBuilder.Entity<AbpClaimType>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ConcurrencyStamp).HasMaxLength(40);
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.Regex).HasMaxLength(512);
            entity.Property(e => e.RegexDescription).HasMaxLength(128);
        });

        modelBuilder.Entity<AbpEntityChange>(entity =>
        {
            entity.HasIndex(e => e.AuditLogId, "IX_AbpEntityChanges_AuditLogId");

            entity.HasIndex(e => new { e.TenantId, e.EntityTypeFullName, e.EntityId }, "IX_AbpEntityChanges_TenantId_EntityTypeFullName_EntityId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.EntityId).HasMaxLength(128);
            entity.Property(e => e.EntityTypeFullName).HasMaxLength(128);

            entity.HasOne(d => d.AuditLog).WithMany(p => p.AbpEntityChanges).HasForeignKey(d => d.AuditLogId);
        });

        modelBuilder.Entity<AbpEntityPropertyChange>(entity =>
        {
            entity.HasIndex(e => e.EntityChangeId, "IX_AbpEntityPropertyChanges_EntityChangeId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NewValue).HasMaxLength(512);
            entity.Property(e => e.OriginalValue).HasMaxLength(512);
            entity.Property(e => e.PropertyName).HasMaxLength(128);
            entity.Property(e => e.PropertyTypeFullName).HasMaxLength(64);

            entity.HasOne(d => d.EntityChange).WithMany(p => p.AbpEntityPropertyChanges).HasForeignKey(d => d.EntityChangeId);
        });

        modelBuilder.Entity<AbpFeature>(entity =>
        {
            entity.HasIndex(e => e.GroupName, "IX_AbpFeatures_GroupName");

            entity.HasIndex(e => e.Name, "IX_AbpFeatures_Name").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AllowedProviders).HasMaxLength(256);
            entity.Property(e => e.DefaultValue).HasMaxLength(256);
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.DisplayName).HasMaxLength(256);
            entity.Property(e => e.GroupName).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);
            entity.Property(e => e.ParentName).HasMaxLength(128);
            entity.Property(e => e.ValueType).HasMaxLength(2048);
        });

        modelBuilder.Entity<AbpFeatureGroup>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_AbpFeatureGroups_Name").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DisplayName).HasMaxLength(256);
            entity.Property(e => e.Name).HasMaxLength(128);
        });

        modelBuilder.Entity<AbpFeatureValue>(entity =>
        {
            entity.HasIndex(e => new { e.Name, e.ProviderName, e.ProviderKey }, "IX_AbpFeatureValues_Name_ProviderName_ProviderKey")
                .IsUnique()
                .HasFilter("([ProviderName] IS NOT NULL AND [ProviderKey] IS NOT NULL)");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(64);
            entity.Property(e => e.ProviderName).HasMaxLength(64);
            entity.Property(e => e.Value).HasMaxLength(128);
        });

        modelBuilder.Entity<AbpLinkUser>(entity =>
        {
            entity.HasIndex(e => new { e.SourceUserId, e.SourceTenantId, e.TargetUserId, e.TargetTenantId }, "IX_AbpLinkUsers_SourceUserId_SourceTenantId_TargetUserId_TargetTenantId")
                .IsUnique()
                .HasFilter("([SourceTenantId] IS NOT NULL AND [TargetTenantId] IS NOT NULL)");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<AbpOrganizationUnit>(entity =>
        {
            entity.HasIndex(e => e.Code, "IX_AbpOrganizationUnits_Code");

            entity.HasIndex(e => e.ParentId, "IX_AbpOrganizationUnits_ParentId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Code).HasMaxLength(95);
            entity.Property(e => e.ConcurrencyStamp).HasMaxLength(40);
            entity.Property(e => e.DisplayName).HasMaxLength(128);
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent).HasForeignKey(d => d.ParentId);
        });

        modelBuilder.Entity<AbpOrganizationUnitRole>(entity =>
        {
            entity.HasKey(e => new { e.OrganizationUnitId, e.RoleId });

            entity.HasIndex(e => new { e.RoleId, e.OrganizationUnitId }, "IX_AbpOrganizationUnitRoles_RoleId_OrganizationUnitId");

            entity.HasOne(d => d.OrganizationUnit).WithMany(p => p.AbpOrganizationUnitRoles).HasForeignKey(d => d.OrganizationUnitId);

            entity.HasOne(d => d.Role).WithMany(p => p.AbpOrganizationUnitRoles).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AbpPermission>(entity =>
        {
            entity.HasIndex(e => e.GroupName, "IX_AbpPermissions_GroupName");

            entity.HasIndex(e => e.Name, "IX_AbpPermissions_Name").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DisplayName).HasMaxLength(256);
            entity.Property(e => e.GroupName).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);
            entity.Property(e => e.ParentName).HasMaxLength(128);
            entity.Property(e => e.Providers).HasMaxLength(128);
            entity.Property(e => e.StateCheckers).HasMaxLength(256);
        });

        modelBuilder.Entity<AbpPermissionGrant>(entity =>
        {
            entity.HasIndex(e => new { e.TenantId, e.Name, e.ProviderName, e.ProviderKey }, "IX_AbpPermissionGrants_TenantId_Name_ProviderName_ProviderKey")
                .IsUnique()
                .HasFilter("([TenantId] IS NOT NULL)");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(64);
            entity.Property(e => e.ProviderName).HasMaxLength(64);
        });

        modelBuilder.Entity<AbpPermissionGroup>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_AbpPermissionGroups_Name").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DisplayName).HasMaxLength(256);
            entity.Property(e => e.Name).HasMaxLength(128);
        });

        modelBuilder.Entity<AbpRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "IX_AbpRoles_NormalizedName");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ConcurrencyStamp).HasMaxLength(40);
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AbpRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AbpRoleClaims_RoleId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClaimType).HasMaxLength(256);
            entity.Property(e => e.ClaimValue).HasMaxLength(1024);

            entity.HasOne(d => d.Role).WithMany(p => p.AbpRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AbpSecurityLog>(entity =>
        {
            entity.HasIndex(e => new { e.TenantId, e.Action }, "IX_AbpSecurityLogs_TenantId_Action");

            entity.HasIndex(e => new { e.TenantId, e.ApplicationName }, "IX_AbpSecurityLogs_TenantId_ApplicationName");

            entity.HasIndex(e => new { e.TenantId, e.Identity }, "IX_AbpSecurityLogs_TenantId_Identity");

            entity.HasIndex(e => new { e.TenantId, e.UserId }, "IX_AbpSecurityLogs_TenantId_UserId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Action).HasMaxLength(96);
            entity.Property(e => e.ApplicationName).HasMaxLength(96);
            entity.Property(e => e.BrowserInfo).HasMaxLength(512);
            entity.Property(e => e.ClientId).HasMaxLength(64);
            entity.Property(e => e.ClientIpAddress).HasMaxLength(64);
            entity.Property(e => e.ConcurrencyStamp).HasMaxLength(40);
            entity.Property(e => e.CorrelationId).HasMaxLength(64);
            entity.Property(e => e.Identity).HasMaxLength(96);
            entity.Property(e => e.TenantName).HasMaxLength(64);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<AbpSetting>(entity =>
        {
            entity.HasIndex(e => new { e.Name, e.ProviderName, e.ProviderKey }, "IX_AbpSettings_Name_ProviderName_ProviderKey")
                .IsUnique()
                .HasFilter("([ProviderName] IS NOT NULL AND [ProviderKey] IS NOT NULL)");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(64);
            entity.Property(e => e.ProviderName).HasMaxLength(64);
            entity.Property(e => e.Value).HasMaxLength(2048);
        });

        modelBuilder.Entity<AbpTenant>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_AbpTenants_Name");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ConcurrencyStamp).HasMaxLength(40);
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Name).HasMaxLength(64);
        });

        modelBuilder.Entity<AbpTenantConnectionString>(entity =>
        {
            entity.HasKey(e => new { e.TenantId, e.Name });

            entity.Property(e => e.Name).HasMaxLength(64);
            entity.Property(e => e.Value).HasMaxLength(1024);

            entity.HasOne(d => d.Tenant).WithMany(p => p.AbpTenantConnectionStrings).HasForeignKey(d => d.TenantId);
        });

        modelBuilder.Entity<AbpUser>(entity =>
        {
            entity.HasIndex(e => e.Email, "IX_AbpUsers_Email");

            entity.HasIndex(e => e.NormalizedEmail, "IX_AbpUsers_NormalizedEmail");

            entity.HasIndex(e => e.NormalizedUserName, "IX_AbpUsers_NormalizedUserName");

            entity.HasIndex(e => e.UserName, "IX_AbpUsers_UserName");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ConcurrencyStamp).HasMaxLength(40);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.EmailConfirmed)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.IsExternal)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.LockoutEnabled)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Name).HasMaxLength(64);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.PasswordHash).HasMaxLength(256);
            entity.Property(e => e.PhoneNumber).HasMaxLength(16);
            entity.Property(e => e.PhoneNumberConfirmed)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.SecurityStamp).HasMaxLength(256);
            entity.Property(e => e.Surname).HasMaxLength(64);
            entity.Property(e => e.TwoFactorEnabled)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<AbpUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AbpUserClaims_UserId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClaimType).HasMaxLength(256);
            entity.Property(e => e.ClaimValue).HasMaxLength(1024);

            entity.HasOne(d => d.User).WithMany(p => p.AbpUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AbpUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider });

            entity.HasIndex(e => new { e.LoginProvider, e.ProviderKey }, "IX_AbpUserLogins_LoginProvider_ProviderKey");

            entity.Property(e => e.LoginProvider).HasMaxLength(64);
            entity.Property(e => e.ProviderDisplayName).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(196);

            entity.HasOne(d => d.User).WithMany(p => p.AbpUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AbpUserOrganizationUnit>(entity =>
        {
            entity.HasKey(e => new { e.OrganizationUnitId, e.UserId });

            entity.HasIndex(e => new { e.UserId, e.OrganizationUnitId }, "IX_AbpUserOrganizationUnits_UserId_OrganizationUnitId");

            entity.HasOne(d => d.OrganizationUnit).WithMany(p => p.AbpUserOrganizationUnits).HasForeignKey(d => d.OrganizationUnitId);

            entity.HasOne(d => d.User).WithMany(p => p.AbpUserOrganizationUnits).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AbpUserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId });

            entity.HasIndex(e => new { e.RoleId, e.UserId }, "IX_AbpUserRoles_RoleId_UserId");

            entity.HasOne(d => d.Role).WithMany(p => p.AbpUserRoles).HasForeignKey(d => d.RoleId);

            entity.HasOne(d => d.User).WithMany(p => p.AbpUserRoles).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AbpUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(64);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AbpUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Acreditacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__acredita__3213E83F9935ABC3");

            entity.ToTable("acreditaciones");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.FechaValidez)
                .HasColumnType("date")
                .HasColumnName("fecha_validez");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Acreditaciones)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__acreditac__emple__37A5467C");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3213E83FBD24922C");

            entity.ToTable("categorias");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__departam__3213E83F4C077761");

            entity.ToTable("departamentos");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__empleado__3213E83FB527CF8C");

            entity.ToTable("empleados");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.DepartamentoId).HasColumnName("departamento_id");
            entity.Property(e => e.EmpresaId).HasColumnName("empresa_id");
            entity.Property(e => e.FechaContratacion)
                .HasColumnType("date")
                .HasColumnName("fecha_contratacion");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.Departamento).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.DepartamentoId)
                .HasConstraintName("FK__empleados__depar__2B3F6F97");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK__empleados__empre__2C3393D0");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__empresas__3213E83FC9825B25");

            entity.ToTable("empresas");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK__empresas__catego__286302EC");
        });

        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__equipos__3213E83FCC6FB80D");

            entity.ToTable("equipos");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.EmpresaId).HasColumnName("empresa_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Equipos)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK__equipos__empresa__34C8D9D1");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Equipos)
                .HasForeignKey(d => d.ProveedorId)
                .HasConstraintName("FK__equipos__proveed__33D4B598");
        });

        modelBuilder.Entity<Materiale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__material__3213E83F6DD3A1B0");

            entity.ToTable("materiales");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Materiales)
                .HasForeignKey(d => d.ProveedorId)
                .HasConstraintName("FK__materiale__prove__30F848ED");
        });

        modelBuilder.Entity<OpenIddictApplication>(entity =>
        {
            entity.HasIndex(e => e.ClientId, "IX_OpenIddictApplications_ClientId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClientId).HasMaxLength(100);
            entity.Property(e => e.ConcurrencyStamp).HasMaxLength(40);
            entity.Property(e => e.ConsentType).HasMaxLength(50);
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<OpenIddictAuthorization>(entity =>
        {
            entity.HasIndex(e => new { e.ApplicationId, e.Status, e.Subject, e.Type }, "IX_OpenIddictAuthorizations_ApplicationId_Status_Subject_Type");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ConcurrencyStamp).HasMaxLength(40);
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Subject).HasMaxLength(400);
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.Application).WithMany(p => p.OpenIddictAuthorizations).HasForeignKey(d => d.ApplicationId);
        });

        modelBuilder.Entity<OpenIddictScope>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_OpenIddictScopes_Name");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ConcurrencyStamp).HasMaxLength(40);
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<OpenIddictToken>(entity =>
        {
            entity.HasIndex(e => new { e.ApplicationId, e.Status, e.Subject, e.Type }, "IX_OpenIddictTokens_ApplicationId_Status_Subject_Type");

            entity.HasIndex(e => e.AuthorizationId, "IX_OpenIddictTokens_AuthorizationId");

            entity.HasIndex(e => e.ReferenceId, "IX_OpenIddictTokens_ReferenceId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ConcurrencyStamp).HasMaxLength(40);
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.ReferenceId).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Subject).HasMaxLength(400);
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.Application).WithMany(p => p.OpenIddictTokens).HasForeignKey(d => d.ApplicationId);

            entity.HasOne(d => d.Authorization).WithMany(p => p.OpenIddictTokens).HasForeignKey(d => d.AuthorizationId);
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__proveedo__3213E83FEDF7AD9D");

            entity.ToTable("proveedores");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
