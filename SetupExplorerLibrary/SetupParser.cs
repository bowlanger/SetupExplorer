using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary
{
    public class SetupParser
    {
        //public string InputFile { get; set; }
        private string InputFile;

        private HtmlDocument doc = new HtmlDocument();
        private HtmlNodeCollection H2Nodes;

        // Test
        public string h2cartrack;

        private string Car;
        private string SetupName;
        private string Track;

        public SetupParser(string InputFile)
        {
            this.InputFile = InputFile;

            LoadInputFile();

            H2Nodes = GetH2Nodes();
            GetCarTrackH2Node();

            // Test
            h2cartrack = doc.DocumentNode.SelectSingleNode("//h2[@align=\"center\"]").InnerHtml;
        }

        private void LoadInputFile()
        {            
            doc.Load(InputFile);
        }

        private HtmlNodeCollection GetH2Nodes()
        {
            Console.WriteLine("GetH2Nodes");
            HtmlNodeCollection H2Nodes = doc.DocumentNode.SelectNodes("/html/body/h2");

            return H2Nodes;
        }

        private void GetCarTrackH2Node()
        {
            Console.WriteLine("GetCarTrackH2Node");
            HtmlNode cartrackH2Node = H2Nodes.First();
            Car = cartrackH2Node.ChildNodes[2].InnerText.Trim();
            Track = cartrackH2Node.ChildNodes[4].InnerText.Trim();
            SetupName = Car;

            Console.WriteLine("car : " + Car);
            Console.WriteLine("track : " + Track);
            Console.WriteLine("setup : " + SetupName);
        }

    }
}
