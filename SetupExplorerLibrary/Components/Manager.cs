using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Components
{
    public abstract class Manager
    {
        public abstract void Register(Object o);

        public abstract void Delete(Object o);
    }
}
