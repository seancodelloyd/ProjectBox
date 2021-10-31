using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

using Autoboxd.Items;
using Autoboxd.Ratings;

namespace Autoboxd.Data
{
    public class DataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Item, Guid> _itemRepository;
        private readonly IRepository<Rating, Guid> _ratingRepository;

        public DataSeedContributor(
            IRepository<Item, Guid> itemRepository,
            IRepository<Rating, Guid> ratingRepository)
        {
            _itemRepository = itemRepository;
            _ratingRepository = ratingRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _itemRepository.GetCountAsync() > 0)
            {
                return;
            }

            var f50 = await _itemRepository.InsertAsync(
                new Item
                {
                    Name = "Ferrari F50",
                    Path = "ferrari-f50-1995",
                    Description = "A very fast car",
                    ManufacturedYear = 1995
                },
                autoSave: true
            );

            if (await _ratingRepository.GetCountAsync() <= 0)
            {
                await _ratingRepository.InsertAsync(
                    new Rating
                    {
                        Value = 9,
                        ItemId = f50.Id
                    },
                    autoSave: true
                );
            }
        }
    }
}