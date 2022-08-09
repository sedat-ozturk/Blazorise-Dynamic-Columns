using Listform_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Listform_Manager.Data;

public class Listform_ManagerDbContext : AbpDbContext<Listform_ManagerDbContext>
{
    public virtual DbSet<Listform> Listform { get; set; }
    public virtual DbSet<ListformField> Listform_Field { get; set; }
    public virtual DbSet<Product> Product { get; set; }

    public Listform_ManagerDbContext(DbContextOptions<Listform_ManagerDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Listform>()
                .HasKey(i => new { i.Id, i.UserName });

        builder.Entity<Listform>(entity =>
        {
            entity.Property(e => e.RecordSource)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        builder.Entity<ListformField>()
                .HasKey(i => i.Id);

        builder.Entity<ListformField>(entity =>
        {
            entity.Property(e => e.FieldName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Listform)
                            .WithMany(p => p.Listform_Field)
                            .HasForeignKey(u => new { u.FormId, u.UserName })
                            .HasConstraintName("FK_StudentCourse_Student");
        });

        builder.Entity<Product>()
                .HasKey(i => i.Id);

        builder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(true);
        });

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own entities here */
    }
}
