using System;
using System.Collections.Generic;

namespace Shared.Models
{
    public partial class Member
    {
        public Member()
        {
            Goals = new HashSet<Goal>();
            PointHistories = new HashSet<PointHistory>();
            TeamMembers = new HashSet<TeamMember>();
        }

        public string Email { get; set; } = null!;
        public string DisplayName { get; set; } = null!;

        public virtual ICollection<Goal> Goals { get; set; }
        public virtual ICollection<PointHistory> PointHistories { get; set; }
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}
