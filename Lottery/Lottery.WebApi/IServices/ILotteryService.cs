using Lottery.WebApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lottery.WebApi.IServices
{
    public interface ILotteryService
    {
        Task<IEnumerable<LotteryDTO>> GetLotteries();
        Task<bool> AddLottery(LotteryDTO lottery);
        Task<bool> AddLotteryUserAndResponseResult(long userId, long lotteryId);
    }
}
