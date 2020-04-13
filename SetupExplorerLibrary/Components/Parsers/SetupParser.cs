using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetupExplorerLibrary.Interfaces;
using SetupExplorerLibrary.Entities.Setup;
using SetupExplorerLibrary.Extensions;

namespace SetupExplorerLibrary.Components.Parsers
{
	public class SetupParser
	{
		private readonly HtmlDocument doc = new HtmlDocument();
		private readonly HtmlNode firstH2Node;
		private readonly HtmlNodeCollection documentNodes;
		private readonly HtmlNodeCollection h2Nodes;
		private readonly SetupSummaryParser setupSummaryParser;

		public List<string> NodesXPathList { get; set; } = new List<string>();

		private readonly ILogger logger;

		public SetupParser(ILogger logger)
		{
			this.logger = logger;
			this.logger.Log("INFO | SetupParser > _constructor(logger)");

			// components
			setupSummaryParser = new SetupSummaryParser(this.logger);
		}

		public bool Load(string htmFileName)
		{
			try
			{
				doc.Load(htmFileName);
			}
			catch (Exception e)
			{
				logger.Log(e.Message);
				return false;
			}

			logger.Log("INFO | SetupParser > Load(htmFileName) : success !");
			return true;
		}

		public List<string> GetXpathList(string xpath)
		{
			return doc.DocumentNode.SelectNodes(xpath).ToXPathList();
		}

		public List<string> Dump(string xpath)
		{
			return doc.DocumentNode.SelectNodes(xpath).Dump();
		}

		// ##############################################
		// <------------- old code below --------------->
		// ##############################################

		public SetupParser(string htmFileName, ILogger logger)
		{
			this.logger = logger;
			this.logger.Log("SetupParser > _constructor");
			
			doc.Load(htmFileName);

			firstH2Node = doc.DocumentNode.SelectSingleNode("//h2");
			setupSummaryParser = new SetupSummaryParser(firstH2Node, logger);

			// get all content nodes except summary and notes
			// solution 1
			documentNodes = doc.DocumentNode.SelectNodes("//node()[preceding-sibling::h2][following-sibling::h2]"); 
			NodesXPathList = documentNodes.ToXPathList();

			// save result to file for the lul
			//SaveToFile($@"E:\Temp\iRacing\SetupExplorer\setups\{setupSummaryParser.GetCarName()}.xpath.txt", NodesXPathList);

			// solution 2
			h2Nodes = doc.DocumentNode.SelectNodes("//h2");
			GhettoParse(h2Nodes);
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

		public string GetText(string xpath)
		{
			HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(xpath);
			if (nodes.Count == 1)
			{
				return doc.DocumentNode.SelectSingleNode(xpath).InnerText.Trim();
			}
			else
			{
				var str = "";
				foreach(HtmlNode node in nodes)
				{
					str += node.InnerText.Trim() + " ";
				}
				return str;
			}
		}

		//private List<string> ListNodesXPath(HtmlNodeCollection documentNodes)
		//{
		//	// https://stackoverflow.com/questions/37320624/htmlagilitypack-how-to-extract-html-between-some-tag
		//	//string query = "//node()[preceding-sibling::h2 or self::h2][following-sibling::h2 or self::h2]"; // grabs all h2 and nodes in between but won't grab "content" of last h2 node "Notes:"
		//	//string query = "//node()[preceding-sibling::h2][following-sibling::h2]"; // will skip first h2 "setup summary" and the last h2 "Notes:"
		//	//string query = "//node()[preceding-sibling::h2]"; // skips first h2 "setup summary" and doesn't skip last h2 "Notes:", grabs all nodes that have a h2 as 

		//	//List<string> lines = new List<string>();

		//	List<string> xpaths = new List<string>();

		//	foreach (var node in documentNodes.Where(x => !string.IsNullOrEmpty(x.InnerText.Trim())))
		//	{
		//		string xpath = node.XPath;
		//		// string value = node.XPath.InnerText.Trim();
		//		xpaths.Add(xpath);
		//	}

		//	return xpaths;
		//}

		private void Parse(HtmlNodeCollection h2Nodes)
		{
			int h2count = h2Nodes.Count;
			logger.Log(string.Format("1: Found {0} h2 nodes for car {1}.", h2count, GetCarName()));
		}

		private void GhettoParse(HtmlNodeCollection h2Nodes)
		{
			//var h2NodesCount = h2Nodes.Count;
			//for(var i=1; i < h2NodesCount; i++) // i=1 skip "summary" h2 node
			//{
			//	logger.Log("h2Nodes > " + h2Nodes[i].InnerText.Trim());
			//}
			int h2count = h2Nodes.Count;

			logger.Log(string.Format("1: Found {0} h2 nodes.", h2count));

			for (var i=2; i < h2count; i++) // i=2: skip h2 summary, i < h2count : exclude Notes h2 and data, see notesQuery below
			//for (var i=1; i <= h2count; i++) // i=1: include h2 summary, i <= h2count : include Notes h2 and data
			{
				var titleQuery = "//h2[" + i + "]";
				//var dataQuery = "//h2[" + i + "]/following-sibling::node()";
				//dataQuery += "[count(.|//h2[" + i + "+1]/preceding-sibling::node())";
				//dataQuery += "=";
				//dataQuery += "count(//h2[" + i + "+1]/preceding-sibling::node())]";
				//var dataQuery = "//node()[count(preceding-sibling::h2)=" + i + "]";
				var dataQuery = "//node()[count(preceding-sibling::h2)=" + i + " and not(*[not(h2)])]";
				var title = doc.DocumentNode.SelectSingleNode(titleQuery).InnerText.Trim();
				var setupNodes = doc.DocumentNode.SelectNodes(dataQuery);
				logger.Log(string.Format("2: Content of node {0} {1} >", i, title));
				foreach (var node in setupNodes.Where(x => x.ParentNode is HtmlNode && !string.IsNullOrEmpty(x.InnerText.Trim())))
				{
					logger.Log(string.Format("3: {0}", node.InnerText.Trim()));
				}
			}

			var notesQuery = "//node()[count(preceding-sibling::h2)=" + h2count + "]";
			var notesNodes = doc.DocumentNode.SelectNodes(notesQuery);
			logger.Log("4: Content of node Notes >");
			foreach (var node in notesNodes) // doesnt filter empty lines and "br" to keep a glimpse of formatting
			{
				logger.Log(string.Format("5: {0}", node.InnerText.Trim()));
			}

		}

		public string[] SplitXPath(string xpath)
		{
			char sep = '/';
			// https://stackoverflow.com/questions/541954/how-would-you-count-occurrences-of-a-string-actually-a-char-within-a-string
			int count = 0;
			foreach (char c in xpath)
				if (c == sep) count++;

			return xpath.Split(new string[] { sep.ToString() }, count, StringSplitOptions.RemoveEmptyEntries);
		}

		public string GetNodeName(string node)
		{
			return node.Substring(0, node.IndexOf("["));
		}

		public string GetNodeId(string node)
		{
			// https://www.techiedelight.com/convert-string-to-integer-csharp/
			//return Int32.Parse(step.Substring(step.IndexOf("[") + 1, 1));
			int begin = node.IndexOf("[") + 1;
			int length = node.IndexOf("]") - begin;

			return node.Substring(begin, length);
		}
	}
}
