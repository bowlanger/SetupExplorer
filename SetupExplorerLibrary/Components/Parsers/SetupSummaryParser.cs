using HtmlAgilityPack;
using SetupExplorerLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary
{
    public class SetupSummaryParser
    {
        private readonly HtmlNode setupSummary;
        private readonly string carsetupLine; // ie : "mx5 mx52016 setup: baseline_19S3"
        private readonly string trackfullnameLine; // ie : "track: daytona road"

        private readonly ILogger logger;

        public SetupSummaryParser(HtmlNode setupSummary, ILogger logger)
        {
            this.logger = logger;
            this.logger.Log("SetupSummaryParser > _constructor");

            this.setupSummary = setupSummary;

            // extract car-setup and trackname-trackcfg strings from html node
            carsetupLine = this.setupSummary.ChildNodes[2].InnerText.Trim();
            trackfullnameLine = this.setupSummary.ChildNodes[4].InnerText.Trim();

            // get substring from trackLine starting at ":" and offset by +2 (": ") to the actual beginning of the track name.
            trackfullnameLine = trackfullnameLine.Substring(trackfullnameLine.IndexOf(":") + 2);
        }

        public string GetCarName()
        {
            // get beginning substring from carsetupLine until ":" and get rid of trailing string "setup".
            return carsetupLine.Substring(0, carsetupLine.IndexOf(":") - 5);
        }

        public string GetSetupName()
        {
            // get ending substring from carsetupLine starting at ":" and offset by +2 (": ") to the actual beginning of the setup name.
            return carsetupLine.Substring(carsetupLine.IndexOf(":") + 2);
        }

        public string GetTrackName()
        {
            // get beginning substring from trackfullname starting at first space
            return trackfullnameLine.Substring(0, trackfullnameLine.IndexOf(" "));
        }

        public string GetTrackCfg()
        {
            // get ending substring from trackfullname starting at first space and offset by +1 (" ") to the actual beginning of the track cfg.
            return trackfullnameLine.Substring(trackfullnameLine.IndexOf(" ") + 1);
        }
    }
}
