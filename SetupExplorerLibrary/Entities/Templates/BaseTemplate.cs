using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary
{
    public class BaseTemplate : Template
    {
        public List<Area> Areas = new List<Area>();

        public BaseTemplate()
        {
            Name = "Base Template";
        }
    }
}
