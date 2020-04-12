using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities.Setup
{
    public class Sheet
    {
        public string Title { get; set; }
        public List<Area> Areas = new List<Area>();

        public Sheet()
        {
            // explicit empty constructor in parent class to prevent necessity to chain declare constructors in children classes
            //
            // https://stackoverflow.com/questions/29959839/c-sharp-inheritance-and-default-constructors
            // https://stackoverflow.com/questions/30696006/inheritance-with-base-class-constructor-with-parameters

            //Title = "dummy";
        }
        public Sheet(string title)
        {
            Title = title;
        }
    }
}
