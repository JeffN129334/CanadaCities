using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanadaCities
{
    public class Program
    {
        public static void Main()
        {
            Statistics stats = new Statistics("..\\..\\..\\Canadacities-XML.xml", "XML");
            //Statistics stats = new Statistics("..\\..\\..\\Canadacities-JSON.json", "JSON");
            //Statistics stats = new Statistics("..\\..\\..\\Canadacities.csv", "CSV");

            stats.DisplayCityInformation("Toronto");
            //stats.DisplayCityInformation("Deer Lake");    //Duplication tester
            stats.DisplayLargestCityPopulation("Ontario");
            stats.DisplaySmallestCityPopulation("Ontario");
            stats.CompareCitiesPopulation(stats.CityCatalogue["Deer Lake"][0], stats.CityCatalogue["Windsor"][0]);
        }
    }
}
