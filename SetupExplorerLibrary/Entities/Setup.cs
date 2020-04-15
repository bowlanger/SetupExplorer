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
        public string FileName { get; set; } = "";
        public SetupSummary Summary { get; set; } = new SetupSummary();

        public List<Property> Properties { get; set; } = new List<Property>();

        public string Notes { get; set; } = "";

        public Setup(string fileName)
        {
            FileName = fileName;
            Summary = new SetupSummary();
        }
    }
}
