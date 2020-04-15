using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities.Template
{
    public class Template
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, int> Mapping = new Dictionary<string, int>();

        //public Template()
        //{

        //}

        public string GetKeyByValue(int value)
        {
            return Mapping.FirstOrDefault(x => x.Value == value).Key;
        }
    }
}
