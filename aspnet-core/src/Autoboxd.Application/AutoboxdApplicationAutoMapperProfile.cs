using AutoMapper;

using Autoboxd.Items;
using Autoboxd.Ratings;
using Autoboxd.Lists;
using Autoboxd.ListItems;
using Autoboxd.Reviews;

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

            CreateMap<ListItem, ListItemDto>();
            CreateMap<CreateUpdateListItemDto, ListItem>();

            CreateMap<Review, ReviewDto>();
            CreateMap<CreateUpdateReviewDto, Review>();
        }
    }
}
