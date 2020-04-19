using SetupExplorerLibrary.Components.Handlers;
using SetupExplorerLibrary.Entities;
using SetupExplorerLibrary.Entities.SetupEntity;
using SetupExplorerLibrary.Entities.TemplateEntity;
using SetupExplorerLibrary.Enum;
using SetupExplorerLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SetupExplorerLibrary.Components.Parsers
{
    public class SetupFileHelper
    {
        private readonly ILogger _logger;
        
        private readonly XPathHandler _xHd;
        private readonly Config _cfg;

        private readonly string _xpr = "";
        public SetupFileHelper(XPathHandler xHd, Config cfg, ILogger logger)
        {
            _logger = logger;
            _logger.Log(ELogLevel.Debug, $@"{this.GetType().Name} > Constructor(xHd, cfg, logger)");

            _xHd = xHd;
            _cfg = cfg;

            _xpr = cfg.XPathRoot;
        }

        public bool Open(string setupFileName)
        {
            if (!_xHd.Open(setupFileName))
            {
                return false;
            }
            else { 
                if (_cfg.Debug)
                {
                    var xpquery = _cfg.XPathQueries["GetAllNodes"].BindParameters(new string[] { _xpr });
                    _logger.Log(ELogLevel.Debug, "XPathQuery : " + xpquery);
                    //var xRecords = _xHd.SelectRecords(_xpr + "node()");
                    var xRecords = _xHd.SelectRecords(xpquery);
                    var csvList = new List<string>();

                    foreach (var xr in xRecords)
                    {
                        csvList.Add($"{xr.Name};{xr.XPath};{xr.Value}");
                    }
                    SaveToFile($@"{_cfg.OutputFolder}\__debug.xpathrecords.txt", csvList);
                }

                return true;
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
                _logger.Log(ELogLevel.Error, e.Message);
                return false;
            }

            return true;
        }

        public List<string> GetSetupNotes()
        {
            var xpquery = _cfg.XPathQueries["GetSetupNotes"].BindParameters(new string[] { _xpr });
            _logger.Log(ELogLevel.Debug, "XPathQuery : " + xpquery);
            // var query = $@"{_xpr}node()[count(preceding-sibling::h2)=count({_xpr}h2)]";
            var notes = new List<string>();
            foreach (var xr in _xHd.SelectRecords(xpquery).Where(x => x.Name != "br"))
            {
                notes.Add(xr.Value);
            }

            if (_cfg.Debug)
            {
                _logger.Log(ELogLevel.Debug, $"Notes:\r\n{string.Join("\r\n", notes)}");
            }
            
            return notes;
        }

        public Summary GetSetupSummary()
        {
            var xpquery = _cfg.XPathQueries["GetSetupSummary"].BindParameters(new string[] {  _xpr });
            _logger.Log(ELogLevel.Debug, "XPathQuery : " + xpquery);
            //var summaryRecords = _xHd.SelectRecords(_xpr + "h2[1]/text()");
            var summaryRecords = _xHd.SelectRecords(xpquery);

            var carName = GetCarName(summaryRecords[1]);
            var setupName = GetSetupName(summaryRecords[1]);
            var exportTrackName = GetExportTrackName(summaryRecords[2]);

            return new Summary(carName, setupName, exportTrackName);
        }

        private string GetCarName(XPathRecord summaryRecord)
        {
            var carNameLine = summaryRecord.Value;
            _logger.Log(ELogLevel.Debug, $"carNameLine: {carNameLine}");
            var carName = carNameLine.Substring(0, carNameLine.IndexOf(":") - 6); // -6 = get rid of trailing "<SPACE>setup"
            _logger.Log(ELogLevel.DebugV, $@"carName: {carName}");

            return carName;
        }

        private string GetSetupName(XPathRecord summaryRecord)
        {
            var carNameLine = summaryRecord.Value; // carname and setupname are contained in the same summaryRecord
            var setupName = carNameLine.Substring(carNameLine.IndexOf(":") + 2);
            _logger.Log(ELogLevel.DebugV, $@"setupName: {setupName}");

            return setupName;
        }

        private string GetExportTrackName(XPathRecord summaryRecord)
        {
            var exportTrackNameLine = summaryRecord.Value;
            var exportTrackName = exportTrackNameLine.Substring(exportTrackNameLine.IndexOf(":") + 2);
            _logger.Log(ELogLevel.DebugVV, $@"exportTrackName: {exportTrackName}");

            return exportTrackName;
        }

        public Template GetTemplate(string carName)
        {
            var templateName = _cfg.Templates[carName];
            _logger.Log(ELogLevel.DebugV, $@"templateName: {templateName}");
            // TODO:
            // else
            //      build generic template
            //          sheetId = 0
            //          h2dict<string, count> // ex: LEFT FRONT:, 2 => il y a aura donc au moins 2 sheets
            //          foreach h2
            //              definecurrentsheetid { if newcount(h2.title) > currentcount(h2.title), sheetId++ }
            //                  Mapping["Sheet[sheetId]:h2.title"] = id(h2)

            // dynamically load template
            /*
				* https://stackoverflow.com/questions/3512319/resolve-type-from-class-name-in-a-different-assembly
            string fqn1 = typeof(Template).AssemblyQualifiedName;           _logger.Debug(fqn1);
            string fqn2 = typeof(Template).UnderlyingSystemType.FullName;   _logger.Debug(fqn2);
            string ns = typeof(Template).Namespace;                         _logger.Debug(ns);
            */
            Type t = Type.GetType(typeof(Template).Namespace + ".Templates." + templateName);
            return (Template)Activator.CreateInstance(t);
        }

        public List<Sheet> GetSetupProperties(Template template)
        {
            var sheets = new List<Sheet>();
            //var properties = new List<Property>();

            // use template.Mapping to define all the Properties
            foreach (KeyValuePair<string, int> kvp in template.Mapping)
            {
                var pPath = kvp.Key;
                // TODO: maybe replace with split ?
                var sheetName = pPath.Substring(0, pPath.IndexOf(":"));
                var nodeName = pPath.Substring(pPath.IndexOf(":") + 1); // get rid of leading ":"
                _logger.Log(ELogLevel.Debug, $"sheetName: {sheetName}, nodeName: {nodeName}");

                if (sheets.FirstOrDefault(x => x.Name == sheetName) == null)
                {
                    sheets.Add(new Sheet(sheetName));
                }
                var sheet = sheets.FirstOrDefault(x => x.Name == sheetName);

                if (sheet.Nodes.FirstOrDefault(x => x.Name == nodeName) == null){
                    sheet.Nodes.Add(new Node(nodeName));
                }
                var node = sheet.Nodes.FirstOrDefault(x => x.Name == nodeName);

//                Node sn = new Node();                
                node.Id = kvp.Value;
                _logger.Log(ELogLevel.Debug, $"Mapping: {pPath} => {node.Id}");

                node.Text = _xHd.SelectSingleRecord(_cfg.XPathRoot + $"h2[{node.Id}]").Value;
                _logger.Log(ELogLevel.DebugVV, $"sn.Text: {node.Text.Remove(node.Text.Length - 1)}");

                // get content of the setup nodes
                // XPathQuery GetSetupNodeContent { _xpr, sn.Id }
                var xpquery = _cfg.XPathQueries["GetSetupNodeContent"].BindParameters(new string[] { _xpr, node.Id.ToString() });
                _logger.Log(ELogLevel.Debug, "XPathQuery : " + xpquery);
                // var query = $@"{_xpr}node()[count(preceding-sibling::h2)={sn.Id} and not(*[not(h2)])]";
                /* alternate query, same result
                xpquery = $"{cfg.XPathRoot}h2[{sn.Id}]/following-sibling::node()"
						+ $"[count(.|{cfg.XPathRoot}h2[{sn.Id + 1}]/preceding-sibling::node())"
						+ $"="
						+ $"count({cfg.XPathRoot}h2[{sn.Id + 1}]/preceding-sibling::node())]";
                */
                // _logger.Log(ELogLevel.DebugVV, $"query: {xpquery}");

                var xPathRecords = _xHd.SelectRecords(xpquery);

                // parse content of the setup nodes into Label => Value
                var pXPath = "";
                var pVXPath = "";
                var pLabel = "";
                var pValue = "";
                foreach (var xr in xPathRecords.Where(x => !string.IsNullOrEmpty(x.Value)))
                {
                    if (xr.Name == "#text")
                    {
                        if (!string.IsNullOrEmpty(pValue))
                        {
                            // !string.IsNullOrEmpty(pValue) means we went through u once (or more) and pValue got a value assigned
                            // we now found a new #text record, which means we are going to parse a new property
                            // before doing so, store the current property
                            //properties.Add(GetSetupProperty(node, pXPath, pVXPath, pPath, pLabel, pValue));
                            node.Properties.Add(GetSetupProperty(pXPath, pVXPath, pPath, pLabel, pValue));

                            pVXPath = "";
                            pValue = "";
                        }
                        // new setup property
                        pXPath = xr.XPath;
                        pLabel = xr.Value;
                    }
                    else if (xr.Name == "u")
                    {
                        // new value for the current property
                        if (string.IsNullOrEmpty(xr.Value))
                        {
                            xr.Value = "<empty>";
                        }

                        // TODO: replace with 
                        //  List<string> pVXPath
                        //  pVXPath.Add(xr.XPath)
                        //  and after the loop string.Join(";", pVXPath)
                        pVXPath += xr.XPath + ";";
                        pValue += xr.Value + ";";
                    }

                    _logger.Log(ELogLevel.DebugV, $"{xr.Name} => {xr.Value}");
                }
                // save last setup property
                // ( we reached last u and there is no more xr in xPathRecords
                //   so we won't have the chance to go back to !string.IsNullOrEmpty(pValue)
                //   we got out of the the foreach loop
                //   therefore, we need to save the last property we parsed)
                GetSetupProperty(pXPath, pVXPath, pPath, pLabel, pValue);
            }

            return sheets;
        }

        private Property GetSetupProperty(string pXPath, string pVXPath, string pPath, string pLabel, string pValue)
        {
            // remove trailing ";"
            pVXPath = pVXPath.Remove(pVXPath.Length - 1);
            pValue = pValue.Remove(pValue.Length - 1);

            _logger.Log(ELogLevel.Debug, $@"New Setup Property: {pXPath}, {pVXPath}, {pPath}, {pLabel}, {pValue}");
            return new Property(pXPath, pVXPath, pPath, pLabel, pValue);
        }
    }
}
