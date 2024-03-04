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
            YesterdayPoint = new Point(yesterdayPoint);
            TotalPoint = new Point(totalPoint);

        }
        public Point YesterdayPoint { get; }
        public Point TotalPoint { get; }
    }
}
