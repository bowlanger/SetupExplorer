using SetupExplorerLibrary.Components.Managers;
using SetupExplorerLibrary.Components.Parsers;
using SetupExplorerLibrary.Entities;
using SetupExplorerLibrary.Entities.Templates;
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
        //private readonly Setup setup;
        private Template template;

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
                    // TODO : replace with SelectRecords
                    var xPathRecords = setupFileParser.GetMultipleXPathsWithValues(cfg.XPathRoot + "node()");
                    
                    SaveToFile($@"{cfg.OutputDir}\__debug.xpathrecords.txt", xPathRecords);
                }

                Setup setup = new Setup(setupFileName);

                // get setup summary
                SetupSummary ss = new SetupSummary();
                var summaryContent = setupFileParser.SelectRecords(cfg.XPathRoot + "h2[1]/text()");
                //foreach (var xr in summaryContent)
                //{
                //    logger.Debug($@"{xr.Value}");
                //}
                var carNameLine = summaryContent[1].Value;
                logger.Debug($"carNameLine: {carNameLine}");
                var carName = carNameLine.Substring(0, carNameLine.IndexOf(":") - 6); // -6 = get rid of trailing "<SPACE>setup"
                logger.Debug($@"carName: {carName}");

                var setupName = carNameLine.Substring(carNameLine.IndexOf(":") + 2);
                logger.Debug($@"setupName: {setupName}");

                var exportTrackNameLine = summaryContent[2].Value;
                var exportTrackName = exportTrackNameLine.Substring(exportTrackNameLine.IndexOf(":") + 2);
                logger.Debug($@"exportTrackName: {exportTrackName}");

                ss.CarName = carName;
                ss.SetupName = setupName;
                ss.ExportTrackName = exportTrackName;

                setup.Summary = ss;

                // get template from carName
                var templateName = cfg.Templates[carName];
                logger.Debug($@"templateName: {templateName}");

                // load template
                template = new TCNTemplate();


                // get setup properties
                // use template.Mapping to define setup.Properties
                foreach (KeyValuePair<string, int> kvp in template.Mapping)
                {
                    SetupNode sn = new SetupNode();

                    var pPath = kvp.Key;
                    sn.Id = kvp.Value;
                    logger.Debug($"Mapping: {pPath} => {sn.Id}");

                    sn.Text = setupFileParser.SelectSingleRecord(cfg.XPathRoot + $"h2[{sn.Id}]").Value;
                    logger.Debug($"sn.Text: {sn.Text.Remove(sn.Text.Length - 1)}");

                    // get content of the setup nodes
                    // 
                    var query = $@"{cfg.XPathRoot}node()[count(preceding-sibling::h2)={sn.Id} and not(*[not(h2)])]";
                    /* alternate
                    var query = $"{cfg.XPathRoot}h2[{sn.Id}]/following-sibling::node()"
							  + $"[count(.|{cfg.XPathRoot}h2[{sn.Id + 1}]/preceding-sibling::node())"
							  + $"="
							  + $"count({cfg.XPathRoot}h2[{sn.Id + 1}]/preceding-sibling::node())]";
                    */
                    logger.Debug($"query: {query}");

                    var xPathRecords = setupFileParser.SelectRecords(query);

                    // parse content of the setup nodes into Label => Value
                    var pXPath = "";
                    var pVXPath = "";
                    var pLabel = "";
                    var pValue = "";
                    //List<string> plValue = new List<string>
                    foreach (var xr in xPathRecords.Where(x => !string.IsNullOrEmpty(x.Value)))
                    {    
                        if (xr.LastNodeName == "#text")
                        {
                            if (!string.IsNullOrEmpty(pValue))
                            {
                                AddSetupProperty(setup, sn, pXPath, pVXPath, pPath, pLabel, pValue);

                                pVXPath = "";
                                pValue = "";
                            }
                            // new property
                            pXPath = xr.XPath;
                            pLabel = xr.Value;
                            
                        }
                        else if (xr.LastNodeName == "u") {
                            // property value
                            if (string.IsNullOrEmpty(xr.Value))
                            {
                                xr.Value = "<empty>";
                            }

                            // replace with string.Join(";", List<string>)
                            pVXPath += xr.XPath + ";";
                            pValue += xr.Value + ";";
                        }

                        logger.Debug($"{xr.LastNodeName} => {xr.Value}");
                    }
                    // save last property ( we reached last u and there is no more xr in xPathRecords so we didn't have the chance to go back to !string.IsNullOrEmpty(pValue) )
                    AddSetupProperty(setup, sn, pXPath, pVXPath, pPath, pLabel, pValue);


                    // get Notes node
                }

                // dump setup object
                var setupDump = ObjectDumper.Dump(setup);

                Console.WriteLine(setupDump);
            }
        }

        private void AddSetupProperty(Setup setup, SetupNode sn, string pXPath, string pVXPath, string pPath, string pLabel, string pValue)
        {
            // remove trailing ";"
            pVXPath = pVXPath.Remove(pVXPath.Length - 1);
            pValue = pValue.Remove(pValue.Length - 1);

            // property has a value, store it !
            // pValue != "" means we went through u once and pValue got a value assigned
            setup.Properties.Add(new Property(sn, pXPath, pVXPath, pPath, pLabel, pValue));
            logger.Debug($@"New Setup Property: {sn}, {pXPath}, {pVXPath}, {pPath}, {pLabel}, {pValue}");
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
    }
}
