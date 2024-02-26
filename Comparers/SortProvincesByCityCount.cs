using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanadaCities.Comparers
{
    public class SortProvincesByCityCount : IComparer<ProvinceInfo>
    {
        public int Compare(ProvinceInfo? x, ProvinceInfo? y)
        {
            if (x is null) { return -1; }
            if (y is null) { return 1; }
            return x.CityCount.CompareTo(y.CityCount);
        }
    }
}
