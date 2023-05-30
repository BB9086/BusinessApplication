using AutoMapper;
using BusinessMobileApi.Dtos;
using BusinessMobileApi.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BusinessMobileApi.Profiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            //Source -> Target
            //DB -> Web API
            CreateMap<Store, StoreReadDto>();
            CreateMap<StoreMonth, StoreMonthReadDto>();
            CreateMap<StoreYear, StoreYearReadDto>();
        }
    }
}
