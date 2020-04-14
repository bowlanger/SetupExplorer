using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities
{
    public class Template
    {
        public string Name { get; set; }
        public Dictionary<string, string> Mapping = new Dictionary<string, string>();

        public Template()
        {

        }

        public string GetKeyByValue(string value)
        {
            return Mapping.FirstOrDefault(x => x.Value == value).Key;
        }
    }
}
