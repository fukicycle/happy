using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Shared.Dto.Response
{
    public class GoalPointResponseDto
    {
        public GoalPointResponseDto(Guid guid, string content, int point, bool isDone)
        {
            Guid = guid;
            Content = content;
            Point = point;
            IsDone = isDone;
        }
        public Guid Guid { get; }
        public string Content { get; }
        public int Point { get; }
        public bool IsDone { get; }
    }
}
