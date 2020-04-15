using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetupExplorerLibrary.Interfaces;
using SetupExplorerLibrary.Extensions;
using SetupExplorerLibrary.Entities;

namespace SetupExplorerLibrary.Components.Handlers
{
	public class XPathHandler
	{
		// injections
		private readonly ILogger _logger;

		// champs
		private readonly HtmlDocument _doc = new HtmlDocument();
		
		public XPathHandler(ILogger logger)
		{
			_logger = logger;
			_logger.Info($@"{this.GetType().Name} > Constructor(logger)");
		}

		public bool Open(string htmFileName)
		{
			try
			{
				_doc.Load(htmFileName);
			}
			catch (Exception e)
			{
				_logger.Log(e.Message);
				return false;
			}

			_logger.Info($@"{this.GetType().Name} > Open(htmFileName) : success !");
			return true;
		}

		public XPathRecord SelectSingleRecord(string query)
		{
			var node = _doc.DocumentNode.SelectSingleNode(query);
			return new XPathRecord(node.XPath, node.Name, node.InnerText.Trim());
		}

		public List<XPathRecord> SelectRecords(string query)
		{
			var lines = new List<XPathRecord>();
			foreach (var node in _doc.DocumentNode.SelectNodes(query))
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
	}
}
