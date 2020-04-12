using SetupExplorerLibrary.Components.Parsers;
using SetupExplorerLibrary.Entities.Setup;
using SetupExplorerLibrary.Entities.Template;
using SetupExplorerLibrary.Entities.Template.Cars;
using SetupExplorerLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Components.Handlers
{
    public class SetupHandler
    {
        private readonly ILogger logger;

        private readonly SetupParser setupParser;
        private readonly string setupFileName;

        private Template template;
        private Setup setup;

        public SetupHandler(string setupFileName, ILogger logger)
        {
            this.logger = logger;
            this.logger.Log("SetupHandler > _constructor");

            this.setupFileName = setupFileName;

            // TODO: validate htm file format ?

            setupParser = new SetupParser(this.setupFileName, this.logger);
            GetTemplate(setupParser.GetCarName());

            BuildSetupV2();
        }

        public Setup GetSetup()
        {
            return this.setup;
        }

        public string GetSetupFileName()
        {
            return this.setupFileName;
        }

        private void GetTemplate(string carName)
        {
            // Capitalize first letter of carName
            System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(carName.ToLower());

            // Trying to dynamically instancing template
            //string templateTypeFQN = typeof(carName + "Template").AssemblyQualifiedName;
            //Type templateType = Type.GetType(templateTypeFQN);
            //return (Template)Activator.CreateInstance(templateType);

            // instancing template based on carName
            //switch (carName)
            //{
            //    case "Audirs3lms":
            //        return new Audirs3lmsTemplate();
            //    //break;
            //    default:
            //        logger.Log("Unknown car");
            //        break;
            //}

            template = new Audirs3lmsTemplateV2();

        }

        private void BuildSetup()
        {
            setup = new Setup(setupParser.GetSetupSummary(), logger);

            foreach (Sheet sheet in template.Sheets)
            {
                foreach(Area area in sheet.Areas)
                {
                    foreach(Property property in area.Properties)
                    {
                        logger.Log("6: " + setupParser.GetText(property.PropertyXpath) + " => " + setupParser.GetText(property.ValuesXpath));
                        
                    }
                }
            }
        }

        private void BuildSetupV2()
        {
            setup = new Setup(setupParser.GetSetupSummary(), logger);
            
            foreach(string parsedLine in setupParser.parsedLines)
            {
                string last = setupParser.SplitXPath(parsedLine).Last();
                logger.Log(last);
                string currentNode = setupParser.GetNodeName(last);
                string id = setupParser.GetNodeId(last);
                if (currentNode == "h2")
                {
                    logger.Log(id + " => " + template.Mapping[id]);
                }
            }
        }
    }
}
