using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Shared.ValueObjects
{
    public sealed class Point
    {
        private readonly string UnitName = "pt";
        public Point(int value)
        {
            Value = value;
            DisplayText = $"{value}{UnitName}";
        }
        public int Value { get; }
        public string DisplayText { get; }
    }
}
