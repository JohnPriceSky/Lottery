using Newtonsoft.Json;
using System;

namespace Lottery.WebApi.DTO
{
    [JsonObject(NamingStrategyType = typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public class LotteryDTO
    {
        public long Id { get; set; }
        public string LotteryName { get; set; }
        public string Prize { get; set; }
        public DateTime DrowTime { get; set; }
    }
}