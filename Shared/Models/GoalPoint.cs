using System;
using System.Collections.Generic;

namespace Happy.Shared.Models
{
    public partial class GoalPoint
    {
        public GoalPoint()
        {
            PointHistories = new HashSet<PointHistory>();
        }
        public Guid Guid { get; set; }
        public Guid GoalGuid { get; set; }
        public string Content { get; set; } = null!;
        public int Point { get; set; }

        public virtual Goal GoalGu { get; set; } = null!;
        public virtual ICollection<PointHistory> PointHistories { get; set; }

    }
}
