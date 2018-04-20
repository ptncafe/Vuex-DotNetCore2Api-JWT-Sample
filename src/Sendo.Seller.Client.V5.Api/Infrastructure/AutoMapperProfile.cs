using AutoMapper;
using Sendo.Seller.Client.V5.Api.Dtos.Authentication;
using Sendo.Seller.Client.V5.Api.Models.Authentication;

namespace Sendo.Seller.Client.V5.Api.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserContextDto, UserContext>();
            CreateMap<SendoMenuDto, SendoMenu>();
            CreateMap<StoreFunctionsDto, StoreFunctions>();
            CreateMap<StoreAccessDto, StoreAccess>();
        }
    }
}