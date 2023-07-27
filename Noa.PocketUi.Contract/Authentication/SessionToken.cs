using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Noa.PocketUi.Contract.Authentication;

public class SessionToken
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime Expiration { get; set; }
}
