using SetupExplorerLibrary.Components.Handlers;
using SetupExplorerLibrary.Components.Parsers;
using SetupExplorerLibrary.Entities.Setup;
using SetupExplorerLibrary.Entities.SetupFile;
using SetupExplorerLibrary.Entities.Template;
using SetupExplorerLibrary.Entities.Template.Cars;
using SetupExplorerLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary
{
    public class SetupExplorer
    {
        private readonly ILogger logger;

        private readonly Config cfg;
        private readonly SetupHandler setupHandler;
        private readonly SetupParser setupParser;
        private readonly Setup setup;
        private readonly Template template;

        private List<string> xPathList;

        public SetupExplorer(ILogger logger)
        {
            this.logger = logger;
            this.logger.Log("INFO | SetupHandler > _constructor(logger)");

            // config
            cfg = new Config();

            // components
            setupHandler = new SetupHandler(logger);
            setupParser = new SetupParser(logger);

            // entities
            template = new Template();
            setup = new Setup();

            //template = GetTemplate(setupParser.GetCarName());
            //BuildSetupV2();
        }

        public void Init(string setupFileName)
        {
            setupHandler.OpenSetupFile(setupFileName);
            SetupFile setupFile = new SetupFile(setupFileName);
        }

        public void LoadSetupFile(string setupFileName)
        {
            SetupFile setupFile = setupHandler.Create(setupFileName); 

            // check setupFile.Size

            if (setupParser.Load(setupFileName))
            {
                if (cfg.Debug)
                {
                    var xPathList = setupParser.GetXpathList(cfg.XPathRoot + "node()");
                    var dump = setupParser.Dump(cfg.XPathRoot + "node()");
                    //var carName = setupParser.GetCarName();
                    SaveToFile($@"{cfg.OutputDir}\__debug.xpath.txt", xPathList);
                    SaveToFile($@"{cfg.OutputDir}\__debug.xpathvalues.txt", dump);
                }

                setup.SetupSummary = setupParser.GetSetupSummary();
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

        //public string GetSetupFileName()
        //{
        //    return this.setupFileName;
        //}

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
            Setup setup = new Setup(setupParser.GetSetupSummary(), logger);

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
            Setup setup = new Setup(setupParser.GetSetupSummary(), logger);
            
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
