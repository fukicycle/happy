using Happy.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Shared.Dto.Response
{
    public sealed class UserPointResponseDto
    {
        public UserPointResponseDto(int yesterdayPoint, int totalPoint)
        {
            YesterdayPoint = yesterdayPoint;
            TotalPoint = totalPoint;

        }
        public int YesterdayPoint { get; }
        public int TotalPoint { get; }
    }
}
