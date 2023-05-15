using AutoMapper;
using Contracts.Repository;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.Portfolio;
using Shared.DataTransferObjects.Share;
using Shared.DataTransferObjects.Trade;
using Shared.Enums;
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
            await CheckIfUserExist(portfolio.UserId, false);
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
        public async Task BuyShare(TradeDto trade, bool trackChanges)
        {
            await CheckIfPortfolioExist(trade.PortfolioId, trackChanges);
            await CheckIfShareExist(trade.ShareId, trackChanges);
            bool isShareInPortfolio = await CheckIfShareInPortfolio(trade.PortfolioId, trade.ShareId, trackChanges);
            if (!isShareInPortfolio)
                AddShareToPortfolio(trade);
            var tradeEntity = await GetTradeEntityFromTradeDto(trade, trackChanges);
            _repository.Trade.CreateTradeAsync(tradeEntity);
            await _repository.SaveAsync();
        }

        public async Task SellShare(TradeDto trade, bool trackChanges)
        {
            await CheckIfPortfolioExist(trade.PortfolioId, trackChanges);
            await CheckIfShareExist(trade.ShareId, trackChanges);
            await CheckIfShareExistInPortfolio(trade.PortfolioId, trade.ShareId, trackChanges);
            var shareSummary = await GetShareSummary(trade.UserId, trade.ShareId, trackChanges);
            if (shareSummary is null)
                throw new ShareNotFoundInTradeException(trade.ShareId);
            bool isShareAvailableForSelling = shareSummary.AvailableQuantityForSell >= trade.Quantity;
            if (!isShareAvailableForSelling)
                throw new AvailabeShareDoesNotExistForSellingBadRequest();
            var tradeEntity = await GetTradeEntityFromTradeDto(trade, trackChanges);
            _repository.Trade.CreateTradeAsync(tradeEntity);
            bool isShareStillExistForSelling = shareSummary.AvailableQuantityForSell > trade.Quantity;
            if (!isShareStillExistForSelling)
            {
                var shareInPortfolio = await GetShareInPortfolioByShareId(trade.PortfolioId, trade.ShareId, trackChanges);
                _repository.ShareInPortfolioRepository.DeleteShareInPortfolio(shareInPortfolio);
            }
            await _repository.SaveAsync();
        }
        private async Task<Trade> GetTradeEntityFromTradeDto(TradeDto trade, bool trackChanges)
        {
            var latestSharePrice = await GetLatestSharePriceAsync(trade.ShareId, trackChanges);
            var tradeEntity = _mapper.Map<Trade>(trade);
            tradeEntity.TradePrice = latestSharePrice.Price;
            return tradeEntity;
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

        private async Task CheckIfShareExistInPortfolio(int portfolioId, int shareId, bool trackChanges)
        {
            var shareInPortfolio = await _repository.ShareInPortfolioRepository.GetShareInPortfolioByShareIdAsync(portfolioId, shareId, trackChanges);
            if (shareInPortfolio is null)
                throw new ShareNotFoundInPortfolioException(portfolioId, shareId);
        }
        private async Task CheckIfUserExist(int userId, bool trackChanges)
        {
            var user = _repository.Users.GetUserAsync(userId, trackChanges);
            if (user is null)
                throw new UserNotFoundException(userId);
        }

        private async Task<ShareSummaryForTradeDto> GetShareSummary(int userId, int shareId, bool trackChanges)
        {
            var shareSummary = await _repository.Trade.GetShareSummaryForTradeSelling(userId, shareId, trackChanges);
            return shareSummary;
        }
    }
}
