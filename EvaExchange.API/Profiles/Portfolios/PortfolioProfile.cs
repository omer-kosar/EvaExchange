using AutoMapper;
using Shared.DataTransferObjects.Portfolio;
using Entities.Models;

namespace EvaExchange.API.Profiles.Portfolios
{
    public class PortfolioProfile:Profile
    {
        public PortfolioProfile()
        {
            CreateMap<Portfolio, PortfolioDto>();
            CreateMap<PortfolioForCreationDto, Portfolio>();
        }
    }
}
