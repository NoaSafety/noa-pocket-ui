using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noa.PocketUi.Contract.Authentication;

public class Credentials
{
    public Guid UserId { get; set; }
    public string Token { get; set; }
}
