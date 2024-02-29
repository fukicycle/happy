using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Shared
{
    public static class ApplicationSettings
    {
        public static ApplicationMode Mode = ApplicationMode.Dev;
        public static byte[] JWT_KEY = new byte[64];
    }
}
