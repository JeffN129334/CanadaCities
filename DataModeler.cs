using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CanadaCities
{
    /**
     * Class Name:		DataModeler
     * Purpose:			To parse an input file into a dictionary containing City Information
     * Coder:			    Gui Miranda and Jeff Nesbitt
     * Date:			    2024-02-21
     */
    public static class DataModeler
    {
        //Declare customized delegate matching the signature of the parse methods
        private delegate void Parser(string fileName);

        //Private dictionary containing city information with the city name as the key and the information object as the value
        //A list is used as the value so that cities with the same names can store their information under the same key
        private static Dictionary<string, List<CityInfo>> CityCatalogue = new Dictionary<string, List<CityInfo>>();

        /*
          * Method Name: ParseXML
          * Purpose: Parse the inputted XML file into the private dictionary member variable using LINQ to XML
          * Accepts: A string containing the name of the XML input file
          * Returns: void
          */
        private static void ParseXML(string fileName)
        {
            try
            {
                //Create new XDocument and load the file
                XDocument doc = XDocument.Load(fileName);

                //Use Select to transform the Elements of the XMLDocument to a list of CityInfo objects
                List<CityInfo> cityList = doc.Root!.Elements("CanadaCity").Select(cityElement => new CityInfo(
                    cityElement.Element("id")!.Value,
                    cityElement.Element("city")!.Value,
                    cityElement.Element("city_ascii")!.Value,
                    cityElement.Element("population")!.Value,
                    cityElement.Element("admin_name")!.Value,
                    cityElement.Element("lat")!.Value,
                    cityElement.Element("lng")!.Value
                    )
                ).ToList();

                //If the list is empty throw an exception
                if (cityList.Count <= 0)
                {
                    throw new Exception("No data found");
                }

                //Clear out any data from the CityCatalogue dictionary
                CityCatalogue.Clear();

                //For each city in the list...
                foreach (CityInfo city in cityList)
                {
                    //If there is no data, skip the entry
                    if (city.CityName == "")
                    {
                        continue;
                    }
                    //If there is already a city in the dictionary with the name of the current entry
                    if (CityCatalogue.ContainsKey(city.CityName))
                    {
                        //Insert the current entry into the list of CityInfo objects matching the key
                        CityCatalogue[city.CityName].Add(city);
                    }
                    else
                    {
                        //Create a new dictionary entry for the key and add the city info
                        List<CityInfo> tempList = new List<CityInfo> { city };
                        CityCatalogue.Add(city.CityName, tempList);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        /*
          * Method Name: ParseJSON
          * Purpose: Parse the inputted JSON file into the private dictionary member variable using JSONSerializer
          * Accepts: A string containing the name of the JSON input file
          * Returns: void
          */
        private static void ParseJSON(string fileName)
        {
            try
            {
                //Read all the text from the file
                string jsonContent = File.ReadAllText(fileName);

                //Deserialize the text into a list of CityInfo objects
                List<CityInfo> cityList = JsonSerializer.Deserialize<List<CityInfo>>(jsonContent)!;

                //If the list is empty throw an exception
                if (cityList.Count <= 0)
                {
                    throw new Exception("No data found");
                }

                //Clear out any data from the CityCatalogue dictionary
                CityCatalogue.Clear();

                //For each city in the list...
                foreach (CityInfo city in cityList)
                {
                    //If there is no data, skip the entry
                    if (city.CityName == "")
                    {
                        continue;
                    }

                    //If there is already a city in the dictionary with the name of the current entry
                    if (CityCatalogue.ContainsKey(city.CityName))
                    {
                        //Insert the current entry into the list of CityInfo objects matching the key
                        CityCatalogue[city.CityName].Add(city);
                    }
                    else
                    {
                        //Create a new dictionary entry for the key and add the city info
                        List<CityInfo> tempList = new List<CityInfo> { city };
                        CityCatalogue.Add(city.CityName, tempList);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        /*
          * Method Name: ParseCSV
          * Purpose: Parse the inputted CSV file into the private dictionary member variable using String.Split
          * Accepts: A string containing the name of the CSV input file
          * Returns: void
          */
        private static void ParseCSV(string fileName)
        {
            try
            {
                List<CityInfo> cityList = new List<CityInfo>();

                //Read all the text from the file
                string csvContent = File.ReadAllText(fileName);

                //Split the text into rows
                string[] rows = csvContent.Split('\n');
                string[] fields;

                //For each row (minus the first one which contains the headers)
                for(int i = 1; i < rows.Length - 1; i++)
                {
                    //Split the rows into fields
                    fields = rows[i].Split(',');
                    //Create a new CityInfo object
                    cityList.Add(new CityInfo
                    (
                        fields[8],  //Id
                        fields[0],  //City Name
                        fields[1],  //City ASCII
                        fields[7],  //Population
                        fields[5],  //Province
                        fields[2],  //Latitude
                        fields[3]   //Longitude
                    ));
                }

                //If the list is empty throw an exception
                if (cityList.Count <= 0)
                {
                    throw new Exception("No data found");
                }

                //Clear out any data from the CityCatalogue dictionary
                CityCatalogue.Clear();

                //For each city in the list...
                foreach (CityInfo city in cityList)
                {
                    //If there is no data, skip the entry
                    if (city.CityName == "")
                    {
                        continue;
                    }

                    //If there is already a city in the dictionary with the name of the current entry
                    if (CityCatalogue.ContainsKey(city.CityName))
                    {
                        //Insert the current entry into the list of CityInfo objects matching the key
                        CityCatalogue[city.CityName].Add(city);
                    }
                    else
                    {
                        //Create a new dictionary entry for the key and add the city info
                        List<CityInfo> tempList = new List<CityInfo> { city };
                        CityCatalogue.Add(city.CityName, tempList);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        /*
        * Method Name: ParseFile
        * Purpose: Invoke a private parser method using a delegate and return the contents
        * Accepts: A string containing the name of the input file, A string containing the type of input file
        * Returns: The local dictionary object which is populated via the private parser methods
        */
        public static Dictionary<string, List<CityInfo>> ParseFile(string fileName, string fileType)
        {
            //Create a new parser delegate
            Parser parser;
            string fileSelection = fileType.ToUpper();

            //Instantiate the delegate with the appropriate method based on the fileType
            switch (fileSelection)
            {
                case "XML":
                    {
                        parser = ParseXML;
                        break;
                    }
                case "JSON":
                    {
                        parser = ParseJSON;
                        break;
                    }
                case "CSV":
                    {
                        parser = ParseCSV;
                        break;
                    }
                default:
                    {
                        throw new Exception("Invalid File Format!");
                    }
            } 

            //Invoke the delegate
            parser.Invoke(fileName);
            return CityCatalogue;
        }
    }
}
