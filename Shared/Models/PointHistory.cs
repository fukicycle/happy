﻿using System;
using System.Collections.Generic;

namespace Shared.Models
{
    public partial class PointHistory
    {
        public Guid Guid { get; set; }
        public string Email { get; set; } = null!;
        public DateTime Date { get; set; }
        public int Point { get; set; }
    }
}
