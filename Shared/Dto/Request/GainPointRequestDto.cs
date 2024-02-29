using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto.Request
{
    public class GainPointRequestDto
    {
        public GainPointRequestDto(string email, int point)
        {
            Email = email;
            Point = point;
        }
        public string Email { get; }
        public int Point { get; }
    }
}
