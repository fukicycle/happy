using System;
using System.Collections.Generic;

namespace Shared.Models
{
    public partial class Team
    {
        public Team()
        {
            TeamMembers = new HashSet<TeamMember>();
        }

        public Guid Guid { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Date { get; set; }

        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}
