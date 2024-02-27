using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto.Request
{
    public class LoginRequestDto
    {
        public LoginRequestDto(string email)
        {
            Email = email;
        }

        public string Email { get; }
    }
}
