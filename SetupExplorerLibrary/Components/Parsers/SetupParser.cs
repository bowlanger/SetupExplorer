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
		private readonly string htmFileName;
		private readonly HtmlDocument doc = new HtmlDocument();
		private readonly HtmlNodeCollection h2Nodes;
		private readonly SetupSummaryParser setupSummaryParser;

		private readonly ILogger logger;

		public SetupParser(string htmFileName, ILogger logger)
		{
			this.logger = logger;
			this.logger.Log("SetupParser > _constructor");

			this.htmFileName = htmFileName;

			doc.Load(this.htmFileName);
			h2Nodes = doc.DocumentNode.SelectNodes("//h2");

			setupSummaryParser = new SetupSummaryParser(h2Nodes.First(), logger);

			this.Parse(logger);
		}

		public SetupSummary GetSetupSummary()
		{
			return new SetupSummary(setupSummaryParser.GetCarName(), 
									setupSummaryParser.GetSetupName(), 
									setupSummaryParser.GetTrackName(),
									setupSummaryParser.GetTrackCfg(),
									logger);
		}

		public string GetCarName()
		{
			return setupSummaryParser.GetCarName();
		}

		private void Parse(ILogger logger)
		{
			/*
			 * 
			< H2 >< U > LEFT FRONT:</ U ></ H2 >
				Starting pressure: < U > 165 kPa </ U >< br > 
				Last hot pressure: < U > 165 kPa </ U >< br > 
				Last temps O M I: < U > 49C </ U >< br >
									< U > 49C </ U >< br >
									< U > 49C </ U >< br > 
				Tread remaining: < U > 100 %</ U >< br >
									< U > 100 %</ U >< br >
									< U > 100 %</ U >< br >
				< br >
			*/

			// https://stackoverflow.com/questions/37320624/htmlagilitypack-how-to-extract-html-between-some-tag
			//string query = "//node()[preceding-sibling::h2 or self::h2][following-sibling::h2 or self::h2]"; // grabs all h2 and nodes in between but won't grab "content" of last h2 node "Notes:"
			//string query = "/body/h2/node()"; // doesn't work
			//string query = "//node()[preceding-sibling::h2][following-sibling::h2]"; // will skip first h2 "setup summary" and the last h2 "Notes:"
			string query = "//node()[preceding-sibling::h2]"; // skips first h2 "setup summary" and doesn't skip last h2 "Notes:", grabs all nodes that have

			var mynodes = doc.DocumentNode.SelectNodes(query);
			foreach (var item in mynodes.Where(
											x => x.ParentNode is HtmlNode
											&& !string.IsNullOrEmpty(x.InnerText.Trim())
				))
			{
				logger.Log("5: " + item.ParentNode.Name + " > " + item.Name + " > " + item.InnerText.Trim());
			}
		}

	}
}
