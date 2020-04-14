using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetupExplorerApp.Interfaces;

namespace SetupExplorerApp.Entities
{
    public class Summary
    {
        public string CarName { get; set; }
        public string SetupName { get; set; }
        public string TrackName { get; set; }
        public string TrackCfg { get; set; }

        private readonly ILogger logger;

        public Summary(ILogger logger)
        {
            this.logger = logger;
            this.logger.Log("SetupSummary > _constructor #1");
        }

        public Summary(string carName, string setupName, string trackName, string trackCfg, ILogger logger)
        {
            this.logger = logger;
            this.logger.Log("SetupSummary > _constructor #2");

            this.CarName = carName;
            this.SetupName = setupName;
            this.TrackName = trackName;
            this.TrackCfg = trackCfg;
        }

    }
}
