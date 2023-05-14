using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects.Share;

namespace EvaExchange.API.Profiles.Shares
{
    public class SharePriceProfile : Profile
    {
        public SharePriceProfile()
        {
            CreateMap<SharePriceForCreationDto, SharePrice>();
        }
    }
}
