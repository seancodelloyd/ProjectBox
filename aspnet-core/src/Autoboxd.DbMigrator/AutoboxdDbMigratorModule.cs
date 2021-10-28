using Autoboxd.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Autoboxd.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AutoboxdEntityFrameworkCoreModule),
        typeof(AutoboxdApplicationContractsModule)
        )]
    public class AutoboxdDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
