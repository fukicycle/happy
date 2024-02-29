using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Shared.Dto.Request
{
    public class GainPointRequestDto
    {
        public GainPointRequestDto(int point)
        {
            Point = point;
        }
        public int Point { get; }
    }
}
