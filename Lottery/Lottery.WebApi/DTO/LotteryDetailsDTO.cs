using Newtonsoft.Json;
using System.Collections.Generic;

namespace Lottery.WebApi.DTO
{
    [JsonObject(NamingStrategyType = typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public class LotteryDetailsDTO
    {
        public LotteryDTO LotteryProperties { get; set; }
        public IEnumerable<LotteryUserDTO> UsersList { get; set; }
    }
}