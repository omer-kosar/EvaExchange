using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace EvaExchange.API.Profiles
{
    public class ShareProfile :Profile
    {
        public ShareProfile()
        {
            CreateMap<Share, ShareDto>();
            CreateMap<ShareForCreationDto, Share>();
            CreateMap<ShareForUpdateDto, Share>();
        }
    }
}
