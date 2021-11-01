using Autoboxd.Items;
using AutoMapper;

namespace Autoboxd.Web
{
    public class AutoboxdWebAutoMapperProfile : Profile
    {
        public AutoboxdWebAutoMapperProfile()
        {
            CreateMap<ItemDto, CreateUpdateListDto>();
        }
    }
}
