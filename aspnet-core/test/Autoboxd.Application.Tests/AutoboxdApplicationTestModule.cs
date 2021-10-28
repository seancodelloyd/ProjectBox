using Volo.Abp.Modularity;

namespace Autoboxd
{
    [DependsOn(
        typeof(AutoboxdApplicationModule),
        typeof(AutoboxdDomainTestModule)
        )]
    public class AutoboxdApplicationTestModule : AbpModule
    {

    }
}