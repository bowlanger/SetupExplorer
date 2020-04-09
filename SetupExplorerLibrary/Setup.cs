using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetupExplorerLibrary.Interfaces;

namespace SetupExplorerLibrary
{
    public class Setup
    {
        public string SetupFile { get; set; }
        public SetupSummary SetupSummary;

        private readonly SetupParser setupParser;

        private readonly ILogger logger;

        public Setup(string SetupFile, ILogger logger)
        {
            this.SetupFile = SetupFile;
            this.logger = logger;
            this.logger.Log("Setup > _constructor");

            setupParser = new SetupParser(this.SetupFile, logger);

            SetupSummary = setupParser.GetSetupSummary();
            logger.Log("Setup > SetupSummary.CarName : " + SetupSummary.CarName);
            logger.Log("Setup > SetupSummary.SetupName : " + SetupSummary.SetupName);
            logger.Log("Setup > SetupSummary.TrackName : " + SetupSummary.TrackName);
            logger.Log("Setup > SetupSummary.TrackCfg : " + SetupSummary.TrackCfg);
        }
    }
}
