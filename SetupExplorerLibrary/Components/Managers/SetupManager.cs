using SetupExplorerLibrary.Entities.Setup;
using SetupExplorerLibrary.Enum;
using SetupExplorerLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Components.Managers
{
    public class SetupManager : Manager
    {
        private readonly ILogger _logger;
        private List<Setup> Setups = new List<Setup>();

        public SetupManager(ILogger logger)
        {
            _logger = logger;
            _logger.Log(ELogLevel.Debug, $@"{this.GetType().Name} > Constructor(logger)");
        }

        public override void Register(Object setup)
        {
            Setups.Add((Setup)setup);
        }

        public override void Delete(Object setup)
        {
            Setups.Remove((Setup)setup);
        }
    }
}
