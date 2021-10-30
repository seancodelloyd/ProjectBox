using Autoboxd.Items;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Autoboxd.Data
{
    public class DataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Item, Guid> _itemRepository;

        public DataSeedContributor(IRepository<Item, Guid> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _itemRepository.GetCountAsync() <= 0)
            {
                await _itemRepository.InsertAsync(
                    new Item
                    {
                        Name = "Ferrari F50",
                        Description = "A very fast car",
                        ManufacturedYear = 1995
                    },
                    autoSave: true
                );
            }
        }
    }
}