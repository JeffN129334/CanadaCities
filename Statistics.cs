using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanadaCities
{
    public class Statistics
    {
        public Dictionary<string, List<CityInfo>> CityCatalogue { get; set; }

        public Statistics(string fileName, string fileType)
        {
            CityCatalogue = DataModeler.ParseFile(fileName, fileType);
        }
        public void DisplayCityInformation(string cityName)
        {

        }
        public void DisplayLargestCityPopulation(string province)
        {

        }
        public void DisplaySmallestCityPopulation(string province)
        {

        }
        public void CompareCitiesPopulation(CityInfo cityOne, CityInfo cityTwo)
        {

        }
        public void ShowCitiesOnMap(CityInfo cityToDisplay)
        {

        }
        public void CalculateDistanceBetweenCities(CityInfo cityOne, CityInfo cityTwo)
        {

        }
        public void DisplayProvinceInformation(string province)
        {

        }

        public void DisplayProvinceCities(string province)
        {

        }

        public void RankProvincesByPopulation()
        {

        }
        public void RankProvincesByCities()
        {

        }
        public void GetCapital()
        {

        }
    }
}
