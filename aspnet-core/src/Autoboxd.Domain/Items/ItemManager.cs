using JetBrains.Annotations;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Autoboxd.Items
{
    public class ItemManager : DomainService
    {
        private readonly IItemRepository _itemRepository;

        public ItemManager(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> CreateAsync(
            [NotNull] string name,
            [NotNull] string brand,
            [NotNull] string path,
            [NotNull] string description,
            int manufacturedYear = 0,
            bool isFeatured = false
            )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingItem = await _itemRepository.FindByNameAsync(name);

            if (existingItem != null)
            {
                throw new ItemAlreadyExistsException(name);
            }

            return new Item(
                GuidGenerator.Create(),
                brand,
                name,
                path,
                description,
                manufacturedYear,
                isFeatured
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] Item item,
            [NotNull] string newName)
        {
            Check.NotNull(item, nameof(item));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingItem = await _itemRepository.FindByNameAsync(newName);
            if (existingItem != null && existingItem.Id != item.Id)
            {
                throw new ItemAlreadyExistsException(newName);
            }

            item.ChangeName(newName);
        }
    }
}
