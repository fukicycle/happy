using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Shared.Dto.Request
{
    public class GainPointRequestDto
    {
        public GainPointRequestDto(Guid goalPointGuid)
        {
            GoalPointGuid = goalPointGuid;
        }

        public Guid GoalPointGuid { get; }
    }
}
