using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanadaCities
{
    public class Statistics
    {
        public Dictionary<string, List<CityInfo>> CityCatalogue { get; set; }

        /*
          * Method Name: Constructor
          * Purpose: Calls upon the DataModeler to populate the local dictionary with information from the file
          * Accepts: The name and type of the file
          * Returns:
          */
        public Statistics(string fileName, string fileType)
        {
            CityCatalogue = DataModeler.ParseFile(fileName, fileType);
        }

        /*
          * Method Name: DisplayCityInformation
          * Purpose: Print city information for the city with the name passed in. If there are multiple cities with that name, prompt the user for a choice
          * Accepts: A city name
          * Returns: Void
          */
        public void DisplayCityInformation(string cityName)
        {
            //If the city name is valid and within the dictionary
            if (CityCatalogue.ContainsKey(cityName))
            {
                //If there is more than one city with the name given
                if (CityCatalogue[cityName].Count > 1)
                {
                    //Display menu for user to choose from
                    Console.WriteLine("There are two cities in Canada by that name. Please input the number beside the city you are interested in:");
                    for (int i = 0; i < CityCatalogue[cityName].Count; i++)
                    {
                        Console.WriteLine($"{i + 1}: {CityCatalogue[cityName][i].CityName}, {CityCatalogue[cityName][i].GetProvince()}");
                    }

                    //Get a response from the user
                    ushort selection;
                    while (true)
                    {
                        char input = Console.ReadKey().KeyChar;
                        if (ushort.TryParse(input.ToString(), out selection))
                        {
                            selection--;
                            if (selection >= 0 && selection < CityCatalogue[cityName].Count) { break; }
                        }
                        Console.WriteLine(" --> Error, invalid selection!");
                    }

                    //Display the City information for the city selected by the user
                    Console.WriteLine("Displaying relevant city information...");
                    CityCatalogue[cityName][selection].PrintInfo();
                }
                else
                {
                    //If there is only one city matching the name then display the first (and only) item from the list
                    Console.WriteLine("Displaying relevant city information...");
                    CityCatalogue[cityName][0].PrintInfo();
                }
            }
            else
            {
                Console.WriteLine("City not found!");
                return;
            }
        }

        /*
          * Method Name: DisplayLargestCityPopulation
          * Purpose: Populate a sorted set with info for all of the cities that are within the passed in province. Then return the last (largest) item from the set
          * Accepts: A province name
          * Returns: Void
          * Notes: The sorted set is sorted using the IComparable interface which is implemented within the CityInfo class
          */
        public void DisplayLargestCityPopulation(string province)
        {
            //Sorted set which automatically sorts CityInfo objects using the IComparable interface
            SortedSet<CityInfo> citiesByPopulation = new();

            //For each city (including duplicates)
            foreach (var cityInfos in CityCatalogue)
            {
                foreach (CityInfo cityInfo in cityInfos.Value)
                {
                    //If it is within the province passed in
                    if (cityInfo.Province.Equals(province))
                    {
                        //Add to the sorted set
                        citiesByPopulation.Add(cityInfo);
                    }
                }
            }

            //If no cities were found matching the province
            if (citiesByPopulation.Count <= 0)
            {
                Console.WriteLine("No cities found matching that province name!");
                return;
            }

            //Print the last item from the sorted set (the largest)
            Console.WriteLine($"Displaying information for the city with the largest population in {province}...");
            citiesByPopulation.Last().PrintInfo();
        }

        /*
          * Method Name: DisplaySmallestCityPopulation
          * Purpose: Populate a sorted set with info for all of the cities that are within the passed in province. Then return the first (smallest) item from the set
          * Accepts: A province name
          * Returns: Void
          * Notes: The sorted set is sorted using the IComparable interface which is implemented within the CityInfo class
          */
        public void DisplaySmallestCityPopulation(string province)
        {
            //Sorted set which automatically sorts CityInfo objects using the IComparable interface
            SortedSet<CityInfo> citiesByPopulation = new();

            //For each city (including duplicates)
            foreach (var cityInfos in CityCatalogue)
            {
                foreach (CityInfo cityInfo in cityInfos.Value)
                {
                    //If it is within the province passed in
                    if (cityInfo.Province.Equals(province))
                    {
                        //Add to the sorted set
                        citiesByPopulation.Add(cityInfo);
                    }
                }
            }

            //If no cities were found matching the province
            if (citiesByPopulation.Count <= 0)
            {
                Console.WriteLine("No cities found matching that province name!");
                return;
            }

            //Print the first item from the sorted set (the smallest)
            Console.WriteLine($"Displaying information for the city with the smallest population in {province}...");
            citiesByPopulation.First().PrintInfo();
        }

        /*
          * Method Name: CompareCitiesPopulation
          * Purpose: Print the population of the two cities passed in. Then compare them and return all of the city information for the larger one
          * Accepts: Information on two cities
          * Returns: Void
          * Notes: The comparison is made using the IComparable interface which is implemented within the CityInfo class
          */
        public void CompareCitiesPopulation(CityInfo cityOne, CityInfo cityTwo)
        {
            //Print populations
            Console.WriteLine($"The population of {cityOne.CityName} is {cityOne.Population}.");
            Console.WriteLine($"The population of {cityTwo.CityName} is {cityTwo.Population}.");

            //The compare method will return 1 if cityOne is larger, -1 if cityTwo is larger, and 0 if they are the same
            if (cityOne.CompareTo(cityTwo) > 0)
            {
                Console.WriteLine($"{cityOne.CityName} is larger by {cityOne.GetPopulation() - cityTwo.GetPopulation()} people! Displaying relevant information...");
                cityOne.PrintInfo();
            } 
            else if (cityOne.CompareTo(cityTwo) < 0)
            {
                Console.WriteLine($"{cityTwo.CityName} is larger by {cityTwo.GetPopulation() - cityOne.GetPopulation()} people! Displaying relevant information...");
                cityTwo.PrintInfo();
            }
            else
            {
                Console.WriteLine($"{cityOne.CityName} and {cityTwo.CityName} are the same size!");
            }
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
