using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace EvaExchange.API.Profiles
{
    public class SharePriceProfile:Profile
    {
        public SharePriceProfile()
        {
            CreateMap<SharePriceForCreationDto, SharePrice>();
        }
    }
}
