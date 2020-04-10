using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetupExplorerLibrary.Interfaces;

namespace SetupExplorerLibrary
{
	public class SetupParser
	{
		private readonly string InputFile;
		private readonly HtmlDocument doc = new HtmlDocument();
		private readonly HtmlNodeCollection h2Nodes;
		private readonly SetupSummaryParser setupSummaryParser;

		private readonly ILogger logger;

		public SetupParser(string InputFile, ILogger logger)
		{
			this.InputFile = InputFile;
			this.logger = logger;
			this.logger.Log("SetupParser > _constructor");

			doc.Load(this.InputFile);
			h2Nodes = doc.DocumentNode.SelectNodes("//h2");

			setupSummaryParser = new SetupSummaryParser(h2Nodes.First(), logger);
		}

		public SetupSummary GetSetupSummary()
		{
			return new SetupSummary(setupSummaryParser.GetCarName(), 
									setupSummaryParser.GetSetupName(), 
									setupSummaryParser.GetTrackName(),
									setupSummaryParser.GetTrackCfg(),
									logger);
		}

	}
}
