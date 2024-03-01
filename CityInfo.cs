using System.Text.Json.Serialization;

namespace CanadaCities
{
    /*
      * Class Name:        CityInfo
      * Purpose:           Represents information about a city, including population, location, and other details
      * Coder:             Jeff Nesbitt and Gui Miranda
      * Date:              2024-02-26
      */
    public class CityInfo : IComparable<CityInfo>
    {
        private string population;

        [JsonPropertyName("id")]
        public string CityID { get; set; }

        [JsonPropertyName("city")]
        public string CityName { get; set; }

        [JsonPropertyName("city_ascii")]
        public string CityASCII { get; set; }

        [JsonPropertyName("population")]
        public string Population
        {
            get => population;
            set
            {
                if (population != value)
                {
                    //Get old and new population
                    int oldPopulation = !string.IsNullOrEmpty(population) ? int.Parse(population) : 0;
                    int newPopulation = !string.IsNullOrEmpty(value) ? int.Parse(value) : 0;

                    //Raise PopulationChanging event
                    OnPopulationChanging(new CityPopulationChangeEvent(CityName, oldPopulation, newPopulation));

                    //Set new population value
                    population = value!;
                }
            }
        }

        [JsonPropertyName("admin_name")]
        public string Province { get; set; }

        [JsonPropertyName("lat")]
        public string Latitude { get; set; }

        [JsonPropertyName("lng")]
        public string Longitude { get; set; }

        [JsonPropertyName("capital")]
        public string Capital { get; set; }

        // Define event handler delegate for population changing event
        public delegate void PopulationChangingHandler(object sender, CityPopulationChangeEvent e);

        // Define PopulationChanging event based on the delegate
        public event PopulationChangingHandler PopulationChanging;

        /*
          * Method Name:        OnPopulationChanging
          * Purpose:            Raises the PopulationChanging event by invoking its delegates
          *                     If there are subscribers to the event, it notifies them about the population change
          * Accepts:            The CityPopulationChangeEvent object containing information about the population change
          * Returns:            Void
          * Parameters:
          *      e (CityPopulationChangeEvent): The event arguments containing details about the population change
          */
        protected virtual void OnPopulationChanging(CityPopulationChangeEvent e)
        {
            PopulationChanging?.Invoke(this, e);
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
            Capital = "";
        }

        /*
          * Method Name: Constructor [Overload]
          * Purpose: Populate the properties of a new CityInfo object
          * Accepts: All of the properties for a new city
          * Returns:
          */
        public CityInfo(string cid, string cname, string cascii, string pop, string prov, string lat, string lon, string cap)
        {
            CityID = cid;
            CityName = cname;
            CityASCII = cascii;
            Population = pop;
            Province = prov;
            Latitude = lat;
            Longitude = lon;
            Capital = cap;
        }

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
          * Method Name: IsCapital
          * Purpose: Return a bool reflecting whether or not the city is a capital city
          * Accepts: N/A
          * Returns: A boolean
          */
        public bool IsCapital()
        {
            return Capital != "";
        }

        /*
          * Method Name: PrintInfo
          * Purpose: Print all of the city information in a nicely formatted manner
          * Accepts: N/A
          * Returns: Void
          */
        public void PrintInfo()
        {
            Console.WriteLine("{0,-18}{1}", "City Id:", CityID);
            Console.WriteLine("{0,-18}{1}", "City Name:", CityName);
            Console.WriteLine("{0,-18}{1}", "City ASCII:", CityASCII);
            Console.WriteLine("{0,-18}{1:N0}", "City Population:", Convert.ToInt64(Population));
            Console.WriteLine("{0,-18}{1}", "City Province:", Province);
            Console.WriteLine("{0,-18}{1}", "City Latitude:", Latitude);
            Console.WriteLine("{0,-18}{1}", "City Longitude:", Longitude);
        }

        /*
          * Method Name: CompareTo
          * Purpose: Comparison method for comparing and sorting cities based on Population
          * Accepts: The City info object which will be compared to this one
          * Returns: An integer representing the result of the comparison
          */
        public int CompareTo(CityInfo? other)
        {
            if (other is null) { return 1; }
            return GetPopulation().CompareTo(other.GetPopulation());
        }
    }
}
