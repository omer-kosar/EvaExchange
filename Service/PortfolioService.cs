using AutoMapper;
using Contracts.Repository;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.Portfolio;
using Shared.DataTransferObjects.Share;
using Shared.DataTransferObjects.Trade;
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
            _repository.Portfolio.CreatePortfolioAsync(portfolioEntity);
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
        public async Task<ShareSummaryForTradeDto> BuyShare(TradeDto trade, bool trackChanges)
        {
            await CheckIfPortfolioExist(trade.PortfolioId, trackChanges);
            await CheckIfShareExist(trade.ShareId, trackChanges);
            bool isShareInPortfolio = await CheckIfShareInPortfolio(trade.PortfolioId, trade.ShareId, trackChanges);
            if (!isShareInPortfolio)
                AddShareToPortfolio(trade);
            var latestSharePrice = await GetLatestSharePriceAsync(trade.ShareId, trackChanges);
            var tradeEntity = _mapper.Map<Trade>(trade);
            tradeEntity.TradePrice = latestSharePrice.Price;
            _repository.Trade.CreateTradeAsync(tradeEntity);
            await _repository.SaveAsync();
            //map trade summary
            return new ShareSummaryForTradeDto();
        }
        private async Task<bool> CheckIfShareInPortfolio(int portfolioId, int shareId, bool trackChanges)
        {
            var shareInPortfolio = await GetShareInPortfolioByShareId(portfolioId, shareId, trackChanges);
            return shareInPortfolio != null;
        }
        private void AddShareToPortfolio(TradeDto trade)
        {
            var shareInPortfolioEntity = _mapper.Map<ShareInPortfolio>(trade);
            _repository.ShareInPortfolioRepository.CreateShareInPortfolioAsync(shareInPortfolioEntity);
        }
        private async Task<ShareInPortfolio> GetShareInPortfolioByShareId(int portfolioId, int shareId, bool trackChanges)
        {
            return await _repository.ShareInPortfolioRepository.GetShareInPortfolioByShareIdAsync(portfolioId, shareId, trackChanges);
        }
        private async Task<Portfolio> GetPortfolioByIdAsync(int id, bool trackChanges)
        {
            var portfolio = await _repository.Portfolio.GetPortfolioAsync(id, trackChanges);
            if (portfolio is null)
                throw new PortfolioNotFoundException(id);
            return portfolio;
        }

        private async Task CheckIfPortfolioExist(int id, bool trackChanges)
        {
            var portfolio = await GetPortfolioByIdAsync(id, trackChanges);
            if (portfolio is null)
                throw new PortfolioNotFoundException(id);
        }
        private async Task CheckIfShareExist(int shareId, bool trackChanges)
        {
            var share = await GetShareByIdAsync(shareId, trackChanges);
            if (share is null)
                throw new ShareNotFoundException(shareId);
        }

        private async Task<Share> GetShareByIdAsync(int id, bool trackChanges)
        {
            var share = await _repository.Share.GetShareAsync(id, trackChanges);
            if (share is null)
                throw new ShareNotFoundException(id);
            return share;
        }
        private async Task<SharePrice> GetLatestSharePriceAsync(int shareId, bool trackChanges)
        {
            var sharePrice = await _repository.SharePrice.GetLatestSharePriceByShareIdAsync(shareId, trackChanges);
            return sharePrice;
        }
    }
}
