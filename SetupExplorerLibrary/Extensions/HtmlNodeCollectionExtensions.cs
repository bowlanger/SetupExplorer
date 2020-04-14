using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerApp.Extensions
{
    public static class HtmlNodeCollectionExtensions
    {
        public static List<string> ToXPathList(this HtmlNodeCollection htmlNodeCollection)
        {
            List<string> xpathList = new List<string>();

            //foreach (var node in htmlNodeCollection.Where(x => !string.IsNullOrEmpty(x.InnerText.Trim())))
            foreach (var node in htmlNodeCollection)
            {
                string xpath = node.XPath;
                xpathList.Add(xpath);
            }

            return xpathList;
        }

        public static List<string> Dump(this HtmlNodeCollection htmlNodeCollection)
        {
            List<string> xpathList = new List<string>();

            //foreach (var node in htmlNodeCollection.Where(x => !string.IsNullOrEmpty(x.InnerText.Trim())))
            foreach (var node in htmlNodeCollection)
            {
                string xpath = node.XPath;
                string value = node.InnerText.Trim();
                xpathList.Add(xpath + ";" + value);
            }

            return xpathList;
        }
    }
}
