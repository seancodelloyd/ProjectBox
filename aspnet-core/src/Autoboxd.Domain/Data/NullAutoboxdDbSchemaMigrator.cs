using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Autoboxd.Data
{
    /* This is used if database provider does't define
     * IAutoboxdDbSchemaMigrator implementation.
     */
    public class NullAutoboxdDbSchemaMigrator : IAutoboxdDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}