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
		private readonly HtmlNode firstH2Node;
		private readonly HtmlNodeCollection documentNodes;
		private readonly HtmlNodeCollection h2Nodes;
		private readonly SetupSummaryParser setupSummaryParser;

		private readonly ILogger logger;

		public SetupParser(string htmFileName, ILogger logger)
		{
			this.logger = logger;
			this.logger.Log("SetupParser > _constructor");

			this.htmFileName = htmFileName;

			doc.Load(this.htmFileName);

			firstH2Node = doc.DocumentNode.SelectSingleNode("//h2");
			setupSummaryParser = new SetupSummaryParser(firstH2Node, logger);

			documentNodes = doc.DocumentNode.SelectNodes("//node()[preceding-sibling::h2]");
			h2Nodes = doc.DocumentNode.SelectNodes("//h2");
			
			this.Parse();
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

		private void Parse()
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
			//string query = "//node()[preceding-sibling::h2]"; // skips first h2 "setup summary" and doesn't skip last h2 "Notes:", grabs all nodes that have a h2 as 

			List<string> lines = new List<string>();

			foreach (var item in documentNodes.Where(x => x.ParentNode is HtmlNode && !string.IsNullOrEmpty(x.InnerText.Trim())))
			{
				//var tabs = "\t\t";

				var tabs = item.XPath.Length > 24 ? "\t" : "\t\t";
				var line = item.XPath + tabs + item.InnerText.Trim();
				//logger.Log(line);

				lines.Add(line);
			}

			//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-write-to-a-text-file
			//using (System.IO.StreamWriter file =
			//	new System.IO.StreamWriter(@"E:\Temp\iRacing\SetupExplorer\setups\" + setupSummaryParser.GetCarName() + ".xpath.txt"))
			//{
			//	foreach (string line in lines)
			//	{
			//		file.WriteLine(line);
			//	}
				
			//}
			System.IO.File.WriteAllLines(@"E:\Temp\iRacing\SetupExplorer\setups\" + setupSummaryParser.GetCarName() + ".xpath.txt", lines);

			//var h2NodesCount = h2Nodes.Count;
			//for(var i=1; i < h2NodesCount; i++) // i=1 skip "summary" h2 node
			//{
			//	logger.Log("h2Nodes > " + h2Nodes[i].InnerText.Trim());
			//}

			var query = "//h2[text()=LEFT FRONT:]/following-sibling=text()";
		}

	}
}
