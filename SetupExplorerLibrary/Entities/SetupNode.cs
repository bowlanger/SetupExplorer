using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities
{
    public class SetupNode
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public SetupNode(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
}
