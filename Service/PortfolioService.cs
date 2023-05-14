using AutoMapper;
using Contracts.Repository;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.Portfolio;
using Shared.DataTransferObjects.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public PortfolioService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PortfolioDto> CreatePortfolioAsync(PortfolioForCreationDto portfolio)
        {
            var portfolioEntity = _mapper.Map<Portfolio>(portfolio);
            _repository.Portfolio.CreatePortfolio(portfolioEntity);
            await _repository.SaveAsync();
            var portfolioReturnEntity = _mapper.Map<PortfolioDto>(portfolioEntity);
            return portfolioReturnEntity;
        }

        public async Task<PortfolioDto> GetPortfolioAsync(int id, bool trackChanges)
        {
            var portfolio = await GetPortfolioByIdAsync(id, trackChanges);
            var portfolioDto = _mapper.Map<PortfolioDto>(portfolio);
            return portfolioDto;
        }
        private async Task<Portfolio> GetPortfolioByIdAsync(int id, bool trackChanges)
        {
            var portfolio = await _repository.Portfolio.GetPortfolioAsync(id, trackChanges);
            if (portfolio is null)
                throw new PortfolioNotFoundException(id);
            return portfolio;
        }
    }
}
