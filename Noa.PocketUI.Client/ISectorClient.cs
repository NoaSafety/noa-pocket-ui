using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noa.PocketUI.Client;

public interface ISectorClient
{
    public Task<string> GetSectorAsync(double lat, double lng);

    public Task<List<string>> GetSectorAreaAsync(double lat, double lng);
}
