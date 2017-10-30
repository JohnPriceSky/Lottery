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

        [HttpGet, Route("lottery")]
        public async Task<LotteryDetailsDTO> GetLotteryDetails([FromUri] long lotteryId)
        {
            return await _lotteryService.GetLottery(lotteryId);
        }

        [HttpPost, Route("addLottery")]
        public async Task<bool> AddLottery([FromBody] LotteryDTO lottery)
        {
            if (lottery == null)
                return false;

            return await _lotteryService.AddLottery(lottery);
        }

        [HttpDelete, Route("deleteLottery")]
        public async Task<bool> DeleteLottery([FromBody] long lotteryId)
        {
            if (lotteryId < 1)
                return false;

            return await _lotteryService.DeleteLottery(lotteryId);
        }

        [HttpPost, Route("signIn")]
        public async Task<bool> SignInToLottery([FromBody] SignInDTO signInData)
        {
            if (signInData.UserId < 1 && signInData.LotteryId < 1)
                return false;

            return await _lotteryService.AddLotteryUserAndResponseResult(signInData.UserId, signInData.LotteryId);
        }
    }
}
