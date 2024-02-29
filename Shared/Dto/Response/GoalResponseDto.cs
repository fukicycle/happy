using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Shared.Dto.Response
{
    public class GoalResponseDto
    {
        public GoalResponseDto(Guid guid, string email, int targetYear, int targetMonth)
        {
            Guid = guid;
            Email = email;
            TargetYearMonth = $"{targetYear:0000}年{targetMonth:00}月";
        }
        public Guid Guid { get; }
        public string Email { get; }
        public string TargetYearMonth { get; set; }
    }
}
