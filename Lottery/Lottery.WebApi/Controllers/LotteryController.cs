using Lottery.WebApi.DTO;
using Lottery.WebApi.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Lottery.WebApi.Controllers
{
    public class LotteryController : ApiController
    {
        private readonly ILotteryService _lotteryService;

        public LotteryController(ILotteryService lotteryService)
        {
            _lotteryService = lotteryService;
        }

        [HttpGet, Route("lotteries")]
        public async Task<IEnumerable<LotteryDTO>> GetLotteries()
        {
            return await _lotteryService.GetLotteries();
        }

        [HttpPost, Route("addLottery")]
        public async Task<bool> AddLottery([FromBody] LotteryDTO lottery)
        {
            if (lottery == null)
                return false;

            return await _lotteryService.AddLottery(lottery);
        }

        [HttpPost, Route("signIn")]
        public async Task<bool> SignInToLottery([FromBody]long userId, [FromBody]long lotteryId)
        {
            if (userId < 1 && lotteryId < 1)
                return false;

            return await _lotteryService.AddLotteryUserAndResponseResult(userId, lotteryId);
        }
    }
}
