using SetupExplorerLibrary.Components.Parsers;
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
        private readonly SetupParser setupParser;
        private readonly Setup setup;
        private readonly string setupFileName;

        private readonly ILogger logger;

        public SetupHandler(string setupFileName, ILogger logger)
        {
            this.logger = logger;
            this.logger.Log("SetupHandler > _constructor");

            this.setupFileName = setupFileName;

            // TODO: validate htm file format ?

            setupParser = new SetupParser(this.setupFileName, this.logger);
            var template = GetTemplate(setupParser.GetCarName());
            setupParser.Parse(template);
            setup = new Setup(setupParser.GetSetupSummary(), this.logger);
        }

        public Setup GetSetup()
        {
            return this.setup;
        }

        public string GetSetupFileName()
        {
            return this.setupFileName;
        }

        private Template GetTemplate(string carName)
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

            return new Audirs3lmsTemplate2();

        }
    }
}
