using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Interfaces
{
    public interface IConfigLibrary
    {
        bool Debug { get; set; }
        string OutputFolder { get; set; }
        string BaseFolder { get; set; } // what is an auto implement property ?

        /*
         *             OutputFolder = @"%temp%"; // => transferer à l'UI
            BaseFolder = @"E:\Temp\iRacing\SetupExplorer\setups\"; // recuperer Mes Documents\iRacing => transferer à l'UI
         * 
         * */
    }
}
