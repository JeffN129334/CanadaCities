namespace CanadaCities
{
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

                stats.ShowCityOnMap("London");
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
