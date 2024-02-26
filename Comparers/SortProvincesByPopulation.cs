namespace CanadaCities.Comparers
{
    public class SortProvincesByPopulation : IComparer<ProvinceInfo>
    {
        public int Compare(ProvinceInfo? x, ProvinceInfo? y)
        {
            if (x is null) { return -1; }
            if (y is null) { return 1; }
            return x.TotalPopulation.CompareTo(y.TotalPopulation);
        }
    }
}
