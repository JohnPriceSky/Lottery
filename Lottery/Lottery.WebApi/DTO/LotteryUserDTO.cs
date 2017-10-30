using Newtonsoft.Json;

namespace Lottery.WebApi.DTO
{
    [JsonObject(NamingStrategyType = typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public class LotteryUserDTO
    {
        public string UserName { get; set; }
        public bool IsWinner { get; set; }
    }
}