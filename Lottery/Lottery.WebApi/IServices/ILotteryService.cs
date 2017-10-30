using Lottery.WebApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lottery.WebApi.IServices
{
    public interface ILotteryService
    {
        Task<IEnumerable<LotteryDTO>> GetLotteries();
        Task<LotteryDetailsDTO> GetLottery(long lotteryId);
        Task<bool> AddLottery(LotteryDTO lottery);
        Task<bool> DeleteLottery(long lotteryId);
        Task<bool> AddLotteryUserAndResponseResult(long userId, long lotteryId);
    }
}
