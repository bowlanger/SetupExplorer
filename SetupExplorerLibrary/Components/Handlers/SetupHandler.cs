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

        private readonly string setupFileName;
        private readonly SetupParser setupParser;
        private Setup setup;
        private readonly Template template;

        private List<string> xPathList;

        
        

        public SetupHandler(string setupFileName, ILogger logger)
        {
            this.logger = logger;
            this.logger.Log("SetupHandler > _constructor(setupFileName, logger)");

            this.setupFileName = setupFileName;

            setupParser = new SetupParser(logger);
            setup = new Setup(logger);

            Work();
            //template = GetTemplate(setupParser.GetCarName());

            //BuildSetupV2();
        }

        private void Work()
        {
            if (setupParser.Load(setupFileName))
            {
                xPathList = setupParser.GetXpathList("//node()");
                var carName = setupParser.GetCarName();
                //var bSaveToFile = SaveToFile($@"E:\Temp\iRacing\SetupExplorer\setups\{setupSummaryParser.GetCarName()}.xpath.txt", xPathList);
                SaveToFile($@"E:\Temp\iRacing\SetupExplorer\setups\__debug.xpath.txt", xPathList);
            }
            
        }

        private bool SaveToFile(string fileName, List<string> lines)
        {
            try
            {
                // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-write-to-a-text-file
                System.IO.File.WriteAllLines(fileName, lines);
            }
            catch (Exception e)
            {
                logger.Log(e.Message);
                return false;
            }

            return true;
        }

        // ##############################################
        // <------------- old code below --------------->
        // ##############################################

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

            return new Audirs3lmsTemplateV2();

        }

        private void BuildSetup()
        {
            Setup = new Setup(setupParser.GetSetupSummary(), logger);

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
            Setup = new Setup(setupParser.GetSetupSummary(), logger);
            
            foreach(var xpath in setupParser.NodesXPathList)
            {
                var last = setupParser.SplitXPath(xpath).Last();
                logger.Log(last);
                var currentNode = setupParser.GetNodeName(last);
                var id = setupParser.GetNodeId(last);
                if (currentNode == "h2")
                {
                    logger.Log(id + " => " + template.GetKeyByValue(id));
                }
            }
        }
    }
}
