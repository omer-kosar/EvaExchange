using Shared.DataTransferObjects.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IShareService
    {
        Task<ShareDto> CreateShareAsync(ShareForCreationDto company);
        Task<ShareDto> GetShareAsync(int id, bool trackChanges);
        Task UpdateShareAsync(int id, ShareForUpdateDto share, bool trackChanges);
    }
}
