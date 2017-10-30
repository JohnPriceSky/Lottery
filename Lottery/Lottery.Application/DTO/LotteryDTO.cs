using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Application.DTO
{
    public class LotteryDTO
    {
        public int Id { get; set; }
        public string LotteryName { get; set; }
        public string Prize { get; set; }
        public DateTime DrowTime { get; set; }

    }
}
