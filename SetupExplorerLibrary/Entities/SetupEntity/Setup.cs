using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetupExplorerLibrary.Entities.TemplateEntity;
using SetupExplorerLibrary.Interfaces;

namespace SetupExplorerLibrary.Entities.SetupEntity
{
    public class Setup
    {
        public string FileName { get; set; } = "";
        public Summary Summary { get; set; } = new Summary();
        public List<Property> Properties { get; set; } = new List<Property>();
        public List<string> Notes { get; set; } = new List<string>();
        public Template Template { get; internal set; }

        public Setup(string fileName)
        {
            FileName = fileName;
        }
    }
}
