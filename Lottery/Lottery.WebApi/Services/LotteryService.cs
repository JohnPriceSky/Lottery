using Lottery.WebApi.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lottery.WebApi.DTO;
using System.Threading.Tasks;
using Lottery.WebApi.Models;

namespace Lottery.WebApi.Services
{
    public class LotteryService : ILotteryService
    {
        private readonly LotteryEntities _lotteryEntities;

        public LotteryService(LotteryEntities lotteryEntities)
        {
            _lotteryEntities = lotteryEntities;
        }

        public async Task<IEnumerable<LotteryDTO>> GetLotteries()
        {
            return GetLotteriesFromDB();
        }

        public async Task<bool> AddLottery(LotteryDTO lottery)
        {
            if(!string.IsNullOrEmpty(lottery.LotteryName) && !string.IsNullOrEmpty(lottery.Prize))
            {
                var newLottery = new Models.Lottery
                {
                    LotteryName = lottery.LotteryName,
                    Prize = lottery.Prize,
                    DrowTime = lottery.DrowTime
                };

                _lotteryEntities.Lottery.Add(newLottery);
                await _lotteryEntities.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> AddLotteryUserAndResponseResult(long userId, long lotteryId)
        {
            var lotteryUser = new LotteryUser
            {
                UserId = userId,
                LotteryId = lotteryId,
            };

            _lotteryEntities.LotteryUser.Add(lotteryUser);
            await _lotteryEntities.SaveChangesAsync();

            return true;
        }

        private IEnumerable<LotteryDTO> GetLotteriesFromDB()
        {
            return _lotteryEntities.Lottery.AsNoTracking()
                .Select(l => new LotteryDTO
                {
                    Id = l.Id,
                    LotteryName = l.LotteryName,
                    Prize = l.Prize,
                    DrowTime = l.DrowTime
                });
        }
    }
}