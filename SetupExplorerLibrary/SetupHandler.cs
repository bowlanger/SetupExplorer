using SetupExplorerLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary
{
    public class SetupHandler
    {
        private readonly SetupParser setupParser;
        private readonly Setup setup;
        private readonly string setupFile;

        private readonly ILogger logger;

        public SetupHandler(string setupFile, ILogger logger)
        {
            this.setupFile = setupFile;
            this.logger = logger;

            this.logger.Log("SetupHandler > _constructor");

            setupParser = new SetupParser(this.setupFile, this.logger);
            setup = new Setup(setupParser.GetSetupSummary(), this.logger);
        }

        public Setup GetSetup()
        {
            return this.setup;
        }
    }
}
