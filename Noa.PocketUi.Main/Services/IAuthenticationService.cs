using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noa.PocketUi.Main.Services;

public interface IAuthenticationService
{
    Guid GetUserId();
    bool IsAdmin();
    Task LoginAsync(string username, string password);
    Task RegisterAsync(string username, string password, string email);
}
