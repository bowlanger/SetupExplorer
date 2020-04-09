using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetupExplorerLibrary.Interfaces;

namespace SetupExplorerLibrary
{
    public class SetupSummary
    {
        public string CarName { get; set; }
        public string SetupName { get; set; }
        public string TrackName { get; set; }
        public string TrackCfg { get; set; }

        private readonly ILogger logger;

        public SetupSummary(ILogger logger)
        {
            this.logger = logger;
            this.logger.Log("SetupSummary > _constructor #1");
        }

        public SetupSummary(string carname, string setupname, string trackname, string trackcfg, ILogger logger)
        {
            this.logger = logger;
            this.logger.Log("SetupSummary > _constructor #2");

            this.CarName = carname;
            this.SetupName = setupname;
            this.TrackName = trackname;
            this.TrackCfg = trackcfg;
        }

    }
}
