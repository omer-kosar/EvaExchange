using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects.Trade;

namespace EvaExchange.API.Profiles.Shares
{
    public class ShareInPortfolioProfile:Profile
    {
        public ShareInPortfolioProfile()
        {
            CreateMap<TradeDto, ShareInPortfolio>();
        }
    }
}
