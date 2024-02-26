namespace CanadaCities
{
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
