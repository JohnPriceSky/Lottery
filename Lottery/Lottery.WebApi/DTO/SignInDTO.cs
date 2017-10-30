using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lottery.WebApi.DTO
{
    public class SignInDTO
    {
        public long UserId { get; set; }
        public long LotteryId { get; set; }
    }
}