using Autoboxd.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Autoboxd
{
    [DependsOn(
        typeof(AutoboxdEntityFrameworkCoreTestModule)
        )]
    public class AutoboxdDomainTestModule : AbpModule
    {

    }
}