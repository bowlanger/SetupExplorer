using SetupExplorerLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerUI.Configuration
{
    // n'est plus utilisée puisque nous avons implémenté l'Action<IConfigLibrary>
    public class ConfigLibrary : IConfigLibrary
    {
        public bool Debug { get; set; }
        public string OutputFolder { get; set; }
        public string BaseFolder { get; set; }
    }
}
