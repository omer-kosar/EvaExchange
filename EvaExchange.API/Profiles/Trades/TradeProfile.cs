using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects.Share;
using Shared.DataTransferObjects.Trade;

namespace EvaExchange.API.Profiles.Trades
{
    public class TradeProfile:Profile
    {
        public TradeProfile()
        {
            CreateMap<TradeDto, Trade>();
        }
    }
}
