using Autoboxd.Items;
using AutoMapper;

namespace Autoboxd
{
    public class AutoboxdApplicationAutoMapperProfile : Profile
    {
        public AutoboxdApplicationAutoMapperProfile()
        {
            CreateMap<Item, ItemDto>();
            CreateMap<CreateUpdateItemDto, Item>();
        }
    }
}
