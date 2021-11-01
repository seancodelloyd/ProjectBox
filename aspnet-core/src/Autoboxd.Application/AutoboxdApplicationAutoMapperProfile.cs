using AutoMapper;

using Autoboxd.Items;
using Autoboxd.Ratings;

namespace Autoboxd
{
    public class AutoboxdApplicationAutoMapperProfile : Profile
    {
        public AutoboxdApplicationAutoMapperProfile()
        {
            CreateMap<Item, ItemDto>();
            CreateMap<CreateUpdateListDto, Item>();

            CreateMap<Rating, RatingDto>();
            CreateMap<CreateUpdateRatingDto, Rating>();
        }
    }
}
