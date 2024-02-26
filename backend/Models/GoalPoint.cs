using System;
using System.Collections.Generic;

namespace backend.Models
{
    public partial class GoalPoint
    {
        public Guid Guid { get; set; }
        public Guid GoalGuid { get; set; }
        public string Content { get; set; } = null!;
        public int Point { get; set; }

        public virtual Goal GoalGu { get; set; } = null!;
    }
}
