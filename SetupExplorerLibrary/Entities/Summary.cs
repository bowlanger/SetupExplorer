using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetupExplorerLibrary.Interfaces;

namespace SetupExplorerLibrary.Entities
{
    public class Summary
    {
        public string CarName { get; set; } = "";
        public string SetupName { get; set; } = "";
        public string ExportTrackName { get; set; } = "";

        public Summary()
        {
        }

        public Summary(string carName, string setupName, string exportTrackName)
        {
            CarName = carName;
            SetupName = setupName;
            ExportTrackName = exportTrackName;
        }

    }
}
