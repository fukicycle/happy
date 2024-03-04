using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Shared.Dto.Response
{
    public class GoalPointResponseDto
    {
        public GoalPointResponseDto(Guid guid, string content, Guid goalPointGuid, int point, bool isDone)
        {
            Guid = guid;
            Content = content;
            GoalPointGuid = goalPointGuid;
            Point = point;
            IsDone = isDone;
        }
        public Guid Guid { get; }
        public string Content { get; }
        public Guid GoalPointGuid { get; }
        public int Point { get; }
        public bool IsDone { get; }
    }
}
