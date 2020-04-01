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
        public string InputFile { get; set; }
        //private string InputFile;

        private HtmlDocument doc = new HtmlDocument();
        private HtmlNodeCollection H2Nodes;
        private HtmlNode SetupSummaryH2Node;

        public string CarName { get; set; }
        public string SetupName { get; set; }
        public string TrackName { get; set; }

        public SetupParser(string InputFile)
        {
            this.InputFile = InputFile;

            LoadInputFile();
            H2Nodes = GetH2Nodes();

            SetupSummaryH2Node = GetSetupSummaryH2Node();
            CarName = GetSanitizedCarName(SetupSummaryH2Node.ChildNodes[2].InnerText.Trim());
            SetupName = GetSanitizedSetupName(SetupSummaryH2Node.ChildNodes[2].InnerText.Trim());
            TrackName = GetSanitizedTrackName(SetupSummaryH2Node.ChildNodes[4].InnerText.Trim());


            Console.WriteLine("carname : " + CarName);
            Console.WriteLine("trackname : " + TrackName);
            Console.WriteLine("setupname : " + SetupName);

            // Test
            //h2cartrack = doc.DocumentNode.SelectSingleNode("//h2[@align=\"center\"]").InnerHtml;
        }

        private void LoadInputFile()
        {            
            doc.Load(InputFile);
        }

        private HtmlNodeCollection GetH2Nodes()
        {
            HtmlNodeCollection H2Nodes = doc.DocumentNode.SelectNodes("//h2");

            return H2Nodes;
        }

        private HtmlNode GetSetupSummaryH2Node()
        {
            // setup summary (car, track, setup name) is first H2 element in document.
            return H2Nodes.First();
        }

        private string GetSanitizedCarName(string carsetupLine)
        {
            // get substring from carsetupLine until ":" and get rid of trailing string "setup".
            return carsetupLine.Substring(0, carsetupLine.IndexOf(":") - 5);
        }

        private string GetSanitizedSetupName(string carsetupLine)
        {
            // get substring from carsetupLine starting at ":" and offset by "+ 2" to the actual beginning of the setup name.
            return carsetupLine.Substring(carsetupLine.IndexOf(":") + 2);
        }

        private string GetSanitizedTrackName(string trackLine)
        {
            // get substring from trackLine starting at ":" and offset by "+ 2" to the actual beginning of the track name.
            return trackLine.Substring(trackLine.IndexOf(":") + 2);
        }

        // retrieve and format from first H2 element : car, track and setup names.
        //private void GetCarTrackH2Node()
        //{
        //    Console.WriteLine("GetCarTrackH2Node");
        //    HtmlNode cartrackH2Node = H2Nodes.First();
        //    string carsetup = cartrackH2Node.ChildNodes[2].InnerText.Trim();
        //    string track = cartrackH2Node.ChildNodes[4].InnerText.Trim();
        //    Car = carsetup.Substring(0, carsetup.IndexOf(":") - 5);
        //    Track = track.Substring(track.IndexOf(":") + 2);
        //    SetupName = carsetup.Substring(carsetup.IndexOf(":") + 2);

        //    Console.WriteLine("car : " + Car);
        //    Console.WriteLine("track : " + Track);
        //    Console.WriteLine("setup : " + SetupName);
        //}

    }
}
