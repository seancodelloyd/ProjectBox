using AutoMapper;

using Autoboxd.Items;
using Autoboxd.Ratings;
using Autoboxd.Lists;
using Autoboxd.ListItems;

namespace Autoboxd
{
    public class AutoboxdApplicationAutoMapperProfile : Profile
    {
        public AutoboxdApplicationAutoMapperProfile()
        {
            CreateMap<Item, ItemDto>();
            CreateMap<CreateUpdateItemDto, Item>();

            CreateMap<Rating, RatingDto>();
            CreateMap<CreateUpdateRatingDto, Rating>();

            CreateMap<List, ListDto>();
            CreateMap<CreateUpdateListDto, List>();
        }
    }
}
