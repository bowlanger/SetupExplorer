using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetupExplorerLibrary.Interfaces;

namespace SetupExplorerLibrary.Entities
{
    public class Setup
    {
        private readonly ILogger logger;

        public string FileName { get; set; }
        public Summary Summary { get; set; }

        public List<Property> Properties { get; set; } = new List<Property>();

        public Setup(string fileName)
        {
            FileName = fileName;
            Summary = new Summary();
        }
    }
}
