using CanadaCities.Comparers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanadaCities
{
    public class Statistics
    {
        public Dictionary<string, List<CityInfo>> CityCatalogue { get; set; }
        public Dictionary<string, ProvinceInfo> ProvinceCatalogue { get; set; }

        /*
          * Method Name: Constructor
          * Purpose: Calls upon the DataModeler to populate the local dictionaries with information from the file
          * Accepts: The name and type of the file
          * Returns:
          */
        public Statistics(string fileName, string fileType)
        {
            CityCatalogue = DataModeler.ParseFile(fileName, fileType);
            ProvinceCatalogue = DataModeler.ParseProvinces();
        }

        /*
          * Method Name: DisplayCityInformation
          * Purpose: Print city information for the city with the name passed in
          * Accepts: A city name
          * Returns: Void
          */
        public void DisplayCityInformation(string cityName)
        {
            Console.WriteLine($"Displaying information for the city of {cityName}...");
            ChooseCity(cityName).PrintInfo();
            Console.WriteLine("\n");
        }

        /*
          * Method Name: DisplayLargestCityPopulation
          * Purpose: Populate a sorted set with info for all of the cities that are within the passed in province. Then print the last (largest) item from the set
          * Accepts: A province name
          * Returns: Void
          * Notes: The sorted set is sorted using the IComparable interface which is implemented within the CityInfo class
          */
        public void DisplayLargestCityPopulation(string province)
        {
            Console.WriteLine($"Displaying information for the city with the largest population in {province}...");
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
                Console.WriteLine($"No cities found in province {province}!");
            }
            else
            {
                //Print the last item from the sorted set (the largest)
                citiesByPopulation.Last().PrintInfo();
            }
            Console.WriteLine("\n");
        }

        /*
          * Method Name: DisplaySmallestCityPopulation
          * Purpose: Populate a sorted set with info for all of the cities that are within the passed in province. Then print the first (smallest) item from the set
          * Accepts: A province name
          * Returns: Void
          * Notes: The sorted set is sorted using the IComparable interface which is implemented within the CityInfo class
          */
        public void DisplaySmallestCityPopulation(string province)
        {
            Console.WriteLine($"Displaying information for the city with the smallest population in {province}...");
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
                Console.WriteLine($"No cities found in province {province}!");
            }
            else
            {
                //Print the first item from the sorted set (the smallest)
                citiesByPopulation.First().PrintInfo();
            }
            Console.WriteLine("\n");
        }

        /*
          * Method Name: CompareCitiesPopulation
          * Purpose: Print the populations of the two cities passed in. Then compare them and print all of the city information for the larger one
          * Accepts: Information on two cities
          * Returns: Void
          * Notes: The comparison is made using the IComparable interface which is implemented within the CityInfo class
          */
        public void CompareCitiesPopulation(string nameOne, string nameTwo)
        {
            Console.WriteLine($"Comparing populations for {nameOne} and {nameTwo}...");
            CityInfo cityOne = ChooseCity(nameOne);
            CityInfo cityTwo = ChooseCity(nameTwo);
            //Print populations
            Console.WriteLine($"The population of {nameOne} is {cityOne.Population}.");
            Console.WriteLine($"The population of {nameTwo} is {cityTwo.Population}.");

            //The compare method will return 1 if cityOne is larger, -1 if cityTwo is larger, and 0 if they are the same
            if (cityOne.CompareTo(cityTwo) > 0)
            {
                Console.WriteLine($"{cityOne.CityName} is larger by {cityOne.GetPopulation() - cityTwo.GetPopulation()} people! \nDisplaying relevant information...");
                cityOne.PrintInfo();
            } 
            else if (cityOne.CompareTo(cityTwo) < 0)
            {
                Console.WriteLine($"{cityTwo.CityName} is larger by {cityTwo.GetPopulation() - cityOne.GetPopulation()} people! \nDisplaying relevant information...");
                cityTwo.PrintInfo();
            }
            else
            {
                Console.WriteLine($"{cityOne.CityName} and {cityTwo.CityName} are the same size!");
            }
            Console.WriteLine("\n");
        }

        //TODO: Implement Statistics.ShowCitiesOnMap
        public void ShowCitiesOnMap(CityInfo cityToDisplay)
        {
            throw new NotImplementedException();
        }

        //TODO: Implement Statistics.CalculateDistanceBetweenCities
        public void CalculateDistanceBetweenCities(CityInfo cityOne, CityInfo cityTwo)
        {
            throw new NotImplementedException();
        }

        /*
          * Method Name: DisplayProvincePopulation
          * Purpose: Display the total population of a given province
          * Accepts: A province name
          * Returns: Void
          */
        public void DisplayProvincePopulation(string province)
        {
            Console.WriteLine($"Displaying total population of the province of {province}...");
            //If the province name is valid
            if (ProvinceCatalogue.ContainsKey(province))
            {
                Console.WriteLine($"The total population of the province of {province} is {ProvinceCatalogue[province].TotalPopulation}!");
            }
            else
            {
                Console.WriteLine($"Province {province} not found!");
            }
            Console.WriteLine("\n");
        }

        /*
          * Method Name: DisplayProvinceCities
          * Purpose: Display the names of all of the cities within a given province
          * Accepts: A province name
          * Returns: Void
          */
        public void DisplayProvinceCities(string province)
        {
            Console.WriteLine($"Displaying city list for the province of {province}...");

            ushort i = 0;

            //For each city in the catalog...
            foreach (var item in CityCatalogue)
            {
                //Including duplicates...
               foreach (var city in item.Value)
                {
                    //Check if it is within the given province
                    if (city.Province.Equals(province))
                    {
                        //Print out its name
                        Console.WriteLine($"{++i}:\t{city.CityName}");
                    }
                }
            }
            //If no matching cities are found output a message
            if (i == 0)
            {
                Console.WriteLine($"No cities found within province {province}!");
            }
            Console.WriteLine("\n");
        }

        /*
          * Method Name: RankProvincesByPopulation
          * Purpose: Populate a sorted set with info for all of the provinces in the province catalogue. Then print them to the console in ascending order
          * Accepts: N/A
          * Returns: Void
          * Notes: The sorted set is sorted using the IComparer interface which is implemented within the SortProvincesByPopulation class
          */
        public void RankProvincesByPopulation()
        {
            Console.WriteLine($"Ranking provinces by population...");
            //Sorted set which automatically sorts ProvinceInfo objects using the SortProvincesByPopulation class, which inherits the IComparer interface
            SortedSet<ProvinceInfo> provincesByPopulation = new SortedSet<ProvinceInfo>(new SortProvincesByPopulation());

            //For each province
            foreach (var province in ProvinceCatalogue)
            {
                //Add it to the sorted set
                provincesByPopulation.Add(province.Value);
            }

            //If no provinces were found
            if (provincesByPopulation.Count <= 0)
            {
                Console.WriteLine("No province data found!");
            }
            else
            {
                int i = 1;
                //Print all of the data in the sorted set
                foreach (var province in provincesByPopulation)
                {
                    Console.WriteLine("{0,-3} {1,-25} Population: {2}", (i++)+":", province.ProvinceName, province.TotalPopulation);
                }
            }
            Console.WriteLine("\n");
        }

        /*
          * Method Name: RankProvincesByCities
          * Purpose: Populate a sorted set with info for all of the provinces in the province catalogue. Then print them to the console in ascending order
          * Accepts: N/A
          * Returns: Void
          * Notes: The sorted set is sorted using the IComparer interface which is implemented within the SortProvincesByCityCount class
          */
        public void RankProvincesByCities()
        {
            Console.WriteLine($"Ranking provinces by city count...");
            //Sorted set which automatically sorts ProvinceInfo objects using the SortProvincesByCityCount class, which inherits the IComparer interface
            SortedSet<ProvinceInfo> provincesByCityCount = new SortedSet<ProvinceInfo>(new SortProvincesByCityCount());

            //For each province
            foreach (var province in ProvinceCatalogue)
            {
                //Add it to the sorted set
                provincesByCityCount.Add(province.Value);
            }

            //If no provinces were found
            if (provincesByCityCount.Count <= 0)
            {
                Console.WriteLine("No province data found!");
            }
            else
            {
                int i = 1;
                //Print all of the data in the sorted set
                foreach (var province in provincesByCityCount)
                {
                    Console.WriteLine("{0,-3} {1,-25} City Count: {2}", (i++) + ":", province.ProvinceName, province.CityCount);
                }
            }
            Console.WriteLine("\n");
        }

        /*
          * Method Name: GetCapital
          * Purpose: Display the name and location of the capital city of a given province
          * Accepts: A province name
          * Returns: Void
          */
        public void GetCapital(string province)
        {
            Console.WriteLine($"Displaying capital city information for the province of {province}...");
            //If the province name is valid...
            if (ProvinceCatalogue.ContainsKey(province))
            {
                Console.WriteLine($"The capital city of the province of {province} is {ProvinceCatalogue[province].CapitalCity.CityName}!");
                Console.WriteLine($"{ProvinceCatalogue[province].CapitalCity.CityName} is located at {ProvinceCatalogue[province].CapitalCity.GetLocation().Item1} latitude and {ProvinceCatalogue[province].CapitalCity.GetLocation().Item2} longitude!");
            }
            else
            {
                Console.WriteLine($"No province found with the name {province}");
            }
            Console.WriteLine("\n");
        }

        /*
          * Method Name: ChooseCity
          * Purpose: A helper method to validate a city name, and prompt the user for a choice if there are multiple cities with the name
          * Accepts: A list of identically named cities
          * Returns: The information object for the chosen city
          */
        public CityInfo ChooseCity(string cityName)
        {
            //If the city name is a valid city
            if (CityCatalogue.ContainsKey(cityName))
            {
                //If there is more than one city by that name...
                if (CityCatalogue[cityName].Count > 1)
                {
                    //Display menu for user to choose from
                    Console.WriteLine($"There are {CityCatalogue[cityName].Count} cities in Canada by that name. Please input the number beside the city you are interested in:");
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
                        Console.WriteLine("Error, invalid selection!");
                    }
                    //Display a brief message to the user and return the chosen city
                    Console.WriteLine($"Using information for the city of {CityCatalogue[cityName][selection].CityName}, {CityCatalogue[cityName][selection].GetProvince()}...");
                    return CityCatalogue[cityName][selection];
                }
                //If there is only one city by that name...
                else if (CityCatalogue[cityName].Count == 1)
                {
                    //Return it
                    return CityCatalogue[cityName][0];
                }
                //If there is no data under the city name key
                else
                {
                    throw new Exception($"No data found for {cityName}!");
                } 
            }
            //If the city name is not found in the dictionary
            else {
                throw new Exception($"City {cityName} not found!");
            }
        }
    }
}
