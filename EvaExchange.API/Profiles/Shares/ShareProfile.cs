using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects.Share;

namespace EvaExchange.API.Profiles.Shares
{
    public class ShareProfile : Profile
    {
        public ShareProfile()
        {
            CreateMap<Share, ShareDto>();
            CreateMap<ShareForCreationDto, Share>();
            CreateMap<ShareForUpdateDto, Share>();
        }
    }
}
