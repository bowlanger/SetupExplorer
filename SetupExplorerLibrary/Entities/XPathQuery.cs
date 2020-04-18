using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities
{
    public class XPathQuery
    {
        public string Name { get; set; }
        public string Query { get; set; }
        public string Template { get; set; }
        public string[] Parameters;

        public XPathQuery(string name, string template)
        {
            Name = name;
            Template = template;
        }

        public string BindParameters(string[] parameters)
        {
            Parameters = parameters;
            // do the magic here
            Query = string.Format(Template, Parameters);

            return Query;
        }
    }
}
