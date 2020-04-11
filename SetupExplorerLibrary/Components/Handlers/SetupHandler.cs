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
        private readonly string setupFileName;

        private readonly ILogger logger;

        public SetupHandler(string setupFileName, ILogger logger)
        {
            this.logger = logger;
            this.logger.Log("SetupHandler > _constructor");

            this.setupFileName = setupFileName;

            // TODO: validate htm file format ?

            setupParser = new SetupParser(this.setupFileName, this.logger);
            setup = new Setup(setupParser.GetSetupSummary(), this.logger);
        }

        public Setup GetSetup()
        {
            return this.setup;
        }

        public string GetSetupFileName()
        {
            return this.setupFileName;
        }
    }
}
