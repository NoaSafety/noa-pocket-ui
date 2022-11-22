using Noa.PocketUi.Contract.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noa.PocketUI.Client
{
    public interface IAuthenticationClient
    {
        public Task<SessionToken> LoginAsync(string username, string password);

        public Task<SessionToken> RegisterAsync(string username, string password, string email);
    }
}
