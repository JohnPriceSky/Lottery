using Lottery.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Application.Abstract
{
    public interface ILotteryService
    {
        Task<IEnumerable<LotteryDTO>> GetLotteries();
        Task<bool> AddLottery(LotteryDTO lottery);

    }
}
