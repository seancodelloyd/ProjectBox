using System.Threading.Tasks;

namespace Autoboxd.Data
{
    public interface IAutoboxdDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
