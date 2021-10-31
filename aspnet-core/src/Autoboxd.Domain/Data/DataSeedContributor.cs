using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

using Autoboxd.Items;
using Autoboxd.Ratings;
using System.Collections.Generic;

namespace Autoboxd.Data
{
    public class DataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Item, Guid> _itemRepository;
        private readonly IRepository<Rating, Guid> _ratingRepository;

        private List<Item> Items;

        public DataSeedContributor(
            IRepository<Item, Guid> itemRepository,
            IRepository<Rating, Guid> ratingRepository)
        {
            _itemRepository = itemRepository;
            _ratingRepository = ratingRepository;

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

        private static List<Item> GetSeedItems()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Ferrari F50",
                    Path = "ferrari-f50-1995",
                    Description = "A very fast car",
                    ManufacturedYear = 1995,
                    IsFeatured = true
                },
                new Item
                {
                    Name = "Jaguar E-Type",
                    Path = "jaguar-e-type",
                    Description = "A very fast car",
                    ManufacturedYear = 1995,
                    IsFeatured = false
                },
                new Item
                {
                    Name = "Chevrolet Corvette",
                    Path = "chevrolet-corvette",
                    Description = "A very fast car",
                    ManufacturedYear = 1995,
                    IsFeatured = false
                },
                new Item
                {
                    Name = "Lamborghini Miura",
                    Path = "lamborghini-miura",
                    Description = "A very fast car",
                    ManufacturedYear = 1995,
                    IsFeatured = false
                },
                new Item
                {
                    Name = "Porsche 911",
                    Path = "porsche-911",
                    Description = "A very fast car",
                    ManufacturedYear = 1995,
                    IsFeatured = true
                },
                new Item
                {
                    Name = "Rolls-Royce Dawn Drophead",
                    Path = "rolls-royce-dawn-drophead",
                    Description = "A very fast car",
                    ManufacturedYear = 1995,
                    IsFeatured = false
                },
                new Item
                {
                    Name = "Mercedes SL 300 Gullwing",
                    Path = "mercedes-sl-300-gullwing",
                    Description = "A very fast car",
                    ManufacturedYear = 1995,
                    IsFeatured = true
                },
                new Item
                {
                    Name = "Ferrari 250 GTO",
                    Path = "ferrari-250-gto",
                    Description = "A very fast car",
                    ManufacturedYear = 1995,
                    IsFeatured = false
                },
                new Item
                {
                    Name = "Aston Martin DB4",
                    Path = "aston-martin-db4",
                    Description = "A very fast car",
                    ManufacturedYear = 1995,
                    IsFeatured = true
                },
                new Item
                {
                    Name = "BMW 3.0 CSL",
                    Path = "bmw-30-csl",
                    Description = "A very fast car",
                    ManufacturedYear = 1995,
                    IsFeatured = false
                },
                new Item
                {
                    Name = "Acura NSX",
                    Path = "acura-nsx",
                    Description = "A very fast car",
                    ManufacturedYear = 1995,
                    IsFeatured = false
                },
                new Item
                {
                    Name = "VW Beetle",
                    Path = "vw-beetle",
                    Description = "A very fast car",
                    ManufacturedYear = 1995,
                    IsFeatured = true
                }
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