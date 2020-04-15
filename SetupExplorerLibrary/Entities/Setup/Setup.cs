using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetupExplorerLibrary.Interfaces;

namespace SetupExplorerLibrary.Entities.Setup
{
    public class Setup
    {
        public string FileName { get; set; } = "";
        public Summary Summary { get; set; } = new Summary();
        public List<Property> Properties { get; set; } = new List<Property>();
        public List<string> Notes { get; set; } = new List<string>();

        public Setup(string fileName)
        {
            FileName = fileName;
        }
    }
}
