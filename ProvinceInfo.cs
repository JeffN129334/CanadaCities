﻿namespace CanadaCities
{
    /*
      * Class Name:        ProvinceInfo
      * Purpose:           Represents information about a province, including its name, total population, number of cities, and capital city
      * Coder:             Jeff Nesbitt and Gui Miranda
      * Date:              2024-02-26
      */
    public class ProvinceInfo
    {
        public string ProvinceName { get; set; }
        public uint TotalPopulation { get; set; }
        public ushort CityCount { get; set; }
        public CityInfo CapitalCity { get; set; }

        /*
          * Method Name: Constructor
          * Purpose: Provide default values for a new ProvinceInfo object
          * Accepts: N/A
          * Returns:
          */
        public ProvinceInfo()
        {
            ProvinceName = "";
            TotalPopulation = 0;
            CityCount = 0;
            CapitalCity = new CityInfo();
        }

        /*
          * Method Name: Constructor [Overload]
          * Purpose: Populate the properties of a new ProvinceInfo object
          * Accepts: All of the properties for a new province
          * Returns:
          */
        public ProvinceInfo(string provName, uint totalPop, ushort cityNum, CityInfo capCity)
        {
            ProvinceName = provName;
            TotalPopulation = totalPop;
            CityCount = cityNum;
            CapitalCity = capCity;
        }
    }
}
