using Lottery.WebApi.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lottery.WebApi.DTO;
using System.Threading.Tasks;
using Lottery.WebApi.Models;
using Microsoft.AspNet.SignalR;
using Lottery.WebApi.Hubs;
using Hangfire;

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

        public async Task<LotteryDetailsDTO> GetLottery(long lotteryId)
        {
            var lottery = _lotteryEntities.Lottery.AsNoTracking()
                .Select(l => new LotteryDTO
                {
                    Id = l.Id,
                    LotteryName = l.LotteryName,
                    Prize = l.Prize,
                    DrowTime = l.DrowTime
                })
                .FirstOrDefault(l => l.Id == lotteryId);

            var lotteryUsers = _lotteryEntities.LotteryUser.AsNoTracking()
                .Where(lu => lu.LotteryId == lotteryId);

            var users = _lotteryEntities.User.AsNoTracking()
                .Join(lotteryUsers,
                u => u.Id,
                lu => lu.UserId,
                (u, lu) => new LotteryUserDTO
                {
                    UserName = u.UserName,
                    IsWinner = lu.IsWinner
                })
                .ToList();

            return new LotteryDetailsDTO
            {
                LotteryProperties = lottery,
                UsersList = users
            };
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
                _lotteryEntities.SaveChanges();

                var jobId = BackgroundJob.Schedule(
                    methodCall: () => Jobs.DrowWinner(newLottery.Id),
                    delay: lottery.DrowTime - DateTime.Now);
            }

            return false;
        }

        public async Task<bool> DeleteLottery(long lotteryId)
        {
            var lottery = _lotteryEntities.Lottery.FirstOrDefault(l => l.Id == lotteryId);

            _lotteryEntities.Lottery.Remove(lottery);
            await _lotteryEntities.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddLotteryUserAndResponseResult(long userId, long lotteryId)
        {
            if (_lotteryEntities.LotteryUser.AsNoTracking().Any(lu => lu.UserId == userId && lu.LotteryId == lotteryId))
                return false;

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

    static class Jobs
    {
        public static void DrowWinner(long lotteryId)
        {
            List<long> users;

            using (var context = new LotteryEntities())
            {
                users = context.LotteryUser.AsNoTracking()
                    .Where(lu => lu.LotteryId == lotteryId)
                    .Select(lu => lu.User)
                    .Select(u => u.Id)
                    .ToList();
            }

            if (users.Count < 1)
                return;

            var random = new Random();
            var randomNumber = random.Next(0, users.Count);

            var winnerId = users[randomNumber];

            string winnerName;

            using (var context = new LotteryEntities())
            {
                var winner = context.LotteryUser
                    .FirstOrDefault(lu => lu.LotteryId == lotteryId && lu.UserId == winnerId);

                winner.IsWinner = true;

                winnerName = winner.User.UserName;

                context.SaveChanges();
            }

            var notificationHubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            notificationHubContext.Clients.All.Notification($"{winnerName} has won lottery!!!");
        }
    }
}