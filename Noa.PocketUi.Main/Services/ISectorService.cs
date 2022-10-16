using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noa.PocketUi.Main.Services;

public interface ISectorService
{
    public string GetSector();

    public List<string> GetSectorArea();
}
