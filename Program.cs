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

            foreach (var city in stats.CityCatalogue)
            {
                foreach (var duplicate in city.Value)
                {
                    Console.WriteLine("Name: " + duplicate.CityName);
                }
            }

        }
    }
}
