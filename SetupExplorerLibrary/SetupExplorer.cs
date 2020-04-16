using Newtonsoft.Json;
using SetupExplorerLibrary.Components.Handlers;
using SetupExplorerLibrary.Components.Managers;
using SetupExplorerLibrary.Components.Parsers;
using SetupExplorerLibrary.Entities.Setup;
using SetupExplorerLibrary.Entities.Template;
using SetupExplorerLibrary.Interfaces;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SetupExplorerLibrary
{
	public class SetupExplorer
	{
		public static Container Container = new Container();

		private readonly ILogger _logger;
		private readonly Config _cfg;
		private readonly SetupManager _setupManager;
		private readonly XPathHandler _xH;
		private readonly SetupFileParser _sfP;

		private string _xQuery;
		private Template _template;

		public SetupExplorer(Action<IConfigLibrary> actionConfig, ILogger logger)
		{
			_logger = logger;

			_logger.Info($@"{this.GetType().Name} > Constructor(logger)");

			// config
			_cfg = new Config();
			actionConfig?.Invoke(_cfg);

			// registering the services
			Container.Register(() => _cfg, Lifestyle.Singleton);
			Container.Register(typeof(ILogger), _cfg.LoggerType);
			// Container.Register(() => _logger, Lifestyle.Singleton);
			Container.Register<SetupManager>();
			Container.Register<XPathHandler>();
			Container.Register<SetupFileParser>();


			_setupManager = Container.GetInstance<SetupManager>();
			_xH = Container.GetInstance<XPathHandler>();
			_sfP = Container.GetInstance<SetupFileParser>();

			// entities
			_template = new Template();
			//setup = new Setup();

			//template = GetTemplate(setupParser.GetCarName());
			//BuildSetupV2();
		}

		public void OpenSetupFile(string setupFileName)
		{
			if (_xH.Open(setupFileName))
			{
				Setup setup = new Setup(setupFileName);

				// Refactor2k20 project
				_sfP.Configure(_xH, _cfg.XPathRoot);
				// should _cfg.XPathRoot become a property of _xH instead of _sfP ? (I think so)
				// -> we'd instantiate _sfP with _xH in SetupExplorer constructor
				// -> _xH would be instantiated with _cfg.XPathRoot
				// Refactor2k21 : also pass _cfg.Queries to _sfP

				if (_cfg.Debug)
				{
					var xRecords = _xH.SelectRecords(_cfg.XPathRoot + "node()");
					var csvList = new List<string>();

					foreach (var xr in xRecords)
					{
						csvList.Add($"{xr.Name};{xr.XPath};{xr.Value}");
					}
					SaveToFile($@"{_cfg.OutputFolder}\__debug.xpathrecords.txt", csvList);
				}

				// get setup notes
				_xQuery = $@"{_cfg.XPathRoot}node()[count(preceding-sibling::h2)=count({_cfg.XPathRoot}h2)]";
				var notesRecords = _xH.SelectRecords(_xQuery);
				var notes = "";
				foreach (var xr in notesRecords.Where(x => x.Name != "br"))
				{
					setup.Notes.Add(xr.Value);
					notes += xr.Value + "\r\n";
				}
				_logger.Debug($"Notes:\r\n{notes}");
				// Refactor2k20:
				setup.Notes = _sfP.GetSetupNotes();

				// get setup summary
				// Refactor2k20: replace with
				//          setup.Summary.CarName = _sfP.GetCarName();
				//          setup.Summary.SetupName = _sfP.GetSetupName();
				//          setup.Summary.ExportTrackName = _sfP.GetExportTrackName();
				Summary ss = new Summary();
				var summmaryRecords = _xH.SelectRecords(_cfg.XPathRoot + "h2[1]/text()");

				var carNameLine = summmaryRecords[1].Value;
				_logger.Debug($"carNameLine: {carNameLine}");
				var carName = carNameLine.Substring(0, carNameLine.IndexOf(":") - 6); // -6 = get rid of trailing "<SPACE>setup"
				_logger.Debug($@"carName: {carName}");

				var setupName = carNameLine.Substring(carNameLine.IndexOf(":") + 2);
				_logger.Debug($@"setupName: {setupName}");

				var exportTrackNameLine = summmaryRecords[2].Value;
				var exportTrackName = exportTrackNameLine.Substring(exportTrackNameLine.IndexOf(":") + 2);
				_logger.Debug($@"exportTrackName: {exportTrackName}");

				ss.CarName = carName;
				ss.SetupName = setupName;
				ss.ExportTrackName = exportTrackName;

				setup.Summary = ss;

				// get template from carName
				var templateName = _cfg.Templates[carName];
				_logger.Debug($@"templateName: {templateName}");
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
				_template = (Template)Activator.CreateInstance(t);

				// get setup properties
				// use template.Mapping to define setup.Properties
				// Refactor2k20: replace with
				//              setup.Properties = _sfP.GetProperties(_template);
				foreach (KeyValuePair<string, int> kvp in _template.Mapping)
				{
					Node sn = new Node();

					var pPath = kvp.Key;
					sn.Id = kvp.Value;
					_logger.Debug($"Mapping: {pPath} => {sn.Id}");

					sn.Text = _xH.SelectSingleRecord(_cfg.XPathRoot + $"h2[{sn.Id}]").Value;
					_logger.Debug($"sn.Text: {sn.Text.Remove(sn.Text.Length - 1)}");

					// get content of the setup nodes
					//
					_xQuery = $@"{_cfg.XPathRoot}node()[count(preceding-sibling::h2)={sn.Id} and not(*[not(h2)])]";
					/* alternate query, same result
                    xpquery = $"{cfg.XPathRoot}h2[{sn.Id}]/following-sibling::node()"
							+ $"[count(.|{cfg.XPathRoot}h2[{sn.Id + 1}]/preceding-sibling::node())"
							+ $"="
							+ $"count({cfg.XPathRoot}h2[{sn.Id + 1}]/preceding-sibling::node())]";
                    */
					_logger.Debug($"_xQuery: {_xQuery}");

					var xPathRecords = _xH.SelectRecords(_xQuery);

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
								AddSetupProperty(setup, sn, pXPath, pVXPath, pPath, pLabel, pValue);

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

							// replace with string.Join(";", List<string>)
							pVXPath += xr.XPath + ";";
							pValue += xr.Value + ";";
						}

						_logger.Debug($"{xr.Name} => {xr.Value}");
					}
					// save last setup property
					// ( we reached last u and there is no more xr in xPathRecords
					//   so we won't have the chance to go back to !string.IsNullOrEmpty(pValue)
					//   we got out of the the foreach loop
					//   therefore, we need to save the last property we parsed)
					AddSetupProperty(setup, sn, pXPath, pVXPath, pPath, pLabel, pValue);
				}

				// dump setup object
				var setupJson = JsonConvert.SerializeObject(setup, Formatting.Indented);
				Console.WriteLine(setupJson);

				_setupManager.Register(setup);
			}
		}

		private void AddSetupProperty(Setup setup, Node sn, string pXPath, string pVXPath, string pPath, string pLabel, string pValue)
		{
			// remove trailing ";"
			pVXPath = pVXPath.Remove(pVXPath.Length - 1);
			pValue = pValue.Remove(pValue.Length - 1);

			setup.Properties.Add(new Property(sn, pXPath, pVXPath, pPath, pLabel, pValue));
			_logger.Debug($@"New Setup Property: {sn}, {pXPath}, {pVXPath}, {pPath}, {pLabel}, {pValue}");
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
				_logger.Error(e.Message);
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
