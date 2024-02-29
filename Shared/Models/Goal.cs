using System;
using System.Collections.Generic;

namespace Happy.Shared.Models
{
    public partial class Goal
    {
        public Goal()
        {
            GoalPoints = new HashSet<GoalPoint>();
        }

        public Guid Guid { get; set; }
        public string Email { get; set; } = null!;
        public DateTime Date { get; set; }
        public int TargetYear { get; set; }
        public int TargetMonth { get; set; }

        public virtual Member EmailNavigation { get; set; } = null!;
        public virtual ICollection<GoalPoint> GoalPoints { get; set; }
    }
}
