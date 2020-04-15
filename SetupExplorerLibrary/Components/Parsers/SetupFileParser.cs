using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetupExplorerLibrary.Interfaces;
using SetupExplorerLibrary.Extensions;
using SetupExplorerLibrary.Entities;

namespace SetupExplorerLibrary.Components.Parsers
{
	public class SetupFileParser
	{
		private readonly HtmlDocument doc = new HtmlDocument();
		private readonly HtmlNode firstH2Node;
		private readonly HtmlNodeCollection documentNodes;
		private readonly HtmlNodeCollection h2Nodes;
		private readonly SummaryParser summaryParser;
		private HtmlNode summaryNode;

		public List<string> NodesXPathList { get; set; } = new List<string>();

		private readonly ILogger logger;

		public SetupFileParser(ILogger logger)
		{
			this.logger = logger;
			this.logger.Log("INFO | SetupParser > _constructor(logger)");

			// components
			summaryParser = new SummaryParser(this.logger);
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

		public List<string> GetMultipleXPathsWithValues(string xpath)
		{
			return doc.DocumentNode.SelectNodes(xpath).ToXPathsAndValuesList();
		}

		public XPathRecord SelectSingleRecord(string xpath)
		{
			var node = doc.DocumentNode.SelectSingleNode(xpath);
			return new XPathRecord(node.XPath, node.Name, node.InnerText.Trim());
		}

		public List<string> GetMultipleLines(string xpath)
		{
			var lines = new List<string>();
			foreach (var node in doc.DocumentNode.SelectNodes(xpath))
			{
				lines.Add(node.InnerText.Trim() + " (" + node.Name + ")");
			}
			return lines;
		}

		public List<XPathRecord> SelectRecords(string xpath)
		{
			var lines = new List<XPathRecord>();
			foreach (var node in doc.DocumentNode.SelectNodes(xpath))
			{
				lines.Add(new XPathRecord(node.XPath, node.Name, node.InnerText.Trim()));
			}
			return lines;
		}

		// ##############################################
		// <------------- old code below --------------->
		// ##############################################

			// XPATH EXAMPLES

			/*
		public SetupFileParser(string htmFileName, ILogger logger)
		{
			// get all content nodes except summary and notes
			// solution 1
			documentNodes = doc.DocumentNode.SelectNodes("//node()[preceding-sibling::h2][following-sibling::h2]"); 
			NodesXPathList = documentNodes.ToXPathsList();
		}
			*/

		//private List<string> ListNodesXPath(HtmlNodeCollection documentNodes)
		//{
		//	// https://stackoverflow.com/questions/37320624/htmlagilitypack-how-to-extract-html-between-some-tag
		//	//string query = "//node()[preceding-sibling::h2 or self::h2][following-sibling::h2 or self::h2]"; // grabs all h2 and nodes in between but won't grab "content" of last h2 node "Notes:"
		//	//string query = "//node()[preceding-sibling::h2][following-sibling::h2]"; // will skip first h2 "setup summary" and the last h2 "Notes:"
		//	//string query = "//node()[preceding-sibling::h2]"; // skips first h2 "setup summary" and doesn't skip last h2 "Notes:", grabs all nodes that have a h2 as 


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
