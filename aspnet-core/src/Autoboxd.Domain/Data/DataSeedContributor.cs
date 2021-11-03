using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Guids;
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
        private readonly IGuidGenerator _guidGenerator;

        private List<Item> Items;

        public DataSeedContributor(
            IRepository<Item, Guid> itemRepository,
            IRepository<Rating, Guid> ratingRepository,
            IGuidGenerator guidGenerator)
        {
            _itemRepository = itemRepository;
            _ratingRepository = ratingRepository;
            _guidGenerator = guidGenerator;

            Items = new List<Item>();
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _itemRepository.GetCountAsync() > 0)
            {
                return;
            }

            await SaveSeedItems();
            var items = await _itemRepository.GetListAsync();
            Items = items;

            if (await _ratingRepository.GetCountAsync() <= 0)
            {
                await _ratingRepository.InsertAsync(
                    new Rating
                    {
                        Value = 9,
                        ItemId = Items.Single(i => i.Path == "ferrari-f50-1995").Id
                    },
                    autoSave: true
                );
            }
        }

        private List<Item> GetSeedItems()
        {
            var items = new List<Item>
            {
                new Item
                (
                    _guidGenerator.Create(),
                    "Ferrari F50",
                    "ferrari-f50-1995",
                    "A very fast car",
                    1995,
                    true
                ),
                new Item
                (
                    _guidGenerator.Create(),
                    "Jaguar E-Type",
                    "jaguar-e-type",
                    "A very fast car",
                    1995,
                    false
                ),
                new Item
                (
                    _guidGenerator.Create(),
                    "Chevrolet Corvette",
                    "chevrolet-corvette",
                    "A very fast car",
                    1995,
                    false
                ),
                new Item
                (
                    _guidGenerator.Create(),
                    "Lamborghini Miura",
                    "lamborghini-miura",
                    "A very fast car",
                    1995,
                    false
                ),
                new Item
                (
                    _guidGenerator.Create(),
                    "Porsche 911",
                    "porsche-911",
                    "A very fast car",
                    1995,
                    true
                ),
                new Item
                (
                    _guidGenerator.Create(),
                    "Rolls-Royce Dawn Drophead",
                    "rolls-royce-dawn-drophead",
                    "A very fast car",
                    1995,
                    false
                ),
                new Item
                (
                    _guidGenerator.Create(),
                    "Mercedes SL 300 Gullwing",
                    "mercedes-sl-300-gullwing",
                    "A very fast car",
                    1995,
                    true
                ),
                new Item
                (
                    _guidGenerator.Create(),
                    "Ferrari 250 GTO",
                    "ferrari-250-gto",
                    "A very fast car",
                    1995,
                    false
                ),
                new Item
                (
                    _guidGenerator.Create(),
                    "Aston Martin DB4",
                    "aston-martin-db4",
                    "A very fast car",
                    1995,
                    true
                ),
                new Item
                (
                    _guidGenerator.Create(),
                    "BMW 3.0 CSL",
                    "bmw-30-csl",
                    "A very fast car",
                    1995,
                    false
                ),
                new Item
                (
                    _guidGenerator.Create(),
                    "Acura NSX",
                    "acura-nsx",
                    "A very fast car",
                    1995,
                    false
                ),
                new Item
                (
                    _guidGenerator.Create(),
                    "VW Beetle",
                    "vw-beetle",
                    "A very fast car",
                    1995,
                    true
                )
            };

            return items;
        }

        public async Task SaveSeedItems()
        {
            var items = GetSeedItems();

            await _itemRepository.InsertManyAsync(items, autoSave: true);        
        }
    }
}