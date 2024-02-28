using System;
using System.Collections.Generic;

namespace Shared.Models
{
    public partial class TeamMember
    {
        public Guid Guid { get; set; }
        public Guid TeamGuid { get; set; }
        public string Email { get; set; } = null!;

        public virtual Member EmailNavigation { get; set; } = null!;
        public virtual Team TeamGu { get; set; } = null!;
    }
}
