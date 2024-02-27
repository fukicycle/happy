using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto.Response
{
    public class GoalPointResponseDto
    {
        public GoalPointResponseDto(Guid guid, string content, int point)
        {
            Guid = guid;
            Content = content;
            Point = point;
        }
        public Guid Guid { get; }
        public string Content { get; }
        public int Point { get; }
    }
}
