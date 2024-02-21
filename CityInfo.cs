using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaCities
{
    public class CityInfo
    {
        [JsonPropertyName("id")]
        public string CityID { get; set; }

        [JsonPropertyName("city")]
        public string CityName { get; set; }

        [JsonPropertyName("city_ascii")]
        public string CityASCII { get; set; }

        [JsonPropertyName("population")]
        public string Population { get; set; }

        [JsonPropertyName("admin_name")]
        public string Province { get; set; }

        [JsonPropertyName("lat")]
        public string Latitude { get; set; }

        [JsonPropertyName("lng")]
        public string Longitude { get; set; }

        /*
          * Method Name: GetLocation
          * Purpose: Parse the Latitude and Longitude properties to doubles and return them as a tuple
          * Accepts: N/A
          * Returns: A tuple containing the latitude and longitude as doubles
          */
        public Tuple<double, double> GetLocation()
        {
            return new Tuple<double, double>(double.Parse(Latitude), double.Parse(Longitude));
        }

        /*
          * Method Name: GetPopulation
          * Purpose: Parse the population property to an unsigned int and return it
          * Accepts: N/A
          * Returns: The population as type uint
          */
        public uint GetPopulation()
        {
            return uint.Parse(Population);
        }

        /*
          * Method Name: GetProvince
          * Purpose: Return the province property
          * Accepts: N/A
          * Returns: The province name as a string
          */
        public string GetProvince()
        {
            return Province;
        }

        /*
          * Method Name: Constructor
          * Purpose: Used for JSON serialization
          * Accepts: N/A
          * Returns:
          */
        public CityInfo()
        {
            CityID = "";
            CityName = "";
            CityASCII = "";
            Population = "";
            Province = "";
            Latitude = "";
            Longitude = "";
        }

        /*
          * Method Name: Constructor [Overload]
          * Purpose: Populate the properties of a new CityInfo object
          * Accepts: N/A
          * Returns:
          */
        public CityInfo(string cid, string cname, string cascii, string pop, string prov, string lat, string lon)
        {
            CityID = cid;
            CityName = cname;
            CityASCII = cascii;
            Population = pop;
            Province = prov;
            Latitude = lat;
            Longitude = lon;
        }
    }
}
