using AutoMapper;
using Contracts.Repository;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ShareService : IShareService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ShareService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ShareDto> CreateShareAsync(ShareForCreationDto share)
        {
            await CheckShareIfExistsWithTheSameSymbol(share.Symbol, false);
            var shareEntity = _mapper.Map<Share>(share);
            _repository.Share.CreateShareAsync(shareEntity);
            await _repository.SaveAsync();
            var shareReturnEntity = _mapper.Map<ShareDto>(shareEntity);
            return shareReturnEntity;
        }

        public async Task<ShareDto> GetShareAsync(int id, bool trackChanges)
        {
            var share = await GetShareByIdAsync(id, trackChanges);
            var shareDto = _mapper.Map<ShareDto>(share);
            return shareDto;
        }

        public async Task UpdateShareAsync(int id, ShareForUpdateDto share, bool trackChanges)
        {
            await CheckShareIfExists(id, trackChanges);
            //await CheckShareIfExistsWithTheSameSymbol(share.Symbol,trackChanges);
            var shareEntity = await GetShareByIdAsync(id, trackChanges);
            _mapper.Map(share, shareEntity);
            await _repository.SaveAsync();
        }
        public async Task CreateSharePriceAsync(SharePriceForCreationDto sharePrice)
        {
            await CheckShareIfExists(sharePrice.ShareId, false);
            var sharePriceEntity = _mapper.Map<SharePrice>(sharePrice);
            _repository.SharePrice.CreateSharePriceAsync(sharePriceEntity);
            await _repository.SaveAsync();
        }
        private async Task<Share> GetShareByIdAsync(int id, bool trackChanges)
        {
            var share = await _repository.Share.GetShareAsync(id, trackChanges);
            if (share is null)
                throw new ShareNotFoundException(id);
            return share;
        }
        private async Task CheckShareIfExistsWithTheSameSymbol(string symbol, bool trackChanges)
        {
            var shares = await _repository.Share.GetShareBySymbolAsync(symbol, trackChanges);
            if (shares.Any())
                throw new ShareExistWithTheSameSymbolBadRequestException();
        }
        private async Task CheckShareIfExists(int id, bool trackChanges)
        {
            var share = await GetShareByIdAsync(id, trackChanges);
            if (share is null)
                throw new ShareNotFoundException(id);
        }
    }
}
