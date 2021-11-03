using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

using Autoboxd.Items;
using Autoboxd.Ratings;
using Autoboxd.Lists;
using Autoboxd.ListItems;

using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;

namespace Autoboxd.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(IIdentityDbContext))]
    [ReplaceDbContext(typeof(ITenantManagementDbContext))]
    [ConnectionStringName("Default")]
    public class AutoboxdDbContext : 
        AbpDbContext<AutoboxdDbContext>,
        IIdentityDbContext,
        ITenantManagementDbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<List> Lists { get; set; }
        
        #region Entities from the modules
        
        /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
         * and replaced them for this DbContext. This allows you to perform JOIN
         * queries for the entities of these modules over the repositories easily. You
         * typically don't need that for other modules. But, if you need, you can
         * implement the DbContext interface of the needed module and use ReplaceDbContext
         * attribute just like IIdentityDbContext and ITenantManagementDbContext.
         *
         * More info: Replacing a DbContext of a module ensures that the related module
         * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
         */
        
        //Identity
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityClaimType> ClaimTypes { get; set; }
        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
        public DbSet<IdentityLinkUser> LinkUsers { get; set; }
        
        // Tenant Management
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

        #endregion
        
        public AutoboxdDbContext(DbContextOptions<AutoboxdDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTenantManagement();

            ConfigureEntities(builder);
            builder.ConfigureBlobStoring();
        }

        private void ConfigureEntities(ModelBuilder builder)
        {
            builder.Entity<Item>(b =>
            {
                b.ToTable(AutoboxdConsts.DbTablePrefix + "Items", AutoboxdConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);

                b.HasMany(l => l.ListItems).WithOne(i => i.Item);
            });

            builder.Entity<Rating>(b =>
            {
                b.ToTable(AutoboxdConsts.DbTablePrefix + "Ratings", AutoboxdConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Value).IsRequired();

                b.HasOne<Item>().WithMany().HasForeignKey(x => x.ItemId).IsRequired();
            });

            builder.Entity<List>(b =>
            {
                b.ToTable(AutoboxdConsts.DbTablePrefix + "Lists", AutoboxdConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Title).IsRequired().HasMaxLength(128);

                b.HasMany(l => l.ListItems).WithOne(i => i.List);
            });

            builder.Entity<ListItem>(b =>
            {
                b.ToTable(AutoboxdConsts.DbTablePrefix + "ListItems", AutoboxdConsts.DbSchema);
                b.ConfigureByConvention();

                b.HasKey(li => new { li.ItemId, li.ListId });

                b.HasOne(li => li.Item).WithMany(i => i.ListItems).HasForeignKey(li => li.ItemId);
                b.HasOne(li => li.List).WithMany(l => l.ListItems).HasForeignKey(li => li.ListId);
            });
        }
    }
}
