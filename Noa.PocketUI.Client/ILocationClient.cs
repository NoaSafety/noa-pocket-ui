using Noa.PocketUi.Contract.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noa.PocketUI.Client
{
    public interface ILocationClient
    {
        Task<List<SOSCall>> GetNearSOSCalls();
    }
}
