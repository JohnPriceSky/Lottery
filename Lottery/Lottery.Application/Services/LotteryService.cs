using Lottery.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Application.DTO;
using Newtonsoft.Json;
using System.Net.Http;

namespace Lottery.Application.Services
{
    public class LotteryService : ILotteryService
    {
        public async Task<bool> AddLottery(LotteryDTO lottery)
        {
            using (var httpClient = new HttpClient())
            {
                var uri = $"http://localhost:52574/addLottery";

                var dict = new Dictionary<string, string>
                {
                    {"lotteryName", lottery.LotteryName },
                    {"prize", lottery.Prize },
                    {"drowTime", lottery.DrowTime.ToString() }
                };
                var content = new FormUrlEncodedContent(dict);

                var response = await(await httpClient.PostAsync(uri, content)).Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<bool>(response);
                return result;
            }
        }

        public async Task<bool> DeleteLottery(long id)
        {
            using (var httpClient = new HttpClient())
            {
                var uri = $"http://localhost:52574/deleteLottery";
                
                var content = new StringContent(id.ToString(), Encoding.Unicode, "application/json");

                var response = await (await httpClient.PostAsync(uri, content)).Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<bool>(response);
                return result;
            }
        }
        public async Task<LotteryDetailsDTO> GetLotteryDetails(long id)
        {
            using (var httpClient = new HttpClient())
            {
                var uri = $"http://localhost:52574/lottery";
                var response = await (await httpClient.GetAsync(uri + "/?lotteryId=" + id.ToString())).Content.ReadAsStringAsync();
                var details = JsonConvert.DeserializeObject<LotteryDetailsDTO>(response);
                return details;
            }
        }

        public async Task<IEnumerable<LotteryDTO>> GetLotteries()
        {
            using (var httpClient = new HttpClient())
            {
                var uri = $"http://localhost:52574/lotteries";
                var response = await(await httpClient.GetAsync(uri)).Content.ReadAsStringAsync();
                var lotteries = JsonConvert.DeserializeObject<IEnumerable<LotteryDTO>>(response);
                return lotteries;
            }
        }

        public async  Task<bool> SignInToLottery(long userId, long lotteryId)
        {
            using (var httpClient = new HttpClient())
            {
                var uri = $"http://localhost:52574/signIn";

                var dict = new Dictionary<string, string>
                {
                    {"userId", userId.ToString() },
                    {"lotteryId", lotteryId.ToString() }
                };
                var content = new FormUrlEncodedContent(dict);
                var response = await(await httpClient.PostAsync(uri, content)).Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<bool>(response);
                return result;
            }
        }
    }
}