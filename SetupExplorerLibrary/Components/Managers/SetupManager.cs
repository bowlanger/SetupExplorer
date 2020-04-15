using SetupExplorerLibrary.Entities;
using SetupExplorerLibrary.Interfaces;
using SetupExplorerLibrary.Components;
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
        private readonly ILogger logger;
        private List<Setup> Setups = new List<Setup>();

        public SetupManager(ILogger logger)
        {
            this.logger = logger;
            this.logger.Info($@"{this.GetType().Name} > _constructor(logger)");
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
