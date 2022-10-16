using Noa.PocketUi.Contract.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noa.PocketUi.Main.Services;

public interface IMqttService
{
    void ConfigureSOSCallback(Action<SOSCall> SOSCallback);
    Task SendSosAsync(Location location, string sector);
    Task ResetAndSubscribeAsync(List<string> sectors);

}
