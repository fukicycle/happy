using System;
using System.Collections.Generic;

namespace Happy.Shared.Models
{
    public partial class PointHistory
    {
        public Guid Guid { get; set; }
        public string Email { get; set; } = null!;
        public DateTime Date { get; set; }
        public Guid GoalPointGuid { get; set; }

        public virtual Member EmailNavigation { get; set; } = null!;
        public virtual GoalPoint GoalPointGu { get; set; } = null!;
    }
}
