using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Application.DTO
{
    public class LotteryDetailsDTO
    {
        public LotteryDTO LotteryProperties { get; set; }
        public IEnumerable<LotteryUserDTO> UsersList { get; set; }

    }
}