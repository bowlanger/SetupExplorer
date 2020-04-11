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
        public SetupSummary SetupSummary;

        private readonly ILogger logger;

        public Setup(SetupSummary setupSummary, ILogger logger)
        {
            this.logger = logger;
            this.logger.Log("Setup > _constructor");

            SetupSummary = setupSummary;
            logger.Log("Setup > SetupSummary.CarName : " + SetupSummary.CarName);
            logger.Log("Setup > SetupSummary.SetupName : " + SetupSummary.SetupName);
            logger.Log("Setup > SetupSummary.TrackName : " + SetupSummary.TrackName);
            logger.Log("Setup > SetupSummary.TrackCfg : " + SetupSummary.TrackCfg);
        }
    }
}
