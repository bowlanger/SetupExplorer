using SetupExplorerLibrary.Entities.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities.Templates
{
    public class Audirs3lmsTemplate2 : Template
    {
        public List<TemplateProperty> TemplateProperties = new List<TemplateProperty>();
        public Audirs3lmsTemplate2()
        {
            var tplProp = new TemplateProperty("Tires",
                                        new Area("Left Font"),
                                        "/html[1]/body[1]/#text[5]",
                                        "Starting pressure:",
                                        new string[1] { "/html[1]/body[1]/u[1]" },
                                        "maching pattern"));
            TemplateProperties.Add(tplProp);

            foreach(var prop in TemplateProperties)
            {
                // validate property
                // create SetupProperty
                // assign value to SetupProperty
            }
            
            //TiresSheet.LeftFrontTire = new Tire("/html[1]/body[1]/#text[5]",
            //                                        "Starting pressure:",
            //                                        new string[1] { "/html[1]/body[1]/u[1]" },
            //                                        "maching pattern");

        }
    }
}
