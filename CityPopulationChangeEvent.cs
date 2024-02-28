namespace CanadaCities
{
    /*
      * Class Name:        CityPopulationChangeEvent
      * Purpose:           Represents an event that notifies changes in a city's population.
      * Coder:             Jeff Nesbitt and Gui Miranda
      * Date:              2024-02-26
      */
    public class CityPopulationChangeEvent : EventArgs
    {
        public string CityName { get; }
        public int OldPopulation { get; }
        public int NewPopulation { get; }

        public CityPopulationChangeEvent(string cityName, int oldPopulation, int newPopulation)
        {
            CityName = cityName;
            OldPopulation = oldPopulation;
            NewPopulation = newPopulation;
        }
    }
}
