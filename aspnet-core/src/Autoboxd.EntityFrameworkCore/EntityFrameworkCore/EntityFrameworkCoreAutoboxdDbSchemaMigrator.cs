using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Autoboxd.Data;
using Volo.Abp.DependencyInjection;

namespace Autoboxd.EntityFrameworkCore
{
    public class EntityFrameworkCoreAutoboxdDbSchemaMigrator
        : IAutoboxdDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreAutoboxdDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the AutoboxdDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<AutoboxdDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
