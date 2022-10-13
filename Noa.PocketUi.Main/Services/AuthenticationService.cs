using Noa.PocketUi.Contract.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noa.PocketUi.Main.Services;

public class AuthenticationService : IAuthenticationService
{
    private Guid UserId { get; set; }
    private string Token { get; set; }

    public AuthenticationService()
    {
        // TODO: Implement login call in login page
        UserId = Guid.NewGuid();
        Token = Guid.NewGuid().ToString();
    }

    public Guid GetUserId() => UserId;

    public async Task LoginAsync(string username, string password)
    {
        // TODO: Send an actual request
        var response = new Credentials()
        {
            UserId = Guid.NewGuid(),
            Token = Guid.NewGuid().ToString(),
        };

        UserId = response.UserId;
        Token = response.Token;
    }
}
