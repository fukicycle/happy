using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto.Response
{
    public class LoginResponseDto
    {
        public LoginResponseDto(string token)
        {
            Token = token;
        }
        public string Token { get; }
    }
}
