using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetupExplorerApp.Interfaces;

namespace SetupExplorerApp.Entities
{
    public class Setup
    {
        private readonly ILogger logger;

        public string FileName { get; set; }
        public Summary Summary { get; set; }
        public List<Property> Properties { get; set; } = new List<Property>();

        public Setup()
        {

        }
        public Setup(ILogger logger)
        {
            this.logger = logger;
            this.logger.Log("Setup > _constructor(logger)");

            FileName = "";
        }
    }
}
