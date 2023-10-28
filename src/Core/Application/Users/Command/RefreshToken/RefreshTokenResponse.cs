using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestTutorial.Application.Users.Command.RefreshToken
{
    public class RefreshTokenResponse
    {
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
    }
}
