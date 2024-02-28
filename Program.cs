namespace CanadaCities
{
    /*
      * Class Name:        Program
      * Purpose:           Entry point of the application, contains the main method to execute the program
      * Coder:             Jeff Nesbitt and Gui Miranda
      * Date:              2024-02-26
      */
    public class Program
    {
        public static void Main()
        {
            //TODO: Make a proper UI
            try
            {
                Statistics stats = new Statistics("..\\..\\..\\Data\\Canadacities-XML.xml", "XML");
                //Statistics stats = new Statistics("..\\..\\..\\Data\\Canadacities-JSON.json", "JSON");
                //Statistics stats = new Statistics("..\\..\\..\\Data\\Canadacities.csv", "CSV");

                //stats.DisplayCityInformation("Toronto");
                //stats.DisplayCityInformation("Deer Lake");    //Duplication tester
                //stats.DisplayLargestCityPopulation("Ontario");
                //stats.DisplaySmallestCityPopulation("Ontario");
                //stats.CompareCitiesPopulation("Toronto", "Ottawa");

                //stats.DisplayProvinceCities("Ontario");
                //stats.DisplayProvincePopulation("Ontario");
                //stats.GetCapital("Ontario");

                stats.RankProvincesByPopulation();
                stats.RankProvincesByCities();

                //stats.ShowCityOnMap("London");

                double distance = stats.CalculateDistanceBetweenCities("London", "Toronto");
                Console.WriteLine($"Distance between London and Toronto: {Math.Round(distance, 2)}km");

                CityInfo city = new CityInfo();
                city.PopulationChanging += PopulationChangingEventHandler;
                city.CityName = "London";
                city.Population = "50000";
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        //Event handler method for the PopulationChanging event
        static void PopulationChangingEventHandler(object sender, CityPopulationChangeEvent e)
        {
            //Your event handling logic goes here
            Console.WriteLine($"Population of {e.CityName} is changing from {e.OldPopulation} to {e.NewPopulation}");
        }
    }
}
