using SetupExplorerLibrary.Components.Managers;
using SetupExplorerLibrary.Components.Parsers;
using SetupExplorerLibrary.Entities;
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
        private readonly SetupManager setupManager;
        private readonly SetupFileParser setupFileParser;
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
            setupManager = new SetupManager(logger);
            setupFileParser = new SetupFileParser(logger);

            // entities
            template = new Template();
            //setup = new Setup();

            //template = GetTemplate(setupParser.GetCarName());
            //BuildSetupV2();
        }

        public void OpenSetupFile(string setupFileName)
        {
            if (setupFileParser.Load(setupFileName))
            {
                if (cfg.Debug)
                {
                    var xPathList = setupFileParser.GetXPathsAsList(cfg.XPathRoot + "node()");
                    var xPathValuesList = setupFileParser.GetXPathsAndValuesAsList(cfg.XPathRoot + "node()");
                    
                    SaveToFile($@"{cfg.OutputDir}\__debug.xpath.txt", xPathList);
                    SaveToFile($@"{cfg.OutputDir}\__debug.xpathvalues.txt", xPathValuesList);
                }

                var nodes = setupFileParser.GetSetupNodes(cfg.XPathRoot);

                var tmp = nodes.

                
                var summaryNodes = setupFileParser.GetNodes(cfg.XPathRoot + "h2[1]/text()"); // /html[1]/body[1]/h2[1]/text()
                foreach (var node in summaryNodes)
                {
                    logger.Log($@"DEBUG | {node.InnerText.Trim()}");
                }

                /*
                Setup setup = new Setup(setupFileName);
                Summary summary = new Summary(setupFileParser.GetCarName(),
                                              setupFileParser.GetSetupName(),
                                              setupFileParser.GetExportTrackName());
                setup.Summary = summary;
                setup.Properties = SetupFileParser.GetProperties();

                setupManager.Register(new Setup(setupFileName));      
                */
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

        /*
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
        */

        /*
        private void BuildSetup()
        {
            Setup setup = new Setup(setupFileParser.GetSetupSummary(), logger);

            foreach (Sheet sheet in template.Sheets)
            {
                foreach(Area area in sheet.Areas)
                {
                    foreach(Property property in area.Properties)
                    {
                        logger.Log("6: " + setupFileParser.GetText(property.PropertyXpath) + " => " + setupFileParser.GetText(property.ValuesXpath));
                        
                    }
                }
            }
        }
        */

        /*
        private void BuildSetupV2()
        {
            Setup setup = new Setup(setupFileParser.GetSetupSummary(), logger);
            
            foreach(var xpath in setupFileParser.NodesXPathList)
            {
                var last = setupFileParser.SplitXPath(xpath).Last();
                logger.Log(last);
                var currentNode = setupFileParser.GetNodeName(last);
                var id = setupFileParser.GetNodeId(last);
                if (currentNode == "h2")
                {
                    logger.Log(id + " => " + template.GetKeyByValue(id));
                }
            }
        }
        */
    }
}
